﻿// <copyright file="ServerCaller.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using McMyAdminAPI.Exceptions;
using McMyAdminAPI.Interfaces;

namespace McMyAdminAPI.Implementations
{
    /// <summary>
    /// Houses the implementation of the methods that actually construct the query and talk to the server.
    /// </summary>
    /// <remarks>
    /// This class should not be exposed outside of the assembly.
    /// </remarks>
    internal class ServerCaller : IServerCaller
    {
        #region Private Fields

        /// <summary>
        /// The server URL.
        /// </summary>
        /// <remarks>
        /// Once this is set by the constructor, this cannot be altered.
        /// </remarks>
        private readonly string serverurl;

        /// <summary>
        /// Cookies to be held between API calls.
        /// </summary>
        private CookieCollection cookies = new CookieCollection();

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="ServerCaller"/> class.
        /// </summary>
        /// <param name="serverurl">The Server URL to point at.</param>
        public ServerCaller(string serverurl)
        {
            this.serverurl = serverurl;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the Server Url as a <see cref="string"/>.
        /// </summary>
        public string ServerURL
        {
            get
            {
                return serverurl;
            }
        }

        /// <summary>
        /// Gets or sets the Session Token to use.
        /// </summary>
        public string SessionToken
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Queries the server.
        /// </summary>
        /// <param name="apimethod">Api method to call.</param>
        /// <param name="parameters">A key-value set of parameters to call.</param>
        /// <returns>String containing the server response.</returns>
        public string Query(string apimethod, IDictionary<string, string> parameters)
        {
            // Build the query string.
            StringBuilder query = new StringBuilder("/data.json?req=").Append(apimethod);

            if (parameters != null)
            {
                // Add any parameters we have. Don't include the MCMASESSIONID.
                foreach (string key in parameters.Keys.Where(x => x.ToUpperInvariant() != "MCMASESSIONID"))
                {
                    string a = EscapeString(key);
                    string b = EscapeString(parameters[key]);

                    query.AppendFormat("&{0}={1}", a, b);
                }
            }
            // Add the session token.
            query.AppendFormat("&MCMASESSIONID={0}", SessionToken);

            // Create the URL to request from.
            var requestUri = new Uri(string.Format("{0}{1}", serverurl, query));

            // Fix any spaces.
            // this.ForceCanonicalPathAndQuery(requestUri);

            // Create the request
            var request = WebRequest.Create(requestUri) as HttpWebRequest;

            if (request == null)
            {
                throw new FailedApiCallException("The API failed to make the call.", null);
            }

            // Add the cookies to the request.
            request.CookieContainer = new CookieContainer();
            if (cookies.Count != 0)
            {
                foreach (Cookie a in cookies)
                {
                    request.CookieContainer.Add(a);
                }
            }

            // We require this header to get the response we want.
            request.Accept = "text/javascript";

            // We need a user agent.
            request.UserAgent = "McMyAdminApiForDotNet";

            // Set the time out!
            request.Timeout = 5000;

            try
            {
                // Make the request
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response == null)
                    {
                        throw new FailedApiCallException("The API failed to make the call.", null);
                    }

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new FailedApiCallException(
                            string.Format("Server returned an HTTP error (HTTP {0}: {1}).", 
                                response.StatusCode,
                                response.StatusDescription), null, (int) response.StatusCode);
                    }

                    // Set the cookies to be sent next time.
                    cookies = response.Cookies;

                    // Get the text response.
                    var httpReponse = new StreamReader(response.GetResponseStream(), true);

                    // Return it.
                    return httpReponse.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = e.Response as HttpWebResponse;
                    if (response != null)
                    {
                        throw new FailedApiCallException(
                            string.Format("Server returned an HTTP error (HTTP {0}: {1}).", response.StatusCode,
                                response.StatusDescription), null, (int) response.StatusCode);
                    }
                }

                // If we failed, throw the failed exception with the inner exception set to what cause this to fail.
                throw new FailedApiCallException("The API failed to make the call.", e);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Escapes a string using Uri encoding
        /// </summary>
        /// <param name="toEscape">String to escape.</param>
        /// <returns>Escaped string.</returns>
        private string EscapeString(string toEscape)
        {
            // Try to escape it.
            return Uri.EscapeUriString(toEscape).Replace("/", "%2F").Replace("&", "%26").Replace("?", "%3F").Replace("=", "%3D").Replace("#", "%23");
        }

        #endregion
    }
}
