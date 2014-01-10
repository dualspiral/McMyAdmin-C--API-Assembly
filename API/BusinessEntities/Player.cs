// <copyright file="Player.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>

using System;
using Newtonsoft.Json;

namespace McMyAdminAPI.BusinessEntities
{
    /// <summary>
    /// Struct that represents a player
    /// </summary>
    public struct Player
    {
        /// <summary>
        /// Gets or sets the player name.
        /// </summary>
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the player's IP address.
        /// </summary>
        [JsonProperty(PropertyName = "IP")]
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the Connection time.
        /// </summary>
        [JsonProperty(PropertyName = "ConnectTime")]
        public DateTime Connected { get; set; }
    }
}
