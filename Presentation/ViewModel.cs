 // <copyright file="ViewModel.cs">
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
using System.ComponentModel;
using System.Diagnostics.Contracts;

using Mwm.Extension;

namespace Mwm.Presentation
{
	/// <summary>
	/// View-Model base class.
	/// </summary>
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		/// <summary>
		/// Occurs when the value of a property has changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Raises the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		/// <param name="propertyName">The name of the property that changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			Contract.Requires(GetType().GetProperty(propertyName) != null);
			
			this.RaiseEvent(PropertyChanged, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	/// <summary>
	/// Strongly-typed View-Model base class.
	/// </summary>
	/// <typeparam name="TModel">The type of the model being wrapped.</typeparam>
	/// <example>
	/// <code>
	/// <![CDATA[
	/// public class PersonViewModel : ViewModel<Person>
	/// {
	/// 	public PersonViewModel(Person person)
	/// 		: base(person)
	/// 	{
	/// 	}
	/// 
	/// 	public string Name
	/// 	{
	/// 		get { return this.GetValue(p => p.Name); }
	/// 		set { this.SetValue(p => p.Name = value, "Name"); }
	/// 	}
	/// }
	/// ]]>
	/// </code>
	/// </example>
	public abstract class ViewModel<TModel> : ViewModelBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ViewModel{TModel}"/> class.
		/// </summary>
		/// <param name="model">The model being wrapped.</param>
		protected ViewModel(TModel model)
		{
			Model = model;
		}
		
		/// <summary>
		/// Gets or sets a reference to the model being wrapped.
		/// </summary>
		protected TModel Model { get; set; }
  	 
		/// <summary>
		/// Get the value of a property on the model.
		/// </summary>
		protected TValue GetValue<TValue>(Func<TModel, TValue> func)
		{
			return func(Model);
		}
	
		/// <summary>
		/// Set the value of a property on the model and raise the <see cref="INotifyPropertyChanged.PropertyChanged"/> event.
		/// </summary>
		protected void SetValue(Action<TModel> action, string propertyName)
		{
			action(Model);
			OnPropertyChanged(propertyName);
		} 
	}
}
