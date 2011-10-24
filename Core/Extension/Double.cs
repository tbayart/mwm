// <copyright file="Double.cs">
// Copyright (c) Chad Weimer
// </copyright>
// <author>Chad Weimer</author>
// <summary>
// This file is part of MwM.
//
// MwM is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MwM is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MwM.  If not, see http://www.gnu.org/licenses/.
// </summary>

using System;
using System.Linq;

namespace Mwm.Extension
{
	/// <summary>
	/// Extension methods for <see cref="System.Double"/>.
	/// </summary>
	public static class DoubleExtensions
	{
		/// <summary>
		/// Get a value indicating whether the value is a whole number.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>True is the value is a whole number; false otherwise.</returns>
		public static bool IsWholeNumber(this double value)
		{
			return Math.Abs(Math.Truncate(value) - value) < double.Epsilon;
		}
	}
}
