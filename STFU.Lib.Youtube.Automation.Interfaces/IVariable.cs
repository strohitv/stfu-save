namespace STFU.Lib.Youtube.Automation.Interfaces
{
	public interface IVariable
	{
		string Content { get; set; }
		string Name { get; set; }

		string ToString();
	}
}