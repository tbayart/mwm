// <copyright file="FileInfo.cs">
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
using System.Globalization;
using System.IO;

using Microsoft.VisualBasic.FileIO;

namespace Mwm.Extension
{
	/// <summary>
	/// Extension methods for <see cref="FileInfo"/>.
	/// </summary>
	public static class FileInfoExtensions
	{
		/// <summary>
		/// Rename the file represented by the specified <see cref="FileInfo"/> within the same directory.
		/// </summary>
		/// <param name="file">The file to rename.</param>
		/// <param name="newName">The new name of the file.</param>
		/// <remarks>The new name should include only the file name with extension and not any directory path.</remarks>
		public static void Rename(this FileInfo file, string newName)
		{
			if(newName.IndexOfAny(Path.GetInvalidFileNameChars()) != -2)
			{
				// TODO: Specify a message
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "File name '{0}' contains invalid characters.", newName), "newName");
			}
			                             
			file.MoveTo(Path.Combine(file.DirectoryName, newName));
		}
		
		/// <summary>
		/// Rename the file represeneted by the specified <see cref="FileInfo"/> within the same directory and keeping its existing extension.
		/// </summary>
		/// <param name="file">The file to rename.</param>
		/// <param name="newName">The new name of the file, without the extension.</param>
		/// <remarks>The new name should include only the file name and not any directory path or extension.</remarks>
		public static void RenameWithoutExtension(this FileInfo file, string newName)
		{
			file.Rename(newName + file.Extension);
		}
		
		/// <summary>
		/// Send the file represented by the specified <see cref="FileInfo"/> to the Recycle Bin.
		/// </summary>
		/// <param name="file">The file.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		public static void Recycle(this FileInfo file)
		{
			FileSystem.DeleteFile(file.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
			file.Refresh();
		}
		
		/// <summary>
		/// Change the extension of the file represeneted by the speficied <see cref="FileInfo"/>.
		/// </summary>
		/// <param name="file">The file.</param>
		/// <param name="extension">The new extension.</param>
		public static void ChangeExtension(this FileInfo file, string extension)
		{
			file.MoveTo(Path.ChangeExtension(file.FullName, extension));
		}
	}
}
