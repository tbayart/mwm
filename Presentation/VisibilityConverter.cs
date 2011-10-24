// <copyright file="VisibilityConverter.cs">
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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Mwm.Presentation
{
	/// <summary>
	/// Represents the converter that converts Boolean values to and from <see cref="Visibility" /> enumeration values,
	/// with the ability to control several aspects of the conversion.
	/// </summary>
	public class BooleanVisibilityConverter : IValueConverter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BooleanVisibilityConverter"/> class.
		/// </summary>
		public BooleanVisibilityConverter()
			: this(false, Visibility.Collapsed)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BooleanVisibilityConverter"/> class.
		/// </summary>
		/// <param name="invert">A value indicating whether to invert the conversion logic.</param>
		/// <param name="falseValue">The <see cref="Visibility"/> value to be returned when converting a false value.</param>
		public BooleanVisibilityConverter(bool invert, Visibility falseValue)
		{
			Invert = invert;
			FalseValue = falseValue;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to invert the conversion logic.
		/// </summary>
		[DefaultValue(false)]
		public bool Invert { get; set; }

		/// <summary>
		/// Gets or sets the <see cref="Visibility"/> value to be returned when converting a false value.
		/// </summary>
		[DefaultValue(Visibility.Collapsed)]
		public Visibility FalseValue { get; set; }

		/// <summary>
		/// Converts a <see cref="Boolean"/> value to a <see cref="Visibility" /> enumeration value.
		/// </summary>
		/// <returns>
		///	<see cref="Visibility.Visible" /> if <paramref name="value" /> is true and <see cref="Invert"/> is false, or if <paramref name="value" /> is false and <see cref="Invert"/> is true; otherwise, <see cref="FalseValue" />.
		/// </returns>
		/// <param name="value">The <see cref="Boolean"/> or <see cref="Nullable{Boolean}"/> value to convert.</param>
		/// <param name="targetType">This parameter is not used.</param>
		/// <param name="parameter">This parameter is not used.</param>
		/// <param name="culture">This parameter is not used.</param>
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			bool? rawValue = null;
			if (value is bool) {
				rawValue = (bool)value;
			} else if (value is bool?) {
				rawValue = (bool?)value;
			}

			if (!rawValue.HasValue) {
				rawValue = false;
			}
			var finalValue = this.Invert ? !rawValue.Value : rawValue.Value;

			return finalValue ? Visibility.Visible : this.FalseValue;
		}

		/// <summary>
		/// Converts a <see cref="Visibility" /> enumeration value to a <see cref="Boolean"/> value.
		/// </summary>
		/// <returns>
		/// false if <paramref name="value" /> is not <see cref="Visibility.Visible" /> and <see cref="Invert"/> is false, or if <paramref name="value" /> is <see cref="Visibility.Visible" /> and <see cref="Invert"/> is true; otherwise, true.
		/// </returns>
		/// <param name="value">A <see cref="Visibility" /> enumeration value. </param>
		/// <param name="targetType">This parameter is not used.</param>
		/// <param name="parameter">This parameter is not used.</param>
		/// <param name="culture">This parameter is not used.</param>
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var convertedValue = false;
			if (value is Visibility) {
				convertedValue = ((Visibility)value) == Visibility.Visible;
			}

			return Invert ? !convertedValue : convertedValue;
		}
	}
}
