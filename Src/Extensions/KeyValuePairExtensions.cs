// --------------------------------------------------------------------------------
// <copyright file="KeyValuePairExtensions.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

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
