// --------------------------------------------------------------------------------
// <copyright file="ListArrayExtensions.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

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
