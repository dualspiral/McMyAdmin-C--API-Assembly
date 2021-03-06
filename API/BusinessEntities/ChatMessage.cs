﻿// <copyright file="ChatMessage.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;

namespace McMyAdminAPI.BusinessEntities
{
    /// <summary>
    /// Contains a chat message received from the server.
    /// </summary>
    public class ChatMessage : IComparable
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time on the message.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the user who sent the message (as determined by McMyAdmin).
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the message is a chat message (as determined by McMyAdmin).
        /// </summary>
        public bool IsChat { get; set; }

        /// <summary>
        /// Gets or sets the timestamp as received by McMyAdmin
        /// </summary>
        public long Timestamp { get; set; }

        #endregion

        #region IComparable

        /// <summary>
        /// Implementation of the <see cref="IComparable"/> interface. Allows the chat messages to be sorted by Timestamp.
        /// </summary>
        /// <param name="obj">Object to compare to. Must be of type <see cref="ChatMessage"/>, or this call will throw an <see cref="InvalidCastException"/>.</param>
        /// <returns>An <see cref="int"/> to indicate the relative position of this object with regards to <paramref name="obj"/>.
        /// <list>
        /// <item>A negative value indicates that this object precedes <paramref name="obj"/></item>
        /// <item>A zero value indicates <paramref name="obj"/> has the same rank</item>
        /// <item>A positive value indicates that this object succeeds <paramref name="obj"/></item>
        /// </list>
        /// </returns>
        public int CompareTo(object obj)
        {
            // The other object should be a ChatMessage.
            var otherMessage = obj as ChatMessage;

            // If the object we are comparing to isn't actually there, return that we succeed it. Otherwise, return the comparison of the timestamp.
            return (otherMessage == null) ? 1 : Timestamp.CompareTo(otherMessage.Timestamp);
        }

        #endregion
    }
}
