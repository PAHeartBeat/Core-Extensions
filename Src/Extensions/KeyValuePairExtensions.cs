// --------------------------------------------------------------------------------
// <copyright file="KeyValuePairExtensions.cs" company="N/A">
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

using System.Collections.Generic;

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Common Operation form Key-value pair object like Dictionary or IDictionary.
/// </summary>
public static class KeyValuePairExtensions {
	/// <summary>
	/// Will merge a dictatory to another one.
	/// </summary>
	/// <typeparam name="TKey">Type of the Key in Dictionary.</typeparam>
	/// <typeparam name="TValue">Type of the value in Dictionary.</typeparam>
	/// <param name="target">Target dictionary in which data from source dictionary will be merged.</param>
	/// <param name="source">Source dictionary of which data should be merged with target one.</param>
	/// <returns>Updated Dictionary.</returns>
	public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> target, Dictionary<TKey, TValue> source)
		=> target.Merge(source, false);

	/// <summary>
	/// Will merge a dictatory to another one.
	/// </summary>
	/// <typeparam name="TKey">Type of the Key in Dictionary.</typeparam>
	/// <typeparam name="TValue">Type of the value in Dictionary.</typeparam>
	/// <param name="target">Target dictionary in which data from source dictionary will be merged.</param>
	/// <param name="source">Source dictionary of which data should be merged with target one.</param>
	/// <param name="removeIsSourceHasNotValue">Should remove data from source dictionary which are not in other dictionary.</param>
	/// <returns>Updated Dictionary.</returns>
	public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> target, Dictionary<TKey, TValue> source, bool removeIsSourceHasNotValue) {
		if (target.IsNull()) {
			target = new Dictionary<TKey, TValue>();
		}

		if (source.IsNull()) {
			return target;
		}

		if (removeIsSourceHasNotValue) {
			_ = target.Copy(source);
			return target;
		}

		foreach (var key in source.Keys) {
			target[key] = source[key];
		}

		return target;
	}

	/// <summary>
	/// Will to Value copy to avoid reference link with two dictionary.
	/// </summary>
	/// <typeparam name="TKey">Type of the Key in Dictionary.</typeparam>
	/// <typeparam name="TValue">Type of the value in Dictionary.</typeparam>
	/// <param name="target">Target dictionary in which data from source dictionary will be copied.</param>
	/// <param name="source">Source dictionary of which data should be copied.</param>
	/// <returns>Updated Dictionary.</returns>
	public static Dictionary<TKey, TValue> Copy<TKey, TValue>(this Dictionary<TKey, TValue> target, Dictionary<TKey, TValue> source) {
		if (target.IsNull()) {
			target = new Dictionary<TKey, TValue>();
		} else {
			target.Clear();
		}

		if (source.IsNull()) {
			return target;
		}

		foreach (var key in source.Keys) {
			target[key] = source[key];
		}

		return target;
	}
}
