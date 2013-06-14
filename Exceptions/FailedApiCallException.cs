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
        /// Initialises a new instance of the FailedApiCallException class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public FailedApiCallException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
