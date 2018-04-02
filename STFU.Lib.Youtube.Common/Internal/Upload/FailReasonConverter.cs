using System;

namespace STFU.Lib.Youtube.Common.Internal.Upload
{
	internal static class FailReasonConverter
	{
		internal static InternalYoutubeError GetError(FailureReason reason)
		{
			InternalYoutubeError error = null;

			switch (reason)
			{
				case FailureReason.None:
					break;
				case FailureReason.Unknown:
					error = new InternalYoutubeError("Unbekannter Fehler.");
					break;
				case FailureReason.FileTooBig:
					error = new InternalYoutubeError("Die Datei ist zu groß und kann daher nicht hochgeladen werden.");
					break;
				case FailureReason.FileDoesNotExist:
					error = new InternalYoutubeError("Die angegebene Datei konnte nicht gefunden werden.");
					break;
				case FailureReason.ReadError:
					error = new InternalYoutubeError("Es gab einen Fehler beim Lesen der Datei.");
					break;
				case FailureReason.SendError:
					error = new InternalYoutubeError("Es gab einen Fehler beim Senden der Datei.");
					break;
				default:
					throw new NotSupportedException("Das entsprechende Feld des Enums wird nicht unterstützt!");
			}

			return error;
		}
	}
}
