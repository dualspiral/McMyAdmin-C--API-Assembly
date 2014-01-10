// <copyright file="ServerInfo.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using McMyAdminAPI.Enums;
using McMyAdminAPI.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        [JsonProperty(PropertyName = "state")]
        public ServerStatus RunStatus { get; internal set; }

        /// <summary>
        /// Gets the number of players currently on the server.
        /// </summary>
        [JsonProperty(PropertyName = "users")]
        public int? NumberOfPlayers { get; internal set; }

        /// <summary>
        /// Gets the maximum number of players currently on the server.
        /// </summary>
        [JsonProperty(PropertyName = "maxusers")]
        public int? MaxNumberOfPlayers { get; internal set; }

        /// <summary>
        /// Gets the current CPU usage.
        /// </summary>
        /// <remarks>
        /// This value is a percentage, so will always be between 0 and 100.
        /// </remarks>
        [JsonProperty(PropertyName = "cpuusage")]
        public int? CPU { get; internal set; }

        /// <summary>
        /// Gets the current RAM usage.
        /// </summary>
        [JsonProperty(PropertyName = "ram")]
        public int? RAM { get; internal set; }

        /// <summary>
        /// Gets the maximum allocated RAM to your server.
        /// </summary>
        [JsonProperty(PropertyName = "maxram")]
        public int? MaxRAM { get; internal set; }

        /// <summary>
        /// Gets the server uptime.
        /// </summary>
        [JsonProperty(PropertyName = "uptime")]
        [JsonConverter(typeof(JsonUptimeConverter))]
        public TimeSpan? Uptime { get; internal set; }

        /// <summary>
        /// Gets the list of players currently on the server.
        /// </summary>
        [JsonProperty(PropertyName = "userinfo")]
        [JsonConverter(typeof(JsonPlayerConverter))]
        public List<Player> Players { get; internal set; }
    }
}
