using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Internal.Templates;
using STFU.Lib.Youtube.Automation.Templates;
using STFU.Lib.Youtube.Interfaces;

namespace STFU.Lib.GUI.Forms
{
	public partial class AddVideosForm : Form
	{
		private IYoutubeCategoryContainer CategoryContainer { get; set; }
		private IYoutubeLanguageContainer LanguageContainer { get; set; }
		private string[] Paths { get; set; }
		private ITemplate[] Templates { get; set; }
		private IPath[] PathInfos { get; set; }

		public TemplateVideoCreator TemplateVideoCreator { get; private set; }
		public List<VideoInformation> Videos { get; } = new List<VideoInformation>();

		public AddVideosForm(ITemplate[] templates, IPath[] pathInfos, IYoutubeCategoryContainer categoryContainer, IYoutubeLanguageContainer languageContainer, params string[] paths)
		{
			InitializeComponent();
			editVideoInformationGrid.IsNewUpload = true;

			DialogResult = DialogResult.Cancel;

			Paths = paths;
			CategoryContainer = categoryContainer;
			LanguageContainer = languageContainer;
			Templates = templates;
			PathInfos = pathInfos;
		}

		private void AddVideosForm_Load(object sender, System.EventArgs e)
		{
			loadWorker.RunWorkerAsync();
		}

		private void RefillListView()
		{
			videosListView.Items.Clear();

			foreach (var video in Videos)
			{
				videosListView.Items.Add(video.Video.File.Name);
			}
		}

		private ITemplate FindTemplate(IPath path, ITemplate[] templates)
		{
			if (templates.Length == 0)
			{
				return null;
			}

			var template = templates.FirstOrDefault(t => t.Id == path.SelectedTemplateId);

			if (template != null)
			{
				return template;
			}

			return templates.FirstOrDefault(t => t.Id == 0);
		}

		private void videosListView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (videosListView.SelectedIndices.Count == 1)
			{
				editVideoInformationGrid.Fill(Videos[videosListView.SelectedIndices[0]].Video, CategoryContainer, LanguageContainer);
				editVideoInformationGrid.Enabled = true;
			}
			else
			{
				editVideoInformationGrid.Enabled = false;
			}
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void acceptButton_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			TemplateVideoCreator.SaveNextUploadSuggestions();
			Close();
		}

		private void loadWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			var publishTimeCalculators = PathInfos
				.Select(p => new ObservationConfiguration(p, FindTemplate(p, Templates)))
				.Select(pto => new PublishTimeCalculator(
					pto.PathInfo,
					pto.StartDate,
					pto.Template,
					pto.HasCustomStartDayIndex ? pto.CustomStartDayIndex : null))
				.ToList();

			TemplateVideoCreator = new TemplateVideoCreator(publishTimeCalculators);

			AddVideos(Paths);
		}

		private void AddVideos(string[] paths)
		{
			var videosWithPaths = paths.Select(p => new FileInfo(p))
				.Select(f => new KeyValuePair<FileInfo, IPath>(f, TemplateVideoCreator.FindNearestPath(f.FullName)))
				.ToArray();

			var sortedPaths = new Dictionary<IPath, List<FileInfo>>();

			foreach (var videoWithPath in videosWithPaths)
			{
				IPath path = videoWithPath.Value;
				if (sortedPaths.ContainsKey(path))
				{
					sortedPaths[path].Add(videoWithPath.Key);
				}
				else
				{
					sortedPaths.Add(path, new List<FileInfo>(new[] { videoWithPath.Key }));
				}
			}

			foreach (var key in sortedPaths.Keys)
			{
				var sorted = new List<FileInfo>();

				switch (key.SearchOrder)
				{
					case FoundFilesOrderByFilter.NameAsc:
						sorted = sortedPaths[key].OrderBy(fi => fi.Name).ToList();
						break;
					case FoundFilesOrderByFilter.NameDsc:
						sorted = sortedPaths[key].OrderByDescending(fi => fi.Name).ToList();
						break;
					case FoundFilesOrderByFilter.CreationDateAsc:
						sorted = sortedPaths[key].OrderBy(fi => fi.CreationTimeUtc).ToList();
						break;
					case FoundFilesOrderByFilter.CreationDateDsc:
						sorted = sortedPaths[key].OrderByDescending(fi => fi.CreationTimeUtc).ToList();
						break;
					case FoundFilesOrderByFilter.ChangedDateAsc:
						sorted = sortedPaths[key].OrderBy(fi => fi.LastWriteTimeUtc).ToList();
						break;
					case FoundFilesOrderByFilter.ChangedDateDsc:
						sorted = sortedPaths[key].OrderByDescending(fi => fi.LastWriteTimeUtc).ToList();
						break;
					case FoundFilesOrderByFilter.SizeAsc:
						sorted = sortedPaths[key].OrderBy(fi => fi.Length).ToList();
						break;
					case FoundFilesOrderByFilter.SizeDsc:
						sorted = sortedPaths[key].OrderByDescending(fi => fi.Length).ToList();
						break;
				}

				Videos.AddRange(sorted.Select(fi => TemplateVideoCreator.CreateVideo(fi.FullName, false)));
			}
		}

		private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			RefillListView();
			mainTlp.Enabled = true;
		}

		private void addVideosWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			AddVideos(Paths);
		}
	}
}
