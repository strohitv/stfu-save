using System.Linq;
using System.Web;
using STFU.Lib.Common;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.MailSender.Generator
{
	public class NewVideoFoundMailGenerator : IMailGenerator
	{
		public string Generate(IYoutubeJob job)
		{
			var tags = "";

			if (job.Video.Tags.Count > 0)
			{
				tags = job.Video.Tags.First();
			}

			for (int i = 1; i < job.Video.Tags.Count; i++)
			{
				tags = $"{tags},{job.Video.Tags.ElementAt(i)}";
			}

			var privacy = string.Empty;
			switch (job.Video.Privacy)
			{
				case Youtube.Interfaces.Model.Enums.PrivacyStatus.Public:
					privacy = "Öffentlich";
					break;
				case Youtube.Interfaces.Model.Enums.PrivacyStatus.Unlisted:
					privacy = "Nicht gelistet";
					break;
				case Youtube.Interfaces.Model.Enums.PrivacyStatus.Private:
					privacy = "Privat";
					break;
			}

			return string.Format(
				template,
				HttpUtility.HtmlEncode(job.Video.Title),
				HttpUtility.HtmlEncode(job.Account.Title),
				HttpUtility.HtmlEncode(job.Video.Privacy.ToString()),
				job.Video.PublishAt != null ? job.Video.PublishAt.Value.ToString("dd.MM.yyyy HH:mm") : "keine Ver&ouml;ffentlichung geplant",
				job.Video.Description.Length <= 500 ? job.Video.Description : $"{job.Video.Description.Substring(0, 497)}...",
				tags,
				ThumbnailLoader.LoadAsBase64(job.Video.ThumbnailPath, 192, 108)
			);
		}

		private string template =
			@"<html style=""padding: 0; margin:0;"">

<body style=""padding: 0; margin:0;"">
	<div
		style=""padding: 0; margin:0; width: calc(100% - 4rem); background: #FFC; margin: 0; padding: 2rem; left: 0; top: 0;"">
		<table>
			<tr>
				<td>
					<img src=""data:image/png;base64,{6}"" alt=""Thumbnail (falls vorhanden)""
						style=""width: 192px; height: 108px; margin: 0; margin-right: 2rem; padding: 0; align-self: center;"" />
				</td>
				<td>
					<h4>
						<p
							style="" align-self: center; overflow: hidden; text-overflow: ellipsis; word-break: break-all; max-height: 108px;"">
							{0}
						</p>
					</h4>
				</td>
			</tr>
		</table>
	</div>
	<div style=""padding: 1rem;"">
		<p>Hallo {1},</p>
		<p>Dein Video <strong>{0}</strong> wurde in die Warteschlange aufgenommen und ist damit zum Upload bereit.</p>
		<p>Sobald der Upload beginnt, wird es mit folgenden Einstellungen auf Youtube hochgeladen:</p>
		<table style=""width: 100%;"">
			<tr style=""background: #DDD;"">
				<td style=""margin-right: 0.5rem"">Titel</td>
				<td>{0}</td>
			</tr>
			<tr style=""background: #CCC;"">
				<td style=""margin-right: 0.5rem"">Sichtbarkeit</td>
				<td>{2}</td>
			</tr>
			<tr style=""background: #DDD;"">
				<td style=""margin-right: 0.5rem"">Ver&ouml;ffentlichung am</td>
				<td>{3}</td>
			</tr>
			<tr style=""background: #CCC;"">
				<td style=""margin-right: 0.5rem"">Beschreibung</td>
				<td>{4}</td>
			</tr>
			<tr style=""background: #DDD;"">
				<td style=""margin-right: 0.5rem"">Tags</td>
				<td>{5}</td>
			</tr>
		</table>
		<p style=""padding-top: 3rem;"">Vielen Dank, dass du mein Tool benutzt!</p>
		<p>strohi</p>
	</div>
</body>

</html>";
	}
}
