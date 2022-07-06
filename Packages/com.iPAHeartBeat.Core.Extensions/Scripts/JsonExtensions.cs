using System;
using System.Collections;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iPAHeartBeat.Core.Extensions {
	/// <summary>
	/// Extension class to work with json in Unity. this will use Unity Json Utility and MiniJson from Calvin Rain.
	/// </summary>
	public static class JsonExtensions {
		/// <summary>
		/// Readonly Newton soft Json Serializer settings. To Update setting please use <see cref="SetSerializerSettings(JsonSerializerSettings)"/>
		/// </summary>
		public static JsonSerializerSettings Settings { get; private set; } = new JsonSerializerSettings();
		/// <summary>
		/// Readonly Json Serializer formattin option
		/// </summary>
		public static Formatting FormattingOption { get; private set; } = Formatting.None;

		/// <summary>
		/// Will update Newton Soft Json Serializer Setting to serialize and deserialize JSon data.
		/// <br/> NOTE: Please use same setting or default setting in whole game to avoid any kind of missmatch.
		/// </summary>
		/// <param name="settings"></param>
		public static void SetSerializerSettings(JsonSerializerSettings settings) {
			if (settings.IsNull()) throw new ArgumentNullException(nameof(settings));
			Settings = settings;
		}

		/// <summary>
		/// Will Serialized object as JSon string using Unity Json Utility with pretty format
		/// </summary>
		/// <param name="obj">object to serialized </param>
		/// <returns>serialized JSon string</returns>
		public static string ToJson(this object obj)
			=> obj.ToJson(FormattingOption);

		/// <summary>
		/// Will Serialized object as JSon string using Unity Json Utility with pretty format
		/// </summary>
		/// <param name="obj">object to serialized </param>
		/// <param name="formatting">Serializer formting option like convert Object to JSON string with indentation or without indent like minified JSON string</param>
		/// <returns>serialized JSon string</returns>
		public static string ToJson(this object obj, Formatting formatting)
			=> JsonConvert.SerializeObject(obj, formatting);// return Json.Serialize(obj);

		/// <summary>
		/// will Deserialize json string to Dictionary.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="jsonData">string to deserialize</param>
		/// <returns>Dict data from serialized json string</returns>
		public static T FromJson<T>(this string jsonData)
			=> JsonConvert.DeserializeObject<T>(jsonData);

		public static T ConvertTo<T>(this object obj) {
			var rs = obj switch {
				JObject njObj => njObj.ToString(),
				IDictionary dict => dict.ToJson(),
				_ => obj.IsPrimitiveType()
					? throw new InvalidCastException("Premitive data type can't converted to Json.")
					: obj.ToJson(),
			};
			return JsonConvert.DeserializeObject<T>(rs);
		}
	}
}
