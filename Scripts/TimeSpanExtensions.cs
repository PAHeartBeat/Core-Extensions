using System;

namespace iPAHeartBeat.Core.Extensions {
	/// <summary>
	/// Time Span extension to get readable time remain time
	/// </summary>
	public static class TimeSpanExtensions {
		public static string GetTickingTime(this TimeSpan span)
			=> span.GetTickingTime(TimeMode.Minimal);

		public static string GetTickingTime(this TimeSpan span, TimeMode mode) {
			string retValue;
			if (span.IsNull())
				throw new ArgumentNullException(nameof(span));

			var format = @"mm\.ss";
			if (mode == TimeMode.Minimal) {
				if (span.TotalDays > 1) format = @"{0:dd} day {0:hh} hour";
				else if (span.TotalHours > 1) format = @"{0:hh} hour {0:mm} min";
				else if (span.TotalMinutes > 1) format = @"{0:mm} min {0:ss} sec";
				else format = @"{0:mm} min {00:ss} sec";
			} else {

				if (span.TotalDays > 1) format = @"{0:dd} day {0:hh} hour {0:mm} min {0:ss} sec";
				else if (span.TotalHours > 1) format = @"{00:hh} hour {00:mm} min {00:ss} sec";
				else if (span.TotalMinutes > 1) format = @"{00:mm} min {00:ss} sec";
				else format = @"{00:mm} min {00:ss} sec";
			}
			retValue = string.Format(format, span);
			return retValue;
		}
	}

	public enum TimeMode {
		Minimal,
		Full
	}
}
