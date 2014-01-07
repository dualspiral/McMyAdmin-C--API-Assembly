// <copyright file="ServerInfo.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using McMyAdminAPI.Enums;

namespace McMyAdminAPI.BusinessEntities
{
    /// <summary>
    /// Provides general information about the current server status.
    /// </summary>
    /// <remarks>
    /// Most objects in this class are <see cref="Nullable"/>, as McMyAdmin does not send all information unless the server is in a running state.
    /// </remarks>
    public class ServerInfo
    {
        /// <summary>
        /// Gets the run status of the server.
        /// </summary>
        public ServerStatus RunStatus { get; internal set; }

        /// <summary>
        /// Gets the number of players currently on the server.
        /// </summary>
        public int? NumberOfPlayers { get; internal set; }

        /// <summary>
        /// Gets the maximum number of players currently on the server.
        /// </summary>
        public int? MaxNumberOfPlayers { get; internal set; }

        /// <summary>
        /// Gets the current CPU usage.
        /// </summary>
        /// <remarks>
        /// This value is a percentage, so will always be between 0 and 100.
        /// </remarks>
        public int? CPU { get; internal set; }

        /// <summary>
        /// Gets the current RAM usage.
        /// </summary>
        public int? RAM { get; internal set; }

        /// <summary>
        /// Gets the maximum allocated RAM to your server.
        /// </summary>
        public int? MaxRAM { get; internal set; }

        /// <summary>
        /// Gets the server uptime.
        /// </summary>
        public TimeSpan? Uptime { get; internal set; }

        /// <summary>
        /// Gets the list of players currently on the server.
        /// </summary>
        public IList<Player> Players { get; internal set; }
    }
}
