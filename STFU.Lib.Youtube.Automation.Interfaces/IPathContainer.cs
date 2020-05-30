using System.Collections.Generic;
using STFU.Lib.Youtube.Automation.Interfaces.Model;
using STFU.Lib.Youtube.Interfaces;

namespace STFU.Lib.Youtube.Automation.Interfaces
{
	public interface IPathContainer
	{
		IReadOnlyCollection<IPath> RegisteredPaths { get; }
		IReadOnlyCollection<IPath> ActivePaths { get; }

		void RegisterPath(IPath path);
		void ShiftPathPositions(IPath first, IPath second);
		void ShiftPathPositionsAt(int firstIndex, int secondIndex);
		void UnregisterAllPaths();
		void UnregisterPath(IPath path);
		void UnregisterPathAt(int index);

		void MarkAllFilesAsRead(IPath path, IYoutubeJobContainer queueContainer, IYoutubeJobContainer archiveContainer, IYoutubeAccountContainer accountContainer);
	}
}