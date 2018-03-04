using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STFU.AutoUploader
{
	public partial class ProcessForm : Form
	{
		public IReadOnlyCollection<Process> Selected { get { return selectedProcesses; } }

		private List<Process> selectedProcesses = new List<Process>();
		private Process[] AllProcesses { get; set; }
		private bool reactToCheckedEvents = true;


		public ProcessForm(IReadOnlyCollection<Process> selected)
		{
			InitializeComponent();

			selectedProcesses = selected.ToList();
		}

		private void ProcessWindowLoad(object sender, EventArgs e)
		{
			RefreshAllProcsAsync();
		}

		List<string> titles = new List<string>();

		private async void RefreshAllProcsAsync()
		{
			reactToCheckedEvents = false;
			lvProcs.BeginUpdate();

			lvProcs.Items.Clear();

			List<ListViewItem> items = new List<ListViewItem>();

			await Task.Run(() =>
			{
				var currentSessionID = Process.GetCurrentProcess().SessionId;
				
				AllProcesses = Process.GetProcesses()
					.OrderBy(item => item.ProcessName)
					.Where(p => HasAccess(p) && p.SessionId == currentSessionID && p.Id != Process.GetCurrentProcess().Id)
					.ToArray();

				foreach (var item in AllProcesses)
				{
					ListViewItem newItem = new ListViewItem(string.Empty);
					newItem.SubItems.Add(item.ProcessName);

					if (selectedProcesses.Any(proc => item.Id == proc.Id))
					{
						newItem.Checked = true;
					}

					try
					{
						newItem.SubItems.Add(item.MainModule.FileVersionInfo.FileDescription);
					}
					catch (Exception)
					{ }

					items.Add(newItem);
				}
			});

			lvProcs.Items.AddRange(items.ToArray());

			lvProcs.Columns[0].Width = -1;
			lvProcs.Columns[1].Width = -1;
			lvProcs.Columns[2].Width = -2;

			lvProcs.EndUpdate();
			reactToCheckedEvents = true;
		}

		private bool HasAccess(Process p)
		{
			var result = false;

			try
			{
				// let it go true only if the process is accessable
				result = p.HasExited || true;
			}
			catch (Win32Exception)
			{ }

			return result;
		}

		private void btnRefreshClick(object sender, EventArgs e)
		{
			RefreshAllProcsAsync();
		}

		private void lvProcsItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (!reactToCheckedEvents)
			{
				return;
			}

			Process item = AllProcesses[e.Item.Index];

			if (selectedProcesses.Any(proc => proc.Id == item.Id))
			{
				selectedProcesses.RemoveAll(proc => proc.Id == item.Id);
				//selectedProcesses.Remove(item);
			}
			else
			{
				selectedProcesses.Add(item);
			}
		}

		private void btnSubmitClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		//protected void FindWindowTitles(Process p)
		//{
		//	// traverse all threads and enum all windows attached to the thread
		//	foreach (ProcessThread t in p.Threads)
		//	{
		//		int threadId = t.Id;

		//		NativeWIN32.EnumThreadProc callbackProc = new NativeWIN32.EnumThreadProc(LoadWindowTitle);
		//		NativeWIN32.EnumThreadWindows(threadId, callbackProc, IntPtr.Zero);
		//	}
		//}

		//// callback used to enumerate Windows attached to one of the threads
		//bool LoadWindowTitle(IntPtr hwnd, IntPtr lParam)
		//{
		//	// get window caption
		//	NativeWIN32.STRINGBUFFER sLimitedLengthWindowTitle;
		//	NativeWIN32.GetWindowText(hwnd, out sLimitedLengthWindowTitle, 256);

		//	string sWindowTitle = sLimitedLengthWindowTitle.szText;
		//	if (sWindowTitle.Length == 0) return true;

		//	titles.Add(sWindowTitle);
		//	lvWindowTitles.Items.Add(sWindowTitle);

		//	return true;
		//}
	}

	//public class NativeWIN32
	//{
	//	public delegate bool EnumThreadProc(IntPtr hwnd, IntPtr lParam);

	//	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	//	public static extern bool EnumThreadWindows(int threadId, EnumThreadProc pfnEnum, IntPtr lParam);

	//	// used for an output LPCTSTR parameter on a method call
	//	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	//	public struct STRINGBUFFER
	//	{
	//		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	//		public string szText;
	//	}

	//	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	//	public static extern int GetWindowText(IntPtr hWnd, out STRINGBUFFER ClassName, int nMaxCount);
	//}
}




