using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace STFU.Lib.Youtube.Automation
{
	public class PathContainer
	{
		private IList<Path> paths = new List<Path>();

		private IList<Path> Paths => paths;

		public IReadOnlyCollection<Path> RegisteredPaths => new ReadOnlyCollection<Path>(paths);

		private bool PathIsAlreadyRegistered(Path path)
		{
			return RegisteredPaths.Any(p => SamePathUsed(path, p));
		}

		private static bool SamePathUsed(Path path, Path p)
		{
			return System.IO.Path.GetFullPath(path.Fullname).ToLower() == System.IO.Path.GetFullPath(p.Fullname).ToLower();
		}

		public void RegisterPath(Path path)
		{
			if (!PathIsAlreadyRegistered(path))
			{
				Paths.Add(path);
			}
		}

		public void UnregisterPath(Path path)
		{
			if (RegisteredPaths.Contains(path))
			{
				Paths.Remove(path);
			}
		}
	}
}
