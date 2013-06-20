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
        /// <param name="parameters">A key-value set of parameters to call.</param>
        /// <returns>String containing the server response.</returns>
        string Query(string apimethod, IDictionary<string, string> parameters);

        #endregion
    }
}
