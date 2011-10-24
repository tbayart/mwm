// <copyright file="ImageConverter.cs">
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
using System.Diagnostics.Contracts;
using System.IO;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mwm.Presentation
{
	/// <summary>
	/// Markup extension to convet from <see cref="System.Drawing.Image"/> to <see cref="ImageSource"/>.
	/// </summary>
	[MarkupExtensionReturnType(typeof(ImageSource))]
	public class ImageConverterExtension : MarkupExtension
	{
		/// <summary>
		/// Initializes a new instance of a <see cref="ImageConverterExtension"/>.
		/// </summary>
		/// <param name="image">The <see cref="System.Drawing.Image"/> to convert.</param>
		public ImageConverterExtension(System.Drawing.Image image)
		{
			Contract.Requires(image != null);
			
			Image = image;
		}
		
		/// <summary>
		/// Gets or sets the <see cref="System.Drawing.Image"/> to convert.
		/// </summary>
		public System.Drawing.Image Image { get; set; }
		
		/// <summary>
		/// Converts the stored <see cref="System.Drawing.Image"/> to an <see cref="ImageSource"/>.
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <returns>A <see cref="ImageSource"/> containing the data from the stored <see cref="System.Drawing.Image"/>.</returns>
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			Contract.Requires(this.Image != null);
			
			var stream = new MemoryStream();
			Image.Save(stream, this.Image.RawFormat);
			stream.Seek(0, SeekOrigin.Begin);
			
			var imageSource = new BitmapImage();
			imageSource.BeginInit();
			try
			{
				imageSource.StreamSource = stream;
			}
			finally
			{
				imageSource.EndInit();
			}
			
			return imageSource;
		}
	}
}
