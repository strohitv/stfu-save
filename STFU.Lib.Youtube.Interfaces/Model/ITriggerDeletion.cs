using STFU.Lib.Youtube.Interfaces.Model.Handler;

namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface ITriggerDeletion
	{
		event TriggerDeletionEventHandler TriggerDeletion;
	}
}
