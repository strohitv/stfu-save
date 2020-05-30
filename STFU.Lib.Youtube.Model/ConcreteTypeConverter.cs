using System;
using Newtonsoft.Json;

namespace STFU.Lib.Youtube.Model
{
	public class ConcreteTypeConverter<TConcrete> : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return true;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			//explicitly specify the concrete type we want to create
			return serializer.Deserialize<TConcrete>(reader);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			//use the default serialization - it works fine
			serializer.Serialize(writer, value);
		}
	}
}
