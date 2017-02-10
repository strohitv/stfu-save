using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrohisUploadLib.Playlists
{
	public class PlaylistResponse
	{
		public string kind { get; set; }
		public string etag { get; set; }
		public string prevPageToken { get; set; }
		public string nextPageToken { get; set; }
		public PageInfo pageInfo { get; set; }
		public PlaylistItem[] items { get; set; }
	}

	public class PageInfo
	{
		public int totalResults { get; set; }
		public int resultsPerPage { get; set; }
	}

	public class PlaylistItem
	{
		public string kind { get; set; }
		public string etag { get; set; }
		public string id { get; set; }
		public ContentDetails contentDetails { get; set; }
	}

	public class ContentDetails
	{
		public string videoId { get; set; }
		public string videoPublishedAt { get; set; }
	}
}
