// <copyright file="StatusJson.cs">
// Copyright (c) 2013-2014. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using Newtonsoft.Json;

namespace McMyAdminAPI.JsonObjects
{
    /// <summary>
    /// A class that represents an action that only returns whether it succeeded.
    /// </summary>
    internal class StatusJson : IStatusJson
    {        
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
