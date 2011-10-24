// <copyright file="ExtensionTests.cs">
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
using System.Diagnostics;

using Mwm.Extension;

using NUnit.Framework;

namespace Test
{
	[TestFixture]
	public class ExtensionTests
	{
		[Test]
		public void ByteExtensions_GetBit()
		{
			byte value = 9;
			Assert.That(value.GetBit(0), Is.True, "Bit 0");
			Assert.That(value.GetBit(1), Is.False, "Bit 1");
			Assert.That(value.GetBit(2), Is.False, "Bit 2");
			Assert.That(value.GetBit(3), Is.True, "Bit 3");
			Assert.That(value.GetBit(4), Is.False, "Bit 4");
			Assert.That(value.GetBit(5), Is.False, "Bit 5");
			Assert.That(value.GetBit(6), Is.False, "Bit 6");
			Assert.That(value.GetBit(7), Is.False, "Bit 7");
		}
		
		[Test]
		public void ByteExtensions_ToBits()
		{
			byte value = 38;
			bool[] bits = value.ToBits();
			Assert.That(bits[0], Is.False, "Bit 0");
			Assert.That(bits[1], Is.True, "Bit 1");
			Assert.That(bits[2], Is.True, "Bit 2");
			Assert.That(bits[3], Is.False, "Bit 3");
			Assert.That(bits[4], Is.False, "Bit 4");
			Assert.That(bits[5], Is.True, "Bit 5");
			Assert.That(bits[6], Is.False, "Bit 6");
			Assert.That(bits[7], Is.False, "Bit 7");
		}
		
		[Test]
		public void ByteExtensions_ArrayToBits()
		{
			byte[] bytes = new byte[] { 27, 122 };
			bool[] bits = bytes.ToBits();
			for(int i = 0; i < bits.Length; i++)
			{
				Console.WriteLine("{0}: {1}", i, bits[i]);
			}
			Assert.That(bits[0], Is.True, "Bit 0");
			Assert.That(bits[1], Is.True, "Bit 1");
			Assert.That(bits[2], Is.False, "Bit 2");
			Assert.That(bits[3], Is.True, "Bit 3");
			Assert.That(bits[4], Is.True, "Bit 4");
			Assert.That(bits[5], Is.False, "Bit 5");
			Assert.That(bits[6], Is.False, "Bit 6");
			Assert.That(bits[7], Is.False, "Bit 7");
			
			Assert.That(bits[8], Is.False, "Bit 8");
			Assert.That(bits[9], Is.True, "Bit 9");
			Assert.That(bits[10], Is.False, "Bit 10");
			Assert.That(bits[11], Is.True, "Bit 11");
			Assert.That(bits[12], Is.True, "Bit 12");
			Assert.That(bits[13], Is.True, "Bit 13");
			Assert.That(bits[14], Is.True, "Bit 14");
			Assert.That(bits[15], Is.False, "Bit 15");
		}
	}
}
