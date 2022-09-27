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
			switch (mode) {
				case TimeMode.Countdown:
					if (span.TotalDays > 1) format = @"{0:d}Day {0:h}:{0:m}:{0:s}";
					else if (span.TotalHours > 1) format = @"{0:h}:{0:m}:{0:s}";
					format = @"{0:m}:{0:s}";
					break;

				case TimeMode.Minimal:
					if (span.TotalDays > 1) format = @"{0:d}Day {0:h}H";
					else if (span.TotalHours > 1) format = @"{0:h}H {0:m}M";
					format = @"{0:m}M {0:s}S";
					break;

				case TimeMode.Compact:
					if (span.TotalDays > 1) format = @"{0:dd} Day {0:hh} Hour";
					else if (span.TotalHours > 1) format = @"{0:hh} Hour {0:mm} Min";
					format = @"{0:mm} Min {0:ss} Sec";
					break;

				case TimeMode.Full:
					if (span.TotalDays > 1) format = @"{0:dd} Day {0:hh} Hour {0:mm} Min {0:ss} Sec";
					else if (span.TotalHours > 1) format = @"{00:hh} Hour {00:mm} Min {00:ss} Sec";
					format = @"{00:mm} Min {00:ss} Sec";
					break;
			}
			retValue = string.Format(format, span);
			return retValue;
		}
	}

	public enum TimeMode {
		Countdown = 0,
		Minimal = 1,
		Compact = 2,
		Full = 3,
	}
}
