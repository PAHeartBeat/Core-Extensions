// --------------------------------------------------------------------------------
// <copyright file="TimeSpanExtensions.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

using System;

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Time Span extension to get readable time remain time.
/// </summary>
public static class TimeSpanExtensions {
	/// <summary>
	/// Helper method to get Timer Text from TimeSpan.
	/// </summary>
	/// <param name="span">Time-span value which will be used for getting ticker time.</param>
	/// <returns>Ticking time Text in minimal format.</returns>
	public static string GetTickingTime(this TimeSpan span)
		=> span.GetTickingTime(TimeMode.Minimal);

	/// <summary>
	/// Helper method to get Timer Text from TimeSpan.
	/// </summary>
	/// <param name="span">Time-span value which will be used for getting ticker time.</param>
	/// <param name="mode">The Display mode format.</param>
	/// <returns>Ticking time Text in minimal format.</returns>
	/// <exception cref="ArgumentNullException">Exception will thrown if time-span value is not provided.</exception>
	public static string GetTickingTime(this TimeSpan span, TimeMode mode) {
		string retValue;
		if (span.IsNull()) {
			throw new ArgumentNullException(nameof(span));
		}

		string format;
		format = mode switch {
			TimeMode.Minimal => span.TotalDays.CheckAndReturnFormatOrRecheck(
				"{0:%d}D {0:%h}H",
				() => span.TotalHours.CheckReturnAnyFormat("{0:%h}H:{0:%m}M", "{0:%m}M:{0:%s}S")),
			TimeMode.Compact => span.TotalDays.CheckAndReturnFormatOrRecheck(
				"{0:dd}D {0:hh}H",
				() => span.TotalHours.CheckReturnAnyFormat("{0:hh}H:{0:mm}M", "{0:mm}M:{0:ss}S")),
			TimeMode.Full => span.TotalDays.CheckAndReturnFormatOrRecheck(
				"{0:dd} Day {0:hh} Hour {0:mm} Min {0:ss} Sec",
				() => span.TotalHours.CheckReturnAnyFormat("{0:hh} Hour {0:mm} Min {0:ss} Sec", "{0:mm} Min {0:ss} Sec")),
			_ => span.TotalDays.CheckAndReturnFormatOrRecheck(
				"{0:dd\\.hh\\:mm\\:ss}",
				() => span.TotalHours.CheckReturnAnyFormat("{0:hh\\:mm\\:ss}", "{0:mm\\:ss}")),
		};

		retValue = string.Format(format, span);
		return retValue;
	}

	/// <summary>
	/// local helper method to choose based on value.
	/// </summary>
	/// <param name="value">the value which need to check with Constant value 1 to first or second value.</param>
	/// <param name="formatOnTrue">Format text when value is Bigger than the 1.</param>
	/// <param name="formatOnFalse">Format text when value is smaller than the 1.</param>
	/// <returns>return either  <paramref name="formatOnTrue"/> or <paramref name="formatOnFalse"/> value based on check.</returns>
	private static string CheckReturnAnyFormat(this double value, string formatOnTrue, string formatOnFalse)
		=> value > 1 ? formatOnTrue : formatOnFalse;

	/// <summary>
	/// local helper method to choose based on value.
	/// </summary>
	/// <param name="value">the value which need to check with Constant value 1 to first or second value.</param>
	/// <param name="formatOnTrue">Format text when value is Bigger than the 1.</param>
	/// <param name="recheckActiOnOnFalse">The delegate or action which get recheck value with other helper method.</param>
	/// <returns>return either format <paramref name="formatOnTrue"/> or format from recheck condition.</returns>
	private static string CheckAndReturnFormatOrRecheck(this double value, string formatOnTrue, Func<string> recheckActiOnOnFalse)
		=> value > 1 ? formatOnTrue : recheckActiOnOnFalse.Invoke();
}
