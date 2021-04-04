using Newtonsoft.Json;

namespace STFU.Lib.Playlistservice.Model
{
	public class Account
	{
		public long id { get; set; }
		public string title { get; set; }
		public string channelId { get; set; }

		public override string ToString()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
