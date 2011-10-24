// <copyright file="Int.cs">
// Copyright (c) Chad Weimer.
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
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MwM. If not, see http://www.gnu.org/licenses/.
// </summary>
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mwm.Extension
{
	/// <summary>
	/// Extension methods for integer types.
	/// </summary>
	public static class IntExtensions
	{
		/// <summary>
		/// Get the specified <see cref="Int16"/> as a collection of bits.
		/// </summary>
		/// <param name="value">The source value.</param>
		/// <returns>The collecion of bits representing the specified <see cref="Int16"/>.</returns>
		public static bool[] ToBits(this short value)
		{
			return BitConverter.GetBytes(value).ToBits();
		}
		
		/// <summary>
		/// Get the specified <see cref="Int32"/> as a collection of bits.
		/// </summary>
		/// <param name="value">The source value.</param>
		/// <returns>The collecion of bits representing the specified <see cref="Int32"/>.</returns>
		public static bool[] ToBits(this int value)
		{
			return BitConverter.GetBytes(value).ToBits();
		}
		
		/// <summary>
		/// Get the specified <see cref="Int64"/> as a collection of bits.
		/// </summary>
		/// <param name="value">The source value.</param>
		/// <returns>The collecion of bits representing the specified <see cref="Int64"/>.</returns>
		public static bool[] ToBits(this long value)
		{
			return BitConverter.GetBytes(value).ToBits();
		}
	}
}
