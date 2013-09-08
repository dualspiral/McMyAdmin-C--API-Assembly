// <copyright file="LoginJson.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using Newtonsoft.Json;

namespace McMyAdminAPI.JsonObjects
{
    /// <summary>
    /// Class that represents the Login json object.
    /// </summary>
    public class LoginJson
    {
        /// <summary>
        /// Gets or sets the value associated with the "success" parameter
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the value associated with the "status" property.
        /// </summary>
        /// <remarks>
        /// This value is broadly in line with the HTTP Status code definitions. On success, we expect this to be "200".
        /// </remarks>
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the McMyAdmin Session Token.
        /// </summary>
        [JsonProperty(PropertyName = "MCMASESSIONID")]
        public string SessionToken { get; set; }

        /// <summary>
        /// Gets or sets the Authorisation Mask.
        /// </summary>
        [JsonProperty(PropertyName = "authmask")]
        public int AuthMask { get; set; }

        /// <summary>
        /// Gets or sets the User Mask.
        /// </summary>
        [JsonProperty(PropertyName = "usermask")]
        public int UserMask { get; set; }
    }
}
