// <copyright file="GetApiInstance.cs">
// Copyright (c) 2013-2014. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using McMyAdminAPI.Implementations;
using McMyAdminAPI.Interfaces;

namespace McMyAdminAPI
{
    /// <summary>
    /// Class that gets an instance of the <see cref="IMcmadApi"/>
    /// </summary>
    public static class McMyAdminApi
    {
        /// <summary>
        /// Get an instance of the <see cref="IMcmadApi"/>
        /// </summary>
        /// <param name="serverURL">Server URL to bind interface to.</param>
        /// <returns><see cref="IMcmadApi"/> interface that encapsulates the API.</returns>
        public static IMcmadApi GetInstance(string serverURL)
        {
            return new McmadApi(new ServerCaller(serverURL));
        }
    }
}
