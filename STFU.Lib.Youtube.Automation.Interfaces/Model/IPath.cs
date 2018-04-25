namespace STFU.Lib.Youtube.Automation.Interfaces.Model
{
	public interface IPath
	{
		string Filter { get; set; }
		string Fullname { get; set; }
		bool Inactive { get; set; }
		bool SearchHidden { get; set; }
		bool SearchRecursively { get; set; }
		int SelectedTemplateId { get; set; }

		int? GetDifference(string pathToCheck);
	}
}