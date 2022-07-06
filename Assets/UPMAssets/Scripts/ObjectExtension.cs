using System;
using System.Collections;

namespace iPAHeartBeat.Core.Extensions {
	/// <summary>
	/// Extension methods for object type data
	/// </summary>
	public static class ObjectExtension {

		/// <summary>
		/// This method Will check object is null or not.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>true if object is null, otherwise false</returns>
		public static bool IsNull(this object obj)
			=> obj is string str ?
				!str.HasValue()
				: obj == null;

		/// <summary>
		/// This method Will check object has value or not.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>true if object is not null, otherwise false</returns>
		public static bool IsNotNull(this object obj)
			=> !obj.IsNull();

		/// <summary>
		/// This method will check object type is primitive type like string, bool, int, long, etc...
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>true if object type is primitive, otherwise false</returns>
		public static bool IsPrimitiveType(this object obj) {
			return obj is string ||
				obj is bool ||
				obj.IsNumber();
		}

		/// <summary>
		/// This method will check for object type is any kind on number or not.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>return true if object is any kind of number, otherwise false</returns>
		public static bool IsNumber(this object obj) {
			return obj is short ||
				obj is int || obj is long ||
				obj is uint || obj is ushort || obj is uint || obj is ulong ||
				obj is float ||
				obj is decimal ||
				obj is double;
		}

		/// <summary>
		/// This method will check is object is collection of KeyValePair like dictionary or HashTable
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>true if matches otherwise false</returns>
		public static bool IsKVPObject(this object obj)
			=> obj is Hashtable || obj is IDictionary;

		/// <summary>
		/// This Extension method will check object type is match with a specific data type or not
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static bool IsA<T>(this object obj)
			=> obj is T;
	}
}
