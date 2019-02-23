using System;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.Youtube.Internal.Upload
{
	internal static class FailReasonConverter
	{
		internal static YoutubeError GetError(FailureReason reason)
		{
			YoutubeError error = null;

			switch (reason)
			{
				case FailureReason.None:
					break;
				case FailureReason.Unknown:
					error = new YoutubeError(reason, "Unbekannter Fehler.");
					break;
				case FailureReason.FileTooBig:
					error = new YoutubeError(reason, "Die Datei ist zu groß und kann daher nicht hochgeladen werden.");
					break;
				case FailureReason.FileDoesNotExist:
					error = new YoutubeError(reason, "Die angegebene Datei konnte nicht gefunden werden.");
					break;
				case FailureReason.ReadError:
					error = new YoutubeError(reason, "Es gab einen Fehler beim Lesen der Datei.");
					break;
				case FailureReason.SendError:
					error = new YoutubeError(reason, "Es gab einen Fehler beim Senden der Datei.");
					break;
				case FailureReason.UserUploadLimitExceeded:
					error = new YoutubeError(reason, "In der letzten Stunde wurden zu viele Videos auf diesen Account hochgeladen. Youtube wird einige Zeit lang keine weiteren Videos für diesen Account mehr akzeptieren.");
					break;
				default:
					throw new NotSupportedException("Das entsprechende Feld des Enums wird nicht unterstützt!");
			}

			return error;
		}
	}
}
