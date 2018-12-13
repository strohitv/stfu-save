using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Executable.AutoUploader.WPF.Helpers
{
    public static class CollectionExtension
    {
        public static void Swap<T>(this Collection<T> collection, int index1, int index2)
        {
            if (index1 >= 0 && index2 >= 0 && index1 < collection.Count && index2 < collection.Count)
            {
                var save = collection[index1];
                collection[index1] = collection[index2];
                collection[index2] = save;
            }
        }
    }
}
