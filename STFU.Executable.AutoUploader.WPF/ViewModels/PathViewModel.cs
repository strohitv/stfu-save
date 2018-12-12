using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class PathViewModel : ViewModelBase
    {
        public void DoAction(PathWindowAction action)
        {

        }
    }

    public enum PathWindowAction
    {
        Add,
        MoveUp,
        MoveDown,
        Delete,
        Clear
    }
}
