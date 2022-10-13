// --------------------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Extension methods for Enums.
/// </summary>
public static class EnumExtensions {
	/// <summary>
	/// Will Prase string value as Enum value to defined enum type.
	/// </summary>
	/// <typeparam name="T">Enum type for which in will be parse.</typeparam>
	/// <param name="enumStringValue">string value to convert enum value.</param>
	/// <returns>enum value of the string.</returns>
	public static T ParseEnumValue<T>(this string enumStringValue)
		where T : Enum {
		T retValue;
		retValue = (T)Enum.Parse(typeof(T), enumStringValue, true);
		return retValue;
	}

	/// <summary>
	/// Helper method to retrieve all enum value names.
	/// </summary>
	/// <typeparam name="T">manged Enum type.</typeparam>
	/// <param name="type">The enum as type.</param>
	/// <returns>Collection of the string from Enum value names.</returns>
	public static ICollection<string> GetEnumNames<T>(this T type)
		where T : Enum
		=> Enum.GetNames(typeof(T));
}
