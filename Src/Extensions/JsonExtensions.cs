// --------------------------------------------------------------------------------
// <copyright file="JsonExtensions.cs" company="N/A">
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

using System;
using System.Collections;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Extension class to work with json in Unity. this will use Unity Json Utility and MiniJson from Calvin Rain.
/// </summary>
public static class JsonExtensions {
	/// <summary>
	/// Gets readonly Newton soft Json Serializer settings. To Update setting please use <see cref="SetSerializerSettings(JsonSerializerSettings)"/>.
	/// </summary>
	public static JsonSerializerSettings Settings { get; private set; } = new JsonSerializerSettings();

	/// <summary>
	/// Gets readonly Json Serializer formatting option.
	/// </summary>
	public static Formatting FormattingOption { get; private set; } = Formatting.None;

	/// <summary>
	/// Will update Newton Soft Json Serializer Setting to serialize and deserialize JSon data.
	/// <br/> NOTE: Please use same setting or default setting in whole game to avoid any kind of mismatch.
	/// </summary>
	/// <param name="settings">The Serialization setting option to set for NewtonSoft Json.</param>
	public static void SetSerializerSettings(JsonSerializerSettings settings) {
		if (settings.IsNull()) {
			throw new ArgumentNullException(nameof(settings));
		}

		Settings = settings;
	}

	/// <summary>
	/// Will Serialized object as JSon string using Unity Json Utility with pretty format.
	/// </summary>
	/// <param name="obj">object to serialized.</param>
	/// <returns>serialized JSon string.</returns>
	public static string ToJson(this object obj)
		=> obj.ToJson(FormattingOption);

	/// <summary>
	/// Will Serialized object as JSon string using Unity Json Utility with pretty format.
	/// </summary>
	/// <param name="obj">object to serialized.</param>
	/// <param name="formatting">Serializer formatting option like convert Object to JSON string with indentation or without indent like minified JSON string.</param>
	/// <returns>serialized JSon string.</returns>
	public static string ToJson(this object obj, Formatting formatting)
		=> JsonConvert.SerializeObject(obj, formatting);

	/// <summary>
	/// will Deserialize json string to Dictionary.
	/// </summary>
	/// <typeparam name="T">Managed Type to which Json data needs to convert.</typeparam>
	/// <param name="jsonData">string to deserialize.</param>
	/// <returns>Dict data from serialized json string.</returns>
	public static T FromJson<T>(this string jsonData)
		=> JsonConvert.DeserializeObject<T>(jsonData);

	/// <summary>
	/// The helper method to Convert Object from one type to another type using json serialization.
	/// </summary>
	/// <typeparam name="T">Managed Type to which Input data needs to convert.</typeparam>
	/// <param name="obj">The object which needs to Convert.</param>
	/// <returns>instance of <typeparamref name="T"/> with data in it.</returns>
	/// <exception cref="InvalidCastException">This method will throw exception if input object is primitive data type like <see cref="string"/>, <see cref="int"/>. etc...</exception>
	public static T ConvertTo<T>(this object obj) {
		var rs = obj switch {
			JObject njObj => njObj.ToString(),
			IDictionary dict => dict.ToJson(),
			_ => obj.IsPrimitiveType()
				? throw new InvalidCastException("Primitive data type can't converted to Json.")
				: obj.ToJson(),
		};

		return JsonConvert.DeserializeObject<T>(rs);
	}
}
