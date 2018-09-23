using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using STFU.Lib.Youtube.Automation.Interfaces;
using STFU.Lib.Youtube.Automation.Interfaces.Model;

namespace STFU.Lib.Youtube.Automation
{
	public class PathContainer : IPathContainer
	{
		public PathContainer() { }

		private IList<IPath> Paths { get; } = new List<IPath>();

		public IReadOnlyCollection<IPath> RegisteredPaths => new ReadOnlyCollection<IPath>(Paths);
		public IReadOnlyCollection<IPath> ActivePaths => new ReadOnlyCollection<IPath>(Paths.Where(p => !p.Inactive).ToList());

		private bool PathIsAlreadyRegistered(IPath path)
		{
			return RegisteredPaths.Any(p => SamePathUsed(path, p));
		}

		private static bool SamePathUsed(IPath path, IPath p)
		{
			return Path.GetFullPath(path.Fullname).ToLower() == Path.GetFullPath(p.Fullname).ToLower();
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
		public void UnregisterPathAt(int index)
		{
			if (RegisteredPaths.Count > index)
			{
				Paths.RemoveAt(index);
			}
		}

		public void UnregisterAllPaths()
		{
			Paths.Clear();
		}

		public void ShiftPathPositions(IPath first, IPath second)
		{
			IPath firstToChange = null;
			IPath secondToChange = null;
			if (first != null
				&& second != null
				&& (firstToChange = Paths.FirstOrDefault(p => p == first)) != null
				&& (secondToChange = Paths.FirstOrDefault(p => p == second)) != null)
			{
				ShiftPathPositionsAt(Paths.IndexOf(firstToChange), Paths.IndexOf(secondToChange));
			}
		}

		public void ShiftPathPositionsAt(int firstIndex, int secondIndex)
		{
			if (firstIndex >= 0 && secondIndex >= 0 && firstIndex < Paths.Count && secondIndex < Paths.Count)
			{
				var save = Paths[firstIndex];
				Paths[firstIndex] = Paths[secondIndex];
				Paths[secondIndex] = save;
			}
		}
	}
}
