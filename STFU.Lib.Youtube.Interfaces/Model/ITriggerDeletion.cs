using STFU.Lib.Youtube.Interfaces.Model.EventHandler;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface ITriggerDeletion
	{
		event TriggerDeletionEventHandler TriggerDeletion;
	}
}
