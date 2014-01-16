// <copyright file="FailedApiCallException.cs">
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
    /// Exception thrown when an API call failed.
    /// </summary>
    public class FailedApiCallException : Exception
    {
        /// <summary>
        /// Gets the status code that was returned with the response, if any.
        /// </summary>
        public int? Status { get; private set; }

        /// <summary>
        /// Initialises a new instance of the FailedApiCallException class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        /// <param name="status">The status that is included with the JSON string, if any. Defaults to <c>null</c></param>
        public FailedApiCallException(string message, Exception innerException, int? status = null) 
            : base(message, innerException)
        {
            Status = status;
        }
    }
}
