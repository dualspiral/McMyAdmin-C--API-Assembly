// <copyright file="ServerStatus.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.Enums
{
    /// <summary>
    /// An enumeration that maps the server run status code.
    /// </summary>
    public enum ServerStatus
    {
        /// <summary>
        /// The server is in a stopped state.
        /// </summary>
        Stopped = 0, 

        /// <summary>
        /// The server is starting.
        /// </summary>
        Starting = 10, 

        /// <summary>
        /// The server is running.
        /// </summary>
        Running = 20, 

        /// <summary>
        /// The server is stopping, entering the Starting state.
        /// </summary>
        Restarting = 30, 

        /// <summary>
        /// The server is stopping, entering the Stopped state.
        /// </summary>
        Stopping = 40, 

        /// <summary>
        /// The server is sleeping.
        /// </summary>
        Sleeping = 50, 

        /// <summary>
        /// The server was unable to start due to an error.
        /// </summary>
        Error = 100
    }
}
