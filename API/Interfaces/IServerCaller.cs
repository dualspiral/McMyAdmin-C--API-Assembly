using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.Interfaces
{
    /// <summary>
    /// Makes API calls to the server.
    /// </summary>
    interface IServerCaller
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether the user has a SessionID and is therefore logged in.
        /// </summary>
        bool IsLoggedIn { get; }
           
        /// <summary>
        /// Gets the Server Url as a <see cref="string"/>.
        /// </summary>
        string ServerURL { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Queries the server.
        /// </summary>
        /// <param name="apimethod">Api method to call.</param>
        /// <param name="parameters">A key-value set of parameters to call.</param>
        /// <returns>String containing the server response.</returns>
        string Query(string apimethod, IDictionary<string, string> parameters);

        #endregion
    }
}
