using System;

namespace iPAHeartBeat.Core.Extensions {
	/// <summary>
	/// Date Time extension to work and avoid date time format is different platform or different localization.
	/// </summary>
	public static class DateTimeExtensions {
		/// <summary>
		/// This will return which date time format will be used to convert string to date time and vice-versa
		/// </summary>
		public static string DateTimeFormat { private set; get; } = "yyyy.MM.dd hh:mm:ss";

		/// <summary>
		/// Method will update default datetime format, please refer Microsoft C# document to create custom datetime format.
		/// </summary>
		/// <param name="format">datetime format string to update default datetime format.</param>
		public static void SetTimeFormat(string format)
			=> DateTimeFormat = format;

		/// <summary>
		/// Method will help to convert datetime string to actual date time object.
		/// </summary>
		/// <param name="dateTimeString">Formated Datetime string. check format <see cref="DateTimeFormat"/></param>
		/// <returns>Datetime object from formated string.</returns>
		public static DateTime ConvertDateTime(this string dateTimeString) {
			return DateTime.TryParseExact(dateTimeString, DateTimeFormat, null, System.Globalization.DateTimeStyles.AssumeUniversal, out var dateTime)
				? dateTime
				: throw new Exception("Date time Convert's fail");
		}

		/// <summary>
		/// Method will help to convert Datetime value to string.
		/// </summary>
		/// <param name="dateTime">dateTime object value</param>
		/// <returns>formated string from Datetime object. Check format <see cref="DateTimeFormat"/></returns>
		public static string ConvertDateTime(this DateTime dateTime) {
			var format = string.Format($"{0:DateTimeFormat}");
			return string.Format(format, dateTime);
		}

		/// <summary>
		/// Method will convert numeric value as minute to C# Timespan.
		/// </summary>
		/// <param name="duration">duration count in minutes</param>
		/// <returns></returns>
		public static TimeSpan ConvertMinutesToTimeSpan(int duration)
			=> TimeSpan.FromMinutes(duration);

		/// <summary>
		/// Will convert C# Datetime value to Unix Epoch timestamp
		/// </summary>
		/// <param name="date">Date which you need to convert in UTC format</param>
		/// <returns>return total seconds as unix time format</returns>
		public static long GetEpochTime(this DateTime date) {
			var timespan = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return (long)timespan.TotalSeconds;
		}

		/// <summary>
		/// will convert Unix Styled seconds based epoch time value to C# datetime object.
		/// </summary>
		/// <param name="unixEpochSeconds">epoch time value in seconds</param>
		/// <returns>return C# datetime object</returns>
		public static DateTime GetDateFromEpoch(this long unixEpochSeconds) {
			var datetime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			datetime = datetime.AddSeconds(unixEpochSeconds);
			return datetime;
		}

		/// <summary>
		/// Will convert C# Datetime value to Unix Epoch timestamp
		/// </summary>
		/// <param name="date">Date which you need to convert in UTC format</param>
		/// <returns>return total seconds as unix time format</returns>
		[Obsolete("This Method is obselete, Please use 'GetEpochTime'. This Count the error for next update and after that it will be removed. ", false)]
		public static long GetUnixEpochTime(this DateTime date)
			=> date.GetEpochTime();

		/// <summary>
		/// will convert Unix Styled seconds based epoch time value to C# datetime object.
		/// </summary>
		/// <param name="unixEpochSeconds">epoch time value in seconds</param>
		/// <returns>return C# datetime object</returns>
		[Obsolete("This Method is obselete, Please use 'GetDateFromEpoch'. This Count the error for next update and after that it will be removed. ", false)]
		public static DateTime GetDateFromUnixEpochTimeStamp(this long unixEpochSeconds)
			=> unixEpochSeconds.GetDateFromEpoch();
	}
}
