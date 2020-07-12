using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Automation.Internal.Templates;
using STFU.Lib.Youtube.Automation.Templates;
using STFU.Lib.Youtube.Interfaces;
using STFU.Lib.Youtube.Interfaces.Model;

namespace STFU.Lib.GUI.Forms
{
	public partial class AddVideosForm : Form
	{
		private IYoutubeCategoryContainer CategoryContainer { get; set; }
		private IYoutubeLanguageContainer LanguageContainer { get; set; }
		private IYoutubeAccount Account { get; set; }
		private string[] Paths { get; set; }
		private ITemplate[] Templates { get; set; }
		private IPath[] PathInfos { get; set; }

		public TemplateVideoCreator TemplateVideoCreator { get; private set; }
		public List<VideoInformation> Videos { get; } = new List<VideoInformation>();

		public AddVideosForm(ITemplate[] templates, IPath[] pathInfos, IYoutubeCategoryContainer categoryContainer, IYoutubeLanguageContainer languageContainer, IYoutubeAccount account)
		{
			InitializeComponent();
			editVideoInformationGrid.IsNewUpload = true;

			DialogResult = DialogResult.Cancel;

			CategoryContainer = categoryContainer;
			LanguageContainer = languageContainer;
			Account = account;
			Templates = templates;
			PathInfos = pathInfos;
		}

		private void AddVideosForm_Load(object sender, System.EventArgs e)
		{
			if (addVideosDialog.ShowDialog(this) == DialogResult.OK)
			{
				Paths = addVideosDialog.FileNames;
				loadWorker.RunWorkerAsync();
			}
			else
			{
				Close();
			}
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
			moveVideosUpButton.Enabled = moveVideosDownButton.Enabled = removeVideoButton.Enabled = insertTemplatesButton.Enabled = videosListView.SelectedIndices.Count > 0;

			if (videosListView.SelectedIndices.Count == 1)
			{
				editVideoInformationGrid.Fill(Videos[videosListView.SelectedIndices[0]].Video, Videos[videosListView.SelectedIndices[0]].NotificationSettings, Account.Access.First().HasSendMailPrivilegue, CategoryContainer, LanguageContainer);
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

				if (path == null)
				{
					path = new Youtube.Automation.Paths.Path()
					{
						Fullname = videoWithPath.Key.DirectoryName,
						SelectedTemplateId = 0
					};
				}

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
			var indices = new List<int>();
			if (videosListView.SelectedIndices.Count > 0)
			{
				foreach (int index in videosListView.SelectedIndices)
				{
					indices.Add(index);
				}
			}
			else
			{
				indices.Add(0);
			}

			RefillListView();

			if (videosListView.Items.Count > 0)
			{
				videosListView.SelectedIndices.Clear();
				foreach (var index in indices)
				{
					videosListView.SelectedIndices.Add(index);
				}
			}

			mainTlp.Enabled = true;
		}

		private void addVideosWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			AddVideos(Paths);
		}

		private void addVideosButton_Click(object sender, System.EventArgs e)
		{
			if (addVideosDialog.ShowDialog(this) == DialogResult.OK)
			{
				Paths = addVideosDialog.FileNames;
				loadWorker.RunWorkerAsync();
			}
		}

		private void moveVideosUpButton_Click(object sender, System.EventArgs e)
		{
			videosListView.BeginUpdate();

			for (int i = 0; i < videosListView.SelectedIndices.Count; i++)
			{
				int index = videosListView.SelectedIndices[i];

				if (index == 0)
				{
					continue;
				}

				if (i > 0 && videosListView.SelectedIndices[i - 1] == index - 1)
				{
					continue;
				}

				var save = Videos[index];
				Videos[index] = Videos[index - 1];
				Videos[index - 1] = save;

				var itemsSave = videosListView.Items[index];
				videosListView.Items.RemoveAt(index);
				videosListView.Items.Insert(index - 1, itemsSave);
			}

			videosListView.EndUpdate();
		}

		private void moveVideosDownButton_Click(object sender, System.EventArgs e)
		{
			videosListView.BeginUpdate();

			for (int i = videosListView.SelectedIndices.Count - 1; i >= 0; i--)
			{
				int index = videosListView.SelectedIndices[i];

				if (index == videosListView.Items.Count - 1)
				{
					continue;
				}

				if (i < videosListView.SelectedIndices.Count - 1 && videosListView.SelectedIndices[i + 1] == index + 1)
				{
					continue;
				}

				var save = Videos[index];
				Videos[index] = Videos[index + 1];
				Videos[index + 1] = save;

				var itemsSave = videosListView.Items[index];
				videosListView.Items.RemoveAt(index);
				videosListView.Items.Insert(index + 1, itemsSave);
			}

			videosListView.EndUpdate();
		}

		private void removeVideoButton_Click(object sender, System.EventArgs e)
		{
			videosListView.BeginUpdate();

			for (int i = videosListView.SelectedIndices.Count - 1; i >= 0; i--)
			{
				int index = videosListView.SelectedIndices[i];

				Videos.RemoveAt(index);
				videosListView.Items.RemoveAt(index);
			}

			videosListView.EndUpdate();
		}

		private void clearVideosButton_Click(object sender, System.EventArgs e)
		{
			Videos.Clear();
			videosListView.Items.Clear();
		}

		private void videosListView_Resize(object sender, System.EventArgs e)
		{
			videosListView.Columns[0].Width = videosListView.Width - 15;
		}

		private void insertTemplatesButton_Click(object sender, System.EventArgs e)
		{
			SelectTemplateDialog dialog = new SelectTemplateDialog();
			dialog.Templates = Templates;

			var result = dialog.ShowDialog(this);

			if (result == DialogResult.OK)
			{
				var template = dialog.SelectedTemplate;
				foreach (int index in videosListView.SelectedIndices)
				{
					Videos[index] = TemplateVideoCreator.CreateVideo(Videos[index].Video.Path, new PublishTimeCalculator(null, template));

					if (videosListView.SelectedIndices.Count == 1)
					{
						editVideoInformationGrid.Fill(Videos[videosListView.SelectedIndices[0]].Video, Videos[videosListView.SelectedIndices[0]].NotificationSettings, Account.Access.First().HasSendMailPrivilegue, CategoryContainer, LanguageContainer);
					}
				}
			}
		}
	}
}
