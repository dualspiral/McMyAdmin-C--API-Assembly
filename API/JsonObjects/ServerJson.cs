// <copyright file="ServerInfo.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using McMyAdminAPI.BusinessEntities;

namespace McMyAdminAPI.JsonObjects
{
    /// <summary>
    /// Provides general information about the current server status.
    /// </summary>
    /// <remarks>
    /// Most objects in this class are <see cref="Nullable"/>, as McMyAdmin does not send all information unless the server is in a running state.
    /// </remarks>
    internal class ServerJson : ServerInfo
    {
        /// <summary>
        /// Gets or sets the failure status.
        /// </summary>
        internal bool Failed { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the "status" property.
        /// </summary>
        /// <remarks>
        /// This value is broadly in line with the HTTP Status code definitions. On success, we expect this to be "200".
        /// </remarks>
        internal int Status { get; set; }
    }
}
