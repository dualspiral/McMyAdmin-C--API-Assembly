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
        /// Get an instance of the <see cref="IMcmadApi"/>.
        /// </summary>
        /// <param name="serverURL">Server URL to bind interface to.</param>
        /// <returns><see cref="IMcmadApi"/> interface that encapsulates the API.</returns>
        /// <remarks>
        /// This is the starting point to get an instance of the API. Consumers should call <c>McMyAdminApi.GetInstance(url)</c>,
        /// where the <c>url</c> is their server instance location. From there, users should then use the <c>IMcmadApi.Login(user, password)</c> method
        /// to authenticate to the system.
        /// <para>
        /// Once authentication has completed, the API is usable, subject to permission checks.
        /// </para>
        /// </remarks>
        public static IMcmadApi GetInstance(string serverURL)
        {
            return new McmadApi(new ServerCaller(serverURL));
        }
    }
}
