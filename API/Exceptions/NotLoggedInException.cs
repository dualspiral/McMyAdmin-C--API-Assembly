// <copyright file="NotLoggedInException.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.Exceptions
{
    /// <summary>
    /// Exception thrown when an API call failed due to a user not being logged in.
    /// </summary>
    public class NotLoggedInException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the NotLoggedInException class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public NotLoggedInException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
