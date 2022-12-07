// --------------------------------------------------------------------------------
// <copyright file="ObjectExtension.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

/*
Author:			Ankur Ranpariya {iPAHeartBeat}
EMail:			ankur30884@gmail.com
Copyright:		(c) 2017, Ankur Ranpariya {iPAHeartBeat}
Social:			@iPAHeartBeat,
GitHubL			https://www.github.com/PAHeartBeat

Original Source:	N/A
Last Modified: 	Ankur Ranpariya
Contributed By:	N/A

All rights reserved.
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the
following conditions are met:

* Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
* Neither the name of the [ORGANIZATION] nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.


The above copyright notice and this permission notice shall be included in all copies or substantial portions of the
Software.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
documentation files (the "Software"), to deal in the Software without restriction, including without limitation the
rights to use, copy, modify, merge, publish, distribute, sub license, and/or sell copies of the Software, and to permit
persons to whom the Software is furnished to do so, subject to the following conditions:

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE
*/

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
