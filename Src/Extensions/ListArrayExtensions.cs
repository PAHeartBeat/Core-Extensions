// --------------------------------------------------------------------------------
// <copyright file="ListArrayExtensions.cs" company="N/A">
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
using System.Collections.Generic;

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Extension utilities to work with List and Array.
/// </summary>
public static class ListArrayExtensions {
	/// <summary>
	/// Will push a item to the top of the list.
	/// </summary>
	/// <typeparam name="T">Type of the data which are being pushed in to typed list.</typeparam>
	/// <param name="list">List in which item should be added.</param>
	/// <param name="item">item object which should be added at top in the list.</param>
	public static void Push<T>(this List<T> list, T item) {
		if (list.IsNull()) {
			list = new List<T>();
		}

		list.Insert(0, item);
	}

	/// <summary>
	/// Will take first item form the list and than remove it from list.
	/// </summary>
	/// <typeparam name="T">Type of the data which being pulled from the.</typeparam>
	/// <param name="list">List object from which need to pull first item.</param>
	/// <returns>return the first item of the list.</returns>
	public static T Pull<T>(this List<T> list) {
		if (list.IsNull()) {
			throw new ArgumentNullException(nameof(list), "List object is null can not be pull item from null Object.");
		}

		if (list.Count <= 0) {
			throw new ArgumentOutOfRangeException(nameof(list), "List does not have any element. Can not pull any item from it.");
		}

		var pulledItem = list[0];
		list.RemoveAt(0);
		list.TrimExcess();
		return pulledItem;
	}

	/// <summary>
	/// Will copy a list to a new/another list to avoid address reference where two different list variable will referencing a same list from memory.
	/// </summary>
	/// <typeparam name="T">Type of the List items.</typeparam>
	/// <param name="target">Target list where data will be copied from source List.</param>
	/// <param name="source">Source list from where data will be copied.</param>
	/// <returns>New Copy of the list which reference to diffident memory address.</returns>
	public static List<T> Copy<T>(this List<T> target, List<T> source) {
		if (source.IsNull()) {
			return target;
		}

		if (target.IsNull()) {
			target = new List<T>();
		} else {
			target.Clear();
			target.TrimExcess();
		}

		foreach (var item in source) {
			if (item.IsNull()) {
				continue;
			}

			target.Add(item);
		}

		return target;
	}

	/// <summary>
	/// Will merge a list to a new/another list to avoid duplicate code.
	/// </summary>
	/// <typeparam name="T">Type of the List items.</typeparam>
	/// <param name="target">Target list where data will be merged from source List.</param>
	/// <param name="source">Source list from where data will be merged.</param>
	/// <returns>updated target list which contain items from both of the list.</returns>
	public static List<T> Merge<T>(this List<T> target, List<T> source) {
		if (target.IsNull()) {
			target = new List<T>();
		}

		if (source.IsNull()) {
			return target;
		}

		string dJson;
		for (var x = 0; x < source.Count; x++) {
			dJson = source[x].ToJson();
			var y = target.FindIndex(o => o.ToJson() == dJson);
			if (y < 0) {
				target.Add(source[x]);
			}
		}

		return target;
	}
}
