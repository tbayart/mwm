// <copyright file="DelegateCommand.cs">
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
using System.Windows.Input;

namespace Mwm.Presentation
{
	/// <summary>
	/// Defines an <see cref="ICommand"/> which uses delegates for the <see cref="ICommand.Execute"/> and <see cref="ICommand.CanExecute"/> methods.
	/// </summary>
	/// <typeparam name="T">The type of the argument to the <see cref="ICommand.Execute"/> and <see cref="ICommand.CanExecute"/> methods.</typeparam>
	public class DelegateCommand<T> : ICommand
	{
		private Action<T> _execute = null;
		private Func<T, bool> _canExecute = null;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
		/// </summary>
		/// <param name="execute">The <see cref="Action{T}"/> to call when the command is invoked.</param>
		/// <param name="canExecute">The <see cref="Func{T, TResult}"/> to call to determine if the command can be invoked in its current state.</param>
		public DelegateCommand(Action<T> execute, Func<T, bool> canExecute)
		{
			Contract.Requires(execute != null);
			
			_execute = execute;
			_canExecute = canExecute;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
		/// </summary>
		/// <param name="execute">The <see cref="Action{T}"/> to call when the command is invoked.</param>
		public DelegateCommand(Action<T> execute)
			: this(execute, null)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
		/// </summary>
		/// <param name="execute">The <see cref="Action"/> to call when the command is invoked.</param>
		/// <param name="canExecute">The <see cref="Func{T}"/> to call to determine if the command can be invoked in its current state.</param>
		public DelegateCommand(Action execute, Func<bool> canExecute)
			: this(p => execute(), p => canExecute())
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
		/// </summary>
		/// <param name="execute">The <see cref="Action"/> to call when the command is invoked.</param>
		public DelegateCommand(Action execute)
			: this(p => execute(), null)
		{
		}
		
		/// <summary>
		/// Occurs when the value of <see cref="CanExecute"/> may have changed.
		/// </summary>
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		
		/// <summary>
		/// Invokes the command.
		/// </summary>
		/// <param name="parameter">The argument to the command.</param>
		public void Execute(object parameter)
		{
			Contract.Requires(parameter is T);
			
			_execute((T)parameter);
		}
		
		/// <summary>
		/// Determines whether this <see cref="DelegateCommand{T}"/> can execute in its current state.
		/// </summary>
		/// <param name="parameter">The argument to the command.</param>
		/// <returns>True is the command can be invoked; false otherwise.</returns>
		public bool CanExecute(object parameter)
		{
			Contract.Requires(parameter is T);
			
			if(_canExecute != null)
			{
				return _canExecute((T)parameter);
			}
			
			return true;
		}
	}
}
