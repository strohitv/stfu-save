namespace STFU.Lib.Youtube.Interfaces.Model
{
	public interface IYoutubeError
	{
		/// <summary>
		/// http status number of the error
		/// </summary>
		int ErrorCode { get; }

		/// <summary>
		/// error message returned by youtube
		/// </summary>
		string Message { get; }

		/// <summary>
		/// complete json returned by youtube
		/// </summary>
		string Json { get; }
	}
}
