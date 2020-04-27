using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;
using STFU.Lib.Youtube.Upload;

namespace STFU.Lib.Youtube.Persistor
{
	public class JobPersistor
	{
		public string Path { get; private set; } = null;
		public IYoutubeJobContainer Container { get; private set; } = null;
		public IYoutubeJobContainer Saved { get; private set; } = null;

		public JobPersistor(IYoutubeJobContainer container, string path)
		{
			Path = path;
			Container = container;
		}

		public bool Load()
		{
			Container.UnregisterAllJobs();

			bool worked = true;

			try
			{
				if (File.Exists(Path))
				{
					using (StreamReader reader = new StreamReader(Path))
					{
						var json = reader.ReadToEnd();

						var jobs = JsonConvert.DeserializeObject<YoutubeJob[]>(json);

						foreach (var loaded in jobs)
						{
							Container.RegisterJob(loaded);
						}
					}
				}

				RecreateSaved();
			}
			catch (Exception e)
			when (e is UnauthorizedAccessException
			|| e is ArgumentException
			|| e is ArgumentNullException
			|| e is DirectoryNotFoundException
			|| e is PathTooLongException
			|| e is IOException)
			{
				worked = false;
			}

			return worked;
		}

		public bool Save()
		{
			IYoutubeJob[] jobs = Container.RegisteredJobs.ToArray();

			var json = JsonConvert.SerializeObject(jobs);

			var worked = true;
			try
			{
				using (StreamWriter writer = new StreamWriter(Path, false))
				{
					writer.Write(json);
				}

				RecreateSaved();
			}
			catch (Exception e)
			when (e is UnauthorizedAccessException
			|| e is ArgumentException
			|| e is ArgumentNullException
			|| e is DirectoryNotFoundException
			|| e is PathTooLongException
			|| e is IOException)
			{
				worked = false;
			}

			return worked;
		}

		private void RecreateSaved()
		{
			Saved = new YoutubeJobContainer();
			foreach (var job in Container.RegisteredJobs)
			{
				var newJob = new YoutubeJob(job.Video.CreateCopy(), job.Account, job.UploadStatus)
				{
					State = job.State
				};

				Saved.RegisterJob(newJob);
			}
		}
	}
}
