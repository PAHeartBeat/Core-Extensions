// --------------------------------------------------------------------------------
// <copyright file="TimeMode.cs" company="N/A">
// Copyright (c) N/A. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------

namespace iPAHeartBeat.Core.Extensions;

/// <summary>
/// Time Mode Enum for get different format style for time ticker.
/// </summary>
public enum TimeMode {
	/// <summary>
	/// This option will provide format like...
	/// 10D 2:10:22 or 23:5:10 or 10:5.
	/// </summary>
	Countdown = 0,

	/// <summary>
	/// This option will provide format like...
	/// 10D 2H or 23H 5M or 10M 5S.
	/// </summary>
	Minimal = 1,

	/// <summary>
	/// This option will provide format like...
	/// 09D 05H or 23H:05M or 10M:05S.
	/// </summary>
	Compact = 2,

	/// <summary>
	/// This option will provide format like...
	/// 10 Day 03 Hour 05 Min 20 Sec or 12 Hour 25 Min 00 Sec or 05 Min 00 Sec.
	/// </summary>
	Full = 3,
}
