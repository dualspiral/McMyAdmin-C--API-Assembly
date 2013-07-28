// <copyright file="IServerCaller.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.Interfaces
{
    /// <summary>
    /// Makes API calls to the server.
    /// </summary>
    public interface IServerCaller
    {
        #region Properties
           
        /// <summary>
        /// Gets the Server Url as a <see cref="string"/>.
        /// </summary>
        string ServerURL { get; }

        /// <summary>
        /// Gets or sets the Session Token.
        /// </summary>
        string SessionToken { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Queries the server.
        /// </summary>
        /// <param name="apimethod">Api method to call.</param>
        /// <param name="parameters">
        /// A key-value set of parameters to call. Should be set to <c>null</c> if 
        /// there are no parameters to add to the method.
        /// </param>
        /// <returns><see cref="String"/> containing the server response as serialized <see cref="Json"/>.</returns>
        string Query(string apimethod, IDictionary<string, string> parameters = null);

        #endregion
    }
}
