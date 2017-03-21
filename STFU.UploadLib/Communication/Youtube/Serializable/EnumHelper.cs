using System;
using System.Reflection;

namespace STFU.UploadLib.Communication.Youtube.Serializable
{
	public static class EnumHelper
	{
		public static T GetAttribute<T>(this Enum enumValue)
			where T : Attribute
		{
			return enumValue
				.GetType()
				.GetTypeInfo()
				.GetDeclaredField(enumValue.ToString())
				.GetCustomAttribute<T>();
		}
	}
}
