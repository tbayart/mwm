// <copyright file="IComparable.cs">
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
using System.Text;

namespace Mwm.Extension
{
	/// <summary>
	/// 
	/// </summary>
    public static class ComparableExtensions
    {
        public static bool IsLessThan<T>(this IComparable<T> item, T value)
        {
            return item.CompareTo(value) < 0;
        }
        public static void VerifyLessThan<T>(this IComparable<T> item, T value, string parameterName)
        {
            if (item.IsGreaterThanOrEqualTo(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static bool IsLessThanOrEqualTo<T>(this IComparable<T> item, T value)
        {
            return item.CompareTo(value) <= 0;
        }
        public static void VerifyLessThanOrEqualTo<T>(this IComparable<T> item, T value, string parameterName)
        {
            if (item.IsGreaterThan(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static bool IsGreaterThan<T>(this IComparable<T> item, T value)
        {
            return item.CompareTo(value) > 0;
        }
        public static void VerifyGreaterThan<T>(this IComparable<T> item, T value, string parameterName)
        {
            if (item.IsLessThanOrEqualTo(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static bool IsGreaterThanOrEqualTo<T>(this IComparable<T> item, T value)
        {
            return item.CompareTo(value) >= 0;
        }
        public static void VerifyGreaterThanOrEqualTo<T>(this IComparable<T> item, T value, string parameterName)
        {
            if (item.IsLessThan(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static bool IsBetween<T>(this IComparable<T> item, T minimum, T maximum)
        {
            return item.IsBetween(minimum, maximum, false);
        }
        public static void VerifyBetween<T>(this IComparable<T> item, T minimum, T maximum, string parameterName)
        {
            item.VerifyBetween(minimum, maximum, parameterName, false);
        }

        public static bool IsBetween<T>(this IComparable<T> item, T minimum, T maximum, bool inclusive)
        {
            if (inclusive)
            {
                return item.IsGreaterThanOrEqualTo(minimum) || item.IsLessThanOrEqualTo(maximum);
            }
            else
            {
                return item.IsGreaterThan(minimum) || item.IsLessThan(maximum);
            }
        }
        public static void VerifyBetween<T>(this IComparable<T> item, T minimum, T maximum, string parameterName, bool inclusive)
        {
            if(!item.IsBetween(minimum, maximum, inclusive))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
    }
}
