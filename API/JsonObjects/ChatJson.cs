// <copyright file="LoginJson.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System.Collections.Generic;
using McMyAdminAPI.BusinessEntities;
using Newtonsoft.Json;

namespace McMyAdminAPI.JsonObjects
{
    /// <summary>
    /// Class that represents the ChatJson object
    /// </summary>
    internal class ChatJson : IStatusJson
    {
        /// <summary>
        /// Gets or sets the value associated with the "timestamp" parameter
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the "status" property.
        /// </summary>
        /// <remarks>
        /// This value is broadly in line with the HTTP Status code definitions. On success, we expect this to be "200".
        /// </remarks>
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the "success" parameter
        /// </summary>
        [JsonProperty(PropertyName = "chatdata")]
        public IList<ChatMessage> ChatMessages { get; set; }
    }
}
