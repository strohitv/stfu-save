using System;
using System.Text;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Model.Serializable;
using STFU.Lib.Youtube.Services;

namespace STFU.Lib.Youtube.Upload.Steps
{
	public class ChangeVideoDetailsStep : AbstractUploadStep
	{
		private double progress = 0.0;

		public override double Progress => progress;

		public ChangeVideoDetailsStep(IYoutubeJob job)
			: base(job) { }

		internal override void Run()
		{
			// TODO: try-catch außenrum bauen für den Fall, dass da was schiefgeht..
			progress = 0;

			var request = HttpWebRequestCreator.CreateWithAuthHeader("https://www.googleapis.com/youtube/v3/videos?part=snippet,status", "PUT", Account.GetActiveToken());
			request.ContentType = "application/json";

			SerializableYoutubeVideo resource = SerializableYoutubeVideo.Create(Video);
			var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(resource));

			var response = WebService.Communicate(request, bytes);
			Status.QuotaReached = QuotaProblemHandler.IsQuotaLimitReached(response);

			if (!Status.QuotaReached)
			{
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
		}
	}
}
