using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using STFU.Lib.Youtube.Automation.Interfaces;

namespace STFU.Lib.Youtube.Automation
{
	public class PathContainer
	{
		private IList<IPath> paths = new List<IPath>();

		private IList<IPath> Paths => paths;

		public IReadOnlyCollection<IPath> RegisteredPaths => new ReadOnlyCollection<IPath>(paths);

		private bool PathIsAlreadyRegistered(IPath path)
		{
			return RegisteredPaths.Any(p => SamePathUsed(path, p));
		}

		private static bool SamePathUsed(IPath path, IPath p)
		{
			return System.IO.Path.GetFullPath(path.Fullname).ToLower() == System.IO.Path.GetFullPath(p.Fullname).ToLower();
		}

		public void RegisterPath(IPath path)
		{
			if (!PathIsAlreadyRegistered(path))
			{
				Paths.Add(path);
			}
		}

		public void UnregisterPath(IPath path)
		{
			if (RegisteredPaths.Contains(path))
			{
				Paths.Remove(path);
			}
		}
	}
}
