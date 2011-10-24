// <copyright file="Object.cs">
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

namespace Mwm.Extension
{
    /// <summary>
    /// Extension methods for <see cref="System.Object"/>.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Raise an event.
        /// </summary>
        /// <param name="sender">The sender that is raising the event.</param>
        /// <param name="handler">The event handler.</param>
        /// <param name="e">The event args.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        public static void RaiseEvent(this object sender, EventHandler handler, EventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /// <summary>
        /// Raise a property changed event.
        /// </summary>
        /// <param name="sender">The sender that is raising the event.</param>
        /// <param name="handler">The event handler.</param>
        /// <param name="e">The event args.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        public static void RaiseEvent(this object sender, PropertyChangedEventHandler handler, PropertyChangedEventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /// <summary>
        /// Raise an event with the specified <see cref="EventArgs"/> type.
        /// </summary>
        /// <param name="sender">The sender that is raising the event.</param>
        /// <param name="handler">The event handler.</param>
        /// <param name="e">The event args.</param>
        /// <typeparam name="TArgs">The type of event args.</typeparam>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
        public static void RaiseEvent<TArgs>(this object sender, EventHandler<TArgs> handler, TArgs e)
            where TArgs : EventArgs
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /// <summary>
        /// Determines whether the <see cref="Object"/> is null.
        /// </summary>
        /// <param name="value">The <see cref="Object"/>.</param>
        /// <returns>
        /// <c>true</c> if the <see cref="Object"/> is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the <see cref="Object"/> is null.
        /// </summary>
        /// <param name="value">The <see cref="Object"/>.</param>
        /// <param name="parameterName">The name of the parameter being checked.</param>
        /// <exception cref="ArgumentNullException">The object is null.</exception>
        public static void VerifyNotNull(this object value, string parameterName)
        {
            if (value.IsNull())
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
