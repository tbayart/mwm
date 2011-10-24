// <copyright file="IList.cs">
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
using System.Collections.Generic;
using System.Linq;

namespace Mwm.Extension
{
	/// <summary>
	/// Extension methods for <see cref="System.Collections.Generic.IList{T}"/>.
	/// </summary>
	public static class IListExtensions
	{
		/// <summary>
		/// Insert a range of items beginning at a specified index.
		/// </summary>
		/// <param name="list">The list to insert to.</param>
		/// <param name="items">The items to insert</param>
		/// <param name="index">The index to insert at.</param>
		public static void InsertRange<T>(this IList<T> list, IEnumerable<T> items, int index)
		{
			foreach(T item in items.Reverse())
			{
				list.Insert(index, item);
			}
		}
	}
}