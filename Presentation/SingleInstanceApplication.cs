// <copyright file="SingleInstanceApplication.cs">
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
using System.Diagnostics.Contracts;
using System.Windows;

using Microsoft.VisualBasic.ApplicationServices;

namespace Mwm.Presentation
{
	/// <summary>
	/// A single instance application bootstrapper for a <see cref="Application"/>.
	/// </summary>
	public class SingleInstanceApplication : WindowsFormsApplicationBase
	{
		private Application _app = null;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="SingleInstanceApplication"/> class.
		/// </summary>
		/// <param name="app">The wrapped WPF application object.</param>
		public SingleInstanceApplication(Application app)
			: base()
		{
			Contract.Requires(app != null);
			Contract.Requires(app.MainWindow != null);
			
			IsSingleInstance = true;
			_app = app;
		}
		
		protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
		{
			base.OnStartup(eventArgs);
			
			ProcessArguments(eventArgs.CommandLine);
			_app.Run(this._app.MainWindow);
			
			return false;
		}
		
		protected override void OnStartupNextInstance(Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs eventArgs)
		{
			base.OnStartupNextInstance(eventArgs);
			
			_app.MainWindow.Activate();
		}
		
		/// <summary>
		/// Processes command-line arguments passed to the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		protected virtual void ProcessArguments(IEnumerable<string> args)
		{
		}
	}
}
