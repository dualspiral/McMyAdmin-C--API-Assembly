// <copyright file="ServerInfo.cs">
// Copyright (c) 2013-2014. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using McMyAdminAPI.BusinessEntities;
using Newtonsoft.Json;

namespace McMyAdminAPI.JsonObjects
{
    /// <summary>
    /// Provides general information about the current server status.
    /// </summary>
    internal class ServerJson : ServerInfo, IStatusJson
    {
        /// <summary>
        /// Gets or sets the failure status.
        /// </summary>
        [JsonProperty(PropertyName = "failed")]
        public bool Failed { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the "status" property.
        /// </summary>
        /// <remarks>
        /// This value is broadly in line with the HTTP Status code definitions. On success, we expect this to be "200".
        /// </remarks>
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }
    }
}
