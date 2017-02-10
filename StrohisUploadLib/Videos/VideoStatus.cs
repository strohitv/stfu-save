using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrohisUploadLib.Videos
{
	public class VideoStatus
	{
		public bool publicStatsViewable { get; set; }
		public DateTime publishAt { get; set; }

		[JsonProperty(PropertyName = "nope")]
		public PrivacyValues privacyStatus { get; set; }

		[JsonProperty(PropertyName = "privacyStatus")]
		public string privacyValue { get { return privacyStatus; } }
		public bool embeddable { get; set; }

		[JsonProperty(PropertyName = "license")]
		public string licenceString { get { return licence; } }

		[JsonProperty(PropertyName = "dont")]
		public Licences licence { get; set; }

		//public PrivacyValues PrivacyValues = { "public", "unlisted", "private" };
		public bool ShouldPublishAt { get; set; }

		//public Licences Licences = { "youtube", "creativeCommon" };

		public bool ShouldSerializelicence()
		{ return false; }
		public bool ShouldSerializeShouldPublishAt()
		{ return false; }
		public bool ShouldSerializeprivacyStatus()
		{ return false; }
		public bool ShouldSerializepublishAt()
		{ return ShouldPublishAt; }
	}

	public sealed class PrivacyValues
	{
		private readonly string name;
		private static readonly Dictionary<string, PrivacyValues> allPrivacyValues = new Dictionary<string, PrivacyValues>();

		public static readonly PrivacyValues Public = new PrivacyValues("public");
		public static readonly PrivacyValues Unlisted = new PrivacyValues("unlisted");
		public static readonly PrivacyValues Private = new PrivacyValues("private");

		private PrivacyValues(string name)
		{
			this.name = name;
			allPrivacyValues[name] = this;
		}

		public override string ToString()
		{
			return name;
		}

		public static implicit operator PrivacyValues(string str)
		{
			str = str.ToLower();

			PrivacyValues result;
			if (allPrivacyValues.TryGetValue(str, out result))
				return result;
			else
				throw new InvalidCastException();
		}

		public static implicit operator string(PrivacyValues pv)
		{
			return pv.name;
		}
	}

	public sealed class Licences
	{
		private static readonly Dictionary<string, Licences> allLicences = new Dictionary<string, Licences>();

		private readonly string name;

		public static readonly Licences Youtube = new Licences("youtube");
		public static readonly Licences CC = new Licences("creativeCommon");

		private Licences(string name)
		{
			this.name = name;
			allLicences[name] = this;
		}

		public override string ToString()
		{
			return name;
		}

		public static implicit operator Licences(string str)
		{
			str = str.ToLower();

			Licences result;
			if (allLicences.TryGetValue(str, out result))
				return result;
			else
				throw new InvalidCastException();
		}

		public static implicit operator string(Licences licence)
		{
			return licence.name;
		}
	}
}
