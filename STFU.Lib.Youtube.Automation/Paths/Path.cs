﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation.Paths
{
	public class Path : IPath
	{
		private static ILog LOGGER { get; set; } = LogManager.GetLogger(nameof(Path));

		private bool searchRecursively;

		private bool searchHidden;

		public string Fullname { get; set; }

		public string Filter { get; set; }

		public bool Inactive { get; set; }

		public bool SearchRecursively
		{
			get
			{
				return searchRecursively;
			}
			set
			{
				searchRecursively = value;
				if (!SearchRecursively)
				{
					SearchHidden = false;
				}
			}
		}

		public bool SearchHidden
		{
			get
			{
				return searchHidden;
			}
			set
			{
				searchHidden = value;
				if (SearchHidden)
				{
					SearchRecursively = true;
				}
			}
		}

		public int SelectedTemplateId { get; set; }

		public bool MoveAfterUpload { get; set; } = false;

		public string MoveDirectoryPath { get; set; } = string.Empty;

		public FoundFilesOrderByFilter SearchOrder { get; set; } = FoundFilesOrderByFilter.NameAsc;

		public int? GetDifference(string pathToCheck)
		{
			LOGGER.Info($"Getting difference between '{Fullname}' and '{pathToCheck}'");

			int? result = null;

			DirectoryInfo directory = new DirectoryInfo(Fullname);
			FileInfo file = new FileInfo(pathToCheck);

			if (Matches(file, directory))
			{
				LOGGER.Info($"'{pathToCheck}' lies directly inside '{Fullname}' => distance is 0");

				result = 0;
			}
			else if (SearchRecursively)
			{
				DirectoryInfo current = file.Directory;

				if (Matches(file, current))
				{
					LOGGER.Info($"File lies in some subdirectory and resursive search is enabled => searching distance recursively");

					// Datei wird durch den Filter rekursiv gefunden.
					result = 0;

					while (System.IO.Path.GetFullPath(current.FullName).ToLower() != System.IO.Path.GetFullPath(directory.FullName).ToLower()
						&& current.Parent != null)
					{
						result++;
						current = current.Parent;
					}

					LOGGER.Info($"Final distance between '{Fullname}' and '{pathToCheck}': {result}");
				}
			}
			else
			{
				LOGGER.Info($"Path '{Fullname}' does not contain the file '{pathToCheck}'");
			}

			return result;
		}

		private bool Matches(FileInfo file, DirectoryInfo current)
		{
			var found = FilterDirs(current, file, Filter, SearchOption.TopDirectoryOnly);
			return found.Any(fd => fd.DirectoryName.ToLower() == file.DirectoryName.ToLower() && fd.Name.ToLower() == file.Name.ToLower());
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

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
