using System;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces.Model.Enums;
using STFU.Lib.Youtube.Internal.Upload.Model;
using STFU.Lib.Youtube.Model.Serializable;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal class YoutubeVideoUploader : UploadStep
	{
		FileUploader fileUploader = new FileUploader();

		internal YoutubeVideoUploader(IYoutubeVideo video, IYoutubeAccount account)
			: base(video, account)
		{
			fileUploader.PropertyChanged += OnUploadProgressChanged;
		}

		public override async Task RunAsync()
		{
			await Task.Run(() => Run());
		}

		public void Run()
		{
			State = UploadStepState.Initializing;

			bool successful = false;
			HttpWebRequest request = null;
			long lastLastByte = -1;
			int tries = 0;

			try
			{
				while (!successful && tries < 10
					&& State != UploadStepState.CancelPending
					&& State != UploadStepState.Canceled
					&& State != UploadStepState.PausePending
					&& State != UploadStepState.Paused)
				{
					var lastbyte = CheckUploadStatus();

					if (lastbyte == -1)
					{
						request = HttpWebRequestCreator.CreateForNewUpload(Video.UploadUri, Video, Account);
					}
					else
					{
						request = HttpWebRequestCreator.CreateForResumeUpload(Video.UploadUri, Video, Account, lastbyte);
					}

					State = UploadStepState.Running;

					successful = fileUploader.UploadFile(Video.Path, request, (long)128 * 1000 * 1000 * 1000, lastbyte + 1);

					if (lastLastByte == lastbyte)
					{
						tries++;
					}
					else
					{
						tries = 0;
						lastLastByte = lastbyte;
					}

					if (!successful)
					{
						if (State != UploadStepState.CancelPending
							&& State != UploadStepState.Canceled
							&& State != UploadStepState.PausePending
							&& State != UploadStepState.Paused)
						{
							State = UploadStepState.Broke;
							Thread.Sleep(90000);
						}
					}
				}
			}
			catch (Exception failed)
			{
				// Thats ok, I guess?
				Console.WriteLine(failed);
			}

			if (successful)
			{
				request.Headers.Set("Authorization", $"Bearer {Account.GetActiveToken()}");
				string result = WebService.Communicate(request);

				Video.Id = JsonConvert.DeserializeObject<SerializableYoutubeVideo>(result).id;
				State = UploadStepState.Successful;
			}
			else if (State == UploadStepState.CancelPending)
			{
				State = UploadStepState.Canceled;
			}
			else if (State != UploadStepState.Paused)
			{
				State = UploadStepState.Error;
			}
		}

		private void OnUploadProgressChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(fileUploader.Progress))
			{
				Progress = fileUploader.Progress;
			}
			else if (e.PropertyName == nameof(fileUploader.CurrentSpeed))
			{
				CurrentSpeed = fileUploader.CurrentSpeed;
			}
			else if (e.PropertyName == nameof(fileUploader.RemainingDuration))
			{
				RemainingDuration = fileUploader.RemainingDuration;
			}
			else if (e.PropertyName == nameof(fileUploader.Started))
			{
				Started = fileUploader.Started;
			}
			else if (e.PropertyName == nameof(fileUploader.UploadedDuration))
			{
				CurrentDuration = fileUploader.UploadedDuration;
			}
			else if (e.PropertyName == nameof(fileUploader.FailureReason))
			{
				Error = FailReasonConverter.GetError(fileUploader.FailureReason);
				State = UploadStepState.Error;
			}
			else if (e.PropertyName == nameof(fileUploader.RunningState))
			{
				if (fileUploader.RunningState == RunningState.Paused)
				{
					State = UploadStepState.Paused;
				}
				else if (fileUploader.RunningState == RunningState.Running
					&& (State == UploadStepState.PausePending || State == UploadStepState.Paused))
				{
					State = UploadStepState.Running;
				}
			}
		}

		internal long CheckUploadStatus()
		{
			var request = HttpWebRequestCreator.CreateWithAuthHeader(Video.UploadUri.AbsoluteUri, "PUT", Account.GetActiveToken());
			request.ContentLength = 0;
			request.Headers.Add($"content-range: bytes */{Video.File.Length}");

			var answer = WebService.Communicate(request);
			if (answer == null)
			{
				return -1;
			}

			answer = answer.Substring("bytes=".Length);

			long lastbyte;
			try
			{
				lastbyte = Convert.ToInt64(answer.Split('-')[1]);
			}
			catch (Exception)
			{
				return -1;
			}

			return lastbyte;
		}

		public override void Cancel()
		{
			if (State == UploadStepState.Initializing || State == UploadStepState.Running)
			{
				State = UploadStepState.CancelPending;
				fileUploader.Cancel();
			}
		}

		public override void Pause()
		{
			if (State == UploadStepState.Initializing || State == UploadStepState.Running)
			{
				State = UploadStepState.PausePending;
				fileUploader.Pause();
			}
		}

		public override void Resume()
		{
			if (State == UploadStepState.PausePending || State == UploadStepState.Paused)
			{
				fileUploader.SetSateToRunning();
				Run();
			}
		}
	}
}
