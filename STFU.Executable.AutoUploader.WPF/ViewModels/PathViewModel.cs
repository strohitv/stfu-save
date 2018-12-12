using STFU.Lib.Youtube.Automation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STFU.Executable.AutoUploader.WPF.ViewModels
{
    public class PathViewModel : ViewModelBase
    {
        public IPathContainer PathContainer { get; set; }

        public ITemplateContainer TemplateContainer { get; set; }

        public ButtonCommand ChoosePathCommand { get; set; }

        public ButtonCommand SaveCommand { get; set; }

        public ButtonCommand MarkAllVideosCommand { get; set; }

        public ButtonCommand CancelCommand { get; set; }

        public ButtonCommand<PathWindowAction> ToolCommand { get; set; }

        public PathViewModel()
        {
            ChoosePathCommand = new ButtonCommand(ChoosePath);
            SaveCommand = new ButtonCommand(Save);
            MarkAllVideosCommand = new ButtonCommand(MarkAllVideos);
            CancelCommand = new ButtonCommand(Cancel);
            ToolCommand = new ButtonCommand<PathWindowAction>(DoAction);
        }

        public void DoAction(PathWindowAction action)
        {

        }

        private void ChoosePath()
        {

        }

        private void MarkAllVideos()
        {

        }

        private void Save()
        {

        }

        private void Cancel()
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
