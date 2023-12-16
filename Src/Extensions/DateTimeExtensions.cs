// --------------------------------------------------------------------------------
// <copyright file="DateTimeExtensions.cs" company="N/A">
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

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Date Time extension to work and avoid date time format is different platform or different localization.
/// </summary>
public static class DateTimeExtensions {
	/// <summary>
	/// Gets this will return which date time format will be used to convert string to date time and vice-versa.
	/// </summary>
	public static string DateTimeFormat { get; private set; } = "yyyy.MM.dd hh:mm:ss";

	/// <summary>
	/// Method will update default date-time format, please refer Microsoft C# document to create custom date-time format.
	/// </summary>
	/// <param name="format">date-time format string to update default date-time format.</param>
	public static void SetTimeFormat(string format)
		=> DateTimeFormat = format;

	/// <summary>
	/// Method will help to convert date-time string to actual date time object.
	/// </summary>
	/// <param name="dateTimeString">Formatted date-time string. check format <see cref="DateTimeFormat"/>.</param>
	/// <returns>date-time object from formatted string.</returns>
	public static DateTime ConvertDateTime(this string dateTimeString) {
		return DateTime.TryParseExact(dateTimeString, DateTimeFormat, null, System.Globalization.DateTimeStyles.AssumeUniversal, out var dateTime)
			? dateTime
			: throw new Exception("Date time Convert's fail");
	}

	/// <summary>
	/// Method will help to convert date-time value to string.
	/// </summary>
	/// <param name="dateTime">dateTime object value.</param>
	/// <returns>formatted string from date-time object. Check format <see cref="DateTimeFormat"/>.</returns>
	public static string ConvertDateTime(this DateTime dateTime) {
		var format = string.Format($"{0:DateTimeFormat}");
		return string.Format(format, dateTime);
	}

	/// <summary>
	/// Method will convert numeric value as minute to C# Time-span.
	/// </summary>
	/// <param name="duration">duration count in minutes.</param>
	/// <returns>Instance of Time-span created with minutes values.</returns>
	public static TimeSpan ConvertMinutesToTimeSpan(int duration)
		=> TimeSpan.FromMinutes(duration);

	/// <summary>
	/// Will convert C# date-time value to Unix Epoch timestamp.
	/// </summary>
	/// <param name="date">Date which you need to convert in UTC format.</param>
	/// <returns>return total seconds as unix time format.</returns>
	public static long GetEpochTime(this DateTime date) {
		var timeSpan = date - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		return (long)timeSpan.TotalSeconds;
	}

	/// <summary>
	/// will convert Unix Styled seconds based epoch time value to C# date-time object.
	/// </summary>
	/// <param name="unixEpochSeconds">epoch time value in seconds.</param>
	/// <returns>return C# date-time object.</returns>
	public static DateTime GetDateFromEpoch(this long unixEpochSeconds) {
		var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
		dateTime = dateTime.AddSeconds(unixEpochSeconds);
		return dateTime;
	}

	/// <summary>
	/// Will convert C# date-time value to Unix Epoch timestamp.
	/// </summary>
	/// <param name="date">Date which you need to convert in UTC format.</param>
	/// <returns>return total seconds as unix time format.</returns>
	[Obsolete("This Method is obsolete, Please use 'GetEpochTime'. This will count as error and after that it will be removed. ", true)]
	public static long GetUnixEpochTime(this DateTime date)
		=> date.GetEpochTime();

	/// <summary>
	/// will convert Unix Styled seconds based epoch time value to C# date-time object.
	/// </summary>
	/// <param name="unixEpochSeconds">epoch time value in seconds.</param>
	/// <returns>return C# date-time object.</returns>
	[Obsolete("This Method is obsolete, Please use 'GetDateFromEpoch'. This Count the error and after that it will be removed. ", true)]
	public static DateTime GetDateFromUnixEpochTimeStamp(this long unixEpochSeconds)
		=> unixEpochSeconds.GetDateFromEpoch();
}
