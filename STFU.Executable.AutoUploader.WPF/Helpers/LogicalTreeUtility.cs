using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace STFU.Executable.AutoUploader.WPF.Helpers
{
    public static class LogicalTreeUtility
    {
        public static IEnumerable GetChildren(DependencyObject obj, bool allChildrenInHierachy)
        {
            if (!allChildrenInHierachy)
                return LogicalTreeHelper.GetChildren(obj);
            else
            {
                List<object> ReturnValues = new List<object>();
                RecursionReturnAllChildren(obj, ReturnValues);
                return ReturnValues;
            }
        }

        private static void RecursionReturnAllChildren(DependencyObject obj, IList<object> returnValues)
        {
            foreach (object curChild in LogicalTreeHelper.GetChildren(obj))
            {
                returnValues.Add(curChild);
                if (curChild is DependencyObject)
                    RecursionReturnAllChildren((DependencyObject)curChild, returnValues);
            }
        }

        public static IEnumerable<ReturnType> GetChildren<ReturnType>(DependencyObject obj, bool allChildrenInHierachy)
        {
            foreach (object child in GetChildren(obj, allChildrenInHierachy))
                if (child is ReturnType)
                    yield return (ReturnType)child;
        }
    }
}
