using System.Linq;
using System.Web;
using STFU.Lib.Common;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.MailSender.Generator
{
	public class UploadFailedMailGenerator : IMailGenerator
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
				ThumbnailLoader.LoadAsBase64(job.Video.ThumbnailPath, 192, 108)
			);
		}

		private string template =
			@"<html style=""padding: 0; margin:0;"">

<body style=""padding: 0; margin:0;"">
	<div
		style=""padding: 0; margin:0; width: calc(100% - 4rem); background: #FCC; margin: 0; padding: 2rem; left: 0; top: 0;"">
		<table>
			<tr>
				<td>
					<img src=""data:image/png;base64,{2}"" alt=""Thumbnail (falls vorhanden)""
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
		<p>Dein Video <strong>{0}</strong> konnte leider nicht erfolgreich hochgeladen werden...</p>
		<p>Der Upload wurde mit einem Fehler abgebrochen. Genauere Infos findest du im Unterordner ""errors"" in den Logdateien. Solltest du Hilfe ben&ouml;tigen, kannst du dich gerne an mich wenden.</p>
		<p style=""padding-top: 3rem;"">Vielen Dank, dass du mein Tool benutzt!</p>
		<p>strohi</p>
	</div>
</body>

</html>";
	}
}
