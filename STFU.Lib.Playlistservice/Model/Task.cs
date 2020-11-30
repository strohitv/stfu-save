using System;

namespace STFU.Lib.Playlistservice.Model
{
	public class Task
	{
		public long id { get; set; }
		public string videoId { get; set; }
		public string playlistId { get; set; }
		public string videoTitle { get; set; }
		public string playlistTitle { get; set; }
		public DateTime addAt { get; set; }
		public TaskState state { get; set; }
		public int attemptCount { get; set; }
	}
}
