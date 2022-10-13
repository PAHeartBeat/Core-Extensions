// --------------------------------------------------------------------------------
// <copyright file="StringExtension.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Extension methods for string type data.
/// </summary>
public static class StringExtension {
	/// <summary>
	/// This method will check is string is empty or null.
	/// </summary>
	/// <param name="checkString">The string which needs to be check for Null or Empty value.</param>
	/// <returns>true if string empty or null otherwise false.</returns>
	public static bool IsNullOrEmpty(this string checkString)
		=> string.IsNullOrEmpty(checkString) || string.IsNullOrWhiteSpace(checkString) || checkString == string.Empty;

	/// <summary>
	/// Check is has any-kind of data.
	/// </summary>
	/// <param name="checkString">The string which needs to be check for has any value or not?.</param>
	/// <returns>true if string has any data otherwise false.</returns>
	public static bool HasValue(this string checkString)
		=> !checkString.IsNullOrEmpty();

	/// <summary>
	/// This method is similar to <see cref="IsNullOrEmpty(string)"/>.
	/// </summary>
	/// <param name="obj">The string which needs to be check for Null or Empty value.</param>
	/// <returns>true if string empty or null otherwise false.</returns>
	public static bool IsNull(this string obj)
		=> obj.IsNullOrEmpty();

	/// <summary>
	/// This method is similar to <see cref="HasValue(string)"/>.
	/// </summary>
	/// <param name="obj">The string which needs to be check for has any value or not?.</param>
	/// <returns>true if string has any data otherwise false.</returns>
	public static bool IsNotNull(this string obj)
		=> obj.HasValue();

	/// <summary>
	/// Helper method to get first few character from the specified collection of the characters.
	/// </summary>
	/// <param name="obj">the actual string form which need to first few character.</param>
	/// <param name="count">The count of the left most character needs to get.</param>
	/// <returns>The string with left most N characters from main input string.</returns>
	public static string Left(this string obj, int count) {
		var x = obj.Length;
		x = x > count ? count : x;
		return obj.Substring(0, x);
	}

	/// <summary>
	/// Helper method to get last few character from the specified collection of the characters.
	/// </summary>
	/// <param name="obj">the actual string form which need to get last few character.</param>
	/// <param name="count">The count of the last most character needs to get.</param>
	/// <returns>The string with last most N characters from main input string.</returns>
	public static string Right(this string obj, int count) {
		var x = obj.Length;
		x = x > count ? x - count : x;
		return obj.Substring(x);
	}

	/// <summary>
	/// this method will split string and convert to list and remove empty items.
	/// </summary>
	/// <param name="data">data string to split.</param>
	/// <param name="separator">separator to split text.</param>
	/// <returns>Collection of string created form main data.</returns>
	public static ICollection<string> SplitItemToList(this string data, char separator) {
		var ret = data.Split(separator).ToList();
		_ = ret.RemoveAll(o => o.Trim().IsNullOrEmpty());
		return ret;
	}

	/// <summary>
	/// This method will split string and convert all possible int value to create collection of int.
	/// </summary>
	/// <param name="data">data string to split.</param>
	/// <param name="separator">separator to split text.</param>
	/// <returns>Collection of integer data created form main data.</returns>
	public static ICollection<int> SplitItemToIntList(this string data, char separator) {
		var ret = data.SplitItemToList(separator);
		return ret.Where(x => int.TryParse(x, out _))
			.Select(int.Parse)
			.ToList();
	}

	/// <summary>
	/// The helper method to replace multiple text with one text.
	/// </summary>
	/// <param name="mainText">Text in which replace should perform.</param>
	/// <param name="newValue">The New text which need to be change instead-of old text(s).</param>
	/// <param name="args">The list of possible old text which need to replace with new text.</param>
	/// <returns>The Updated Text where all values from <paramref name="args"/>is replaced with <paramref name="newValue"/>.</returns>
	public static string ReplaceText(this string mainText, string newValue, params string[] args) {
		foreach (var item in args) {
			mainText = mainText.Replace(item, newValue);
		}

		return mainText;
	}
}
