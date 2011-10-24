// <copyright file="DirectoryInfo.cs">
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
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with MwM.  If not, see http://www.gnu.org/licenses/.
// </summary>

using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Mwm.Extension
{
	/// <summary>
	/// Extension methods for <see cref="DirectoryInfo"/>.
	/// </summary>
	public static class DirectoryInfoExtensions
	{
		/// <summary>
		/// Send the directory represented by the specified <see cref="DirectoryInfo"/> to the Recycle Bin.
		/// </summary>
		/// <param name="directory">The directory.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
		public static void Recycle(this DirectoryInfo directory)
		{
			FileSystem.DeleteDirectory(directory.FullName, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.DoNothing);
			directory.Refresh();
		}
	}
}
