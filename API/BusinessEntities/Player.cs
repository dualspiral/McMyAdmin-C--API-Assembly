// <copyright file="Player.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>

using System;

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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the player's IP address.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the Connection time.
        /// </summary>
        public DateTime Connected { get; set; }
    }
}
