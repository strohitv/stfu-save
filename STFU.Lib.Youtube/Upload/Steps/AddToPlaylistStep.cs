using System;
using System.Text;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model.Serializable;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class AddToPlaylistStep : AbstractUploadStep
	{
		private double progress = 0.0;

		public override double Progress => progress;

		public AddToPlaylistStep(IYoutubeJob job)
			: base(job) { }

		internal override void Run()
		{
			progress = 0;

			if (Video.AddToPlaylist && !string.IsNullOrWhiteSpace(Video.PlaylistId))
			{
				LOGGER.Info($"Adding video '{Video.Title}' to playlist with id '{Video.PlaylistId}'");

				var request = HttpWebRequestCreator.CreateWithAuthHeader("https://www.googleapis.com/youtube/v3/playlistItems?part=snippet", "POST", Account.GetActiveToken());
				request.ContentType = "application/json";

				YoutubePlaylistItem resource = new YoutubePlaylistItem(Video.PlaylistId, Video.Id);
				var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(resource));

				var response = WebService.Communicate(request, bytes);
				Status.QuotaReached = QuotaProblemHandler.IsQuotaLimitReached(response);

				if (!Status.QuotaReached)
				{
					LOGGER.Info($"Video '{Video.Title}' was successfully added to playlist with id '{Video.PlaylistId}'");

					FinishedSuccessful = true;
					progress = 100;
				}
			}
			else
			{
				LOGGER.Info($"Skipping playlist add since it is either not wanted or there is no playlist id");

				FinishedSuccessful = true;
				progress = 100;
			}

			OnStepFinished();
		}

		public override void RefreshDurationAndSpeed()
		{
			Status.CurrentSpeed = 0;
			Status.UploadedDuration = new TimeSpan(0, 0, 0);
			Status.RemainingDuration = new TimeSpan(0, 0, 0);
		}

		public override void Cancel()
		{
			// Höhö, das kann man nicht abbrechen lol
			LOGGER.Warn($"Called cancel but it is not possible on this type of step");
		}
	}
}
