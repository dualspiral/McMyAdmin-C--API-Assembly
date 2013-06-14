﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.Exceptions
{
    /// <summary>
    /// Exception class thrown when the user doesn't have permission to perform an action.
    /// </summary>
    public class NoPermissionException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the NoPermissionException class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public NoPermissionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
