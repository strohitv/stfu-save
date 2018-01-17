using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace STFU.UploadLib.Automation
{
	public class PathInformation
	{
		public string Path { get; set; }
		public string Filter { get; set; }
		public bool SearchRecursively { get; set; }
		public string SelectedTemplate { get; set; }

		public int? GetDifference(string pathToCheck)
		{
			int? result = null;

			DirectoryInfo directory = new DirectoryInfo(Path);
			FileInfo file = new FileInfo(pathToCheck);

			if (FilterDirs(directory, file, Filter, SearchOption.TopDirectoryOnly).Any(fd => fd.DirectoryName.ToLower() == file.DirectoryName.ToLower() && fd.Name.ToLower() == file.Name.ToLower()))
			{
				result = 0;
			}
			else if (SearchRecursively && FilterDirs(directory, file, Filter, SearchOption.AllDirectories).Any(fd => fd.DirectoryName.ToLower() == file.DirectoryName.ToLower() && fd.Name.ToLower() == file.Name.ToLower()))
			{
				result = 0;
				DirectoryInfo current = file.Directory;

				while (current != directory && current.Parent != null)
				{
					result++;
					current = current.Parent;
				}
			}

			return result;
		}

		private FileInfo[] FilterDirs(DirectoryInfo info, FileInfo file, string filter, SearchOption option)
		{
			string[] filters = filter.Split(';');
			List<FileInfo> results = new List<FileInfo>();

			foreach (var fil in filters)
			{
				results.AddRange(info.GetFiles(fil, option));
			}

			return results.ToArray();
		}
	}
}
