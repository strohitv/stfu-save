using System;

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
					error = new YoutubeError("Unbekannter Fehler.");
					break;
				case FailureReason.FileTooBig:
					error = new YoutubeError("Die Datei ist zu groß und kann daher nicht hochgeladen werden.");
					break;
				case FailureReason.FileDoesNotExist:
					error = new YoutubeError("Die angegebene Datei konnte nicht gefunden werden.");
					break;
				case FailureReason.ReadError:
					error = new YoutubeError("Es gab einen Fehler beim Lesen der Datei.");
					break;
				case FailureReason.SendError:
					error = new YoutubeError("Es gab einen Fehler beim Senden der Datei.");
					break;
				default:
					throw new NotSupportedException("Das entsprechende Feld des Enums wird nicht unterstützt!");
			}

			return error;
		}
	}
}
