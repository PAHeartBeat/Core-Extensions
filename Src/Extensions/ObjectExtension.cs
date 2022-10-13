// --------------------------------------------------------------------------------
// <copyright file="ObjectExtension.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

using System.Collections;

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Extension methods for object type data.
/// </summary>
public static class ObjectExtension {
	/// <summary>
	/// This method Will check object is null or not.
	/// </summary>
	/// <param name="obj">The Object which needs to be check for Null value.</param>
	/// <returns>true if object is null, otherwise false.</returns>
	public static bool IsNull(this object obj)
		=> obj is string str ? !str.HasValue() : obj == null;

	/// <summary>
	/// This method Will check object has value or not.
	/// </summary>
	/// <param name="obj">The instance or object which needs to check for not null value.</param>
	/// <returns>true if object is not null, otherwise false.</returns>
	public static bool IsNotNull(this object obj)
		=> !obj.IsNull();

	/// <summary>
	/// This method will check object type is primitive type like string, bool, int, long, etc...
	/// </summary>
	/// <param name="obj">The object or instance which needs to be check about it's primitive value or not?.</param>
	/// <returns>true if object type is primitive, otherwise false.</returns>
	public static bool IsPrimitiveType(this object obj) {
		return obj is string ||
			obj is bool ||
			obj.IsNumber();
	}

	/// <summary>
	/// This method will check for object type is any kind on number or not.
	/// </summary>
	/// <param name="obj">The object or instance which needs check where it's any kind of numeric data or not?.</param>
	/// <returns>return true if object is any kind of number, otherwise false.</returns>
	public static bool IsNumber(this object obj) {
		return obj is short or
			int or long or
			uint or ushort or uint or ulong or
			float or
			decimal or
			double;
	}

	/// <summary>
	/// This method will check is object is collection of KeyValePair like dictionary or HashTable.
	/// </summary>
	/// <param name="obj">The data or instance which need to check whether it's any kind of KVP like Hashtable, or Dictionary or not?.</param>
	/// <returns>true if matches otherwise false.</returns>
	public static bool IsKVPObject(this object obj)
		=> obj is Hashtable or IDictionary;

	/// <summary>
	/// This Extension method will check object type is match with a specific data type or not.
	/// </summary>
	/// <typeparam name="T">Data type to check <paramref name="obj"/> type is the same or not?.</typeparam>
	/// <param name="obj">The object or instance that need to check with particular type.</param>
	/// <returns>true if type match with <typeparamref name="T"/> otherwise false.</returns>
	public static bool IsA<T>(this object obj)
		=> obj is T;
}
