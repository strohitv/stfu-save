using System;
using System.Linq;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;

namespace STFU.Lib.Updater
{
	public class VersionChecker
    {
		public bool CheckStfuVersion (string currentVersion)
		{
			var file = GetLatestStfuZipInfo();

			return file != null && NewVersionAvailable(file, currentVersion);
		}

		private bool NewVersionAvailable(File file, string currentVersion)
		{
			var newestVersionArray = file.Name.Split('-')[1].Replace("v", string.Empty).Split('.');
			var currentVersionArray = currentVersion.Replace("v", string.Empty).Split('.');

			bool isAvailable = false;
			for (int i = 0; i < newestVersionArray.Length; i++)
			{
				int oldV, newV;
				if (newestVersionArray.Length > i && currentVersionArray.Length > i
					&& int.TryParse(newestVersionArray[i], out newV) && int.TryParse(currentVersionArray[i], out oldV)
					&& newV > oldV)
				{
					isAvailable = true;
					break;
				}
			}

			return isAvailable;
		}

		private File GetLatestStfuZipInfo()
		{
			var service = new DriveService(new BaseClientService.Initializer
			{
				ApiKey = "AIzaSyBPC7Fex7tSTu-maq85WXx5TkzTKA_tnD4"
			});

			var request = service.Files.List();
			request.Q = "'1kCRPLg-95PjbQKjEpj-HW7tjvzmZ87RI' in parents";

			FileList result = null;
			try
			{
				result = request.Execute();
			}
			catch (Exception)
			{			}

			var file = result?.Files?.FirstOrDefault(f => f.MimeType == "application/x-zip-compressed");

			return file;
		}
    }
}
