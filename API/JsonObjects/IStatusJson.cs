using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace McMyAdminAPI.JsonObjects
{
    /// <summary>
    /// Interface that represents a status.
    /// </summary>
    internal interface IStatusJson
    {
        /// <summary>
        /// Gets or sets the value associated with the "status" property.
        /// </summary>
        /// <remarks>
        /// This value is broadly in line with the HTTP Status code definitions. On success, we expect this to be "200".
        /// </remarks>
        [JsonProperty(PropertyName = "status")]
        int Status { get; set; }
    }
}
