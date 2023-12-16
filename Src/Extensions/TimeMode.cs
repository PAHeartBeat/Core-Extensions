// --------------------------------------------------------------------------------
// <copyright file="TimeMode.cs" company="N/A">
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
	/// 10 Day 03 Hour 05 Min 20 Sec or 12 Hour 25 Min 00 Sec or 05 Min 00 Sec.
	/// </summary>
	Full = 1,

	/// <summary>
	/// This option will provide format like...
	/// 09D 05H or 23H:05M or 10M:05S.
	/// </summary>
	Compact = 2,

	/// <summary>
	/// This option will provide format like...
	/// 10D 2H or 23H 5M or 10M 5S.
	/// </summary>
	Minimal = 3,

	/// <summary>
	/// This option will provide format like...
	/// 10D 2H or 23H 5M or 10M 5S.
	/// </summary>
	MinimalCaps = 4,
}
