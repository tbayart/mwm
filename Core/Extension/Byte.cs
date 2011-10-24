// <copyright file="Byte.cs">
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

namespace Mwm.Extension
{
	/// <summary>
	/// Extension methods for <see cref="Byte"/>.
	/// </summary>
	public static class ByteExtensions
	{
		/// <summary>
		/// Get the on state of the bit at the specific index of the <see cref="Byte"/>.
		/// </summary>
		/// <param name="value">The source value.</param>
		/// <param name="index">The bit index.</param>
		/// <returns>True if the specified bit is on; false otherwise.</returns>
		public static bool GetBit(this byte value, short index)
		{
			return (value & (1 << index)) != 0;
		}
		
		/// <summary>
		/// Get the specified <see cref="Byte"/> as a collection of bits.
		/// </summary>
		/// <param name="value">The source value.</param>
		/// <returns>The collecion of bits representing the specified <see cref="Byte"/>.</returns>
		public static bool[] ToBits(this byte value)
		{
			var bits = new bool[8];
			for(short i = 0; i < 8; i++)
			{
				bits[i] = value.GetBit(i);
			}
			return bits;
		}
		
		/// <summary>
		/// Get the specified <see cref="Byte"/> array as a collection of bits.
		/// </summary>
		/// <param name="bytes">The source array.</param>
		/// <returns>The collecion of bits representing the specified <see cref="Byte"/> array.</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "bytes")]
		public static bool[] ToBits(this byte[] bytes)
		{
			var bits = new List<bool>(bytes.Length * 8);
			for(int i = 0; i < bytes.Length; i++)
			{
				if(BitConverter.IsLittleEndian)
				{
					bits.AddRange(bytes[i].ToBits());
				}
				else
				{
					bits.InsertRange(0, bytes[i].ToBits());
				}
			}
			
			return bits.ToArray();
		}
	}
}
