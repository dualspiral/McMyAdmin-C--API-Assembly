using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using McMyAdminAPI.DataTransferObjects;
using McMyAdminAPI.Exceptions;
using McMyAdminAPI.Interfaces;

namespace McMyAdminAPI.Implementations
{
    /// <summary>
    /// Implementation of the <see cref="IMcmadApi"/> class. Allows the user to access the McMyAdmin API.
    /// </summary>
    internal class McmadApi : IMcmadApi
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
        /// The session token.
        /// </summary>
        private string sessionToken = string.Empty;

        /// <summary>
        /// Cookies to be held between API calls.
        /// </summary>
        private CookieCollection cookies = new CookieCollection();

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the McmadApi class.
        /// </summary>
        /// <param name="serverurl">URL of Server to call.</param>
        internal McmadApi(string serverurl) 
        {
            this.serverurl = serverurl;
        }

        #endregion

        #region IMcmadApi

        /// <summary>
        /// Gets a value indicating whether the user has successfully logged in.
        /// </summary>
        public bool IsLoggedIn
        {
            get; private set;
        }

        /// <summary>
        /// Gets the server URL for the server that this instance is calling.
        /// </summary>
        public string ServerURL
        {
            get { return serverurl; }
        }

        /// <summary>
        /// Gets the Authorisation Mask for the logged in user.
        /// </summary>
        public AuthMask AuthMask
        {
            get; private set;
        }

        /// <summary>
        /// Gets the User Mask for the logged in user.
        /// </summary>
        public UserMask UserMask
        {
            get; private set;
        }

        /// <summary>
        /// Login to the server. Must be called before any other method.
        /// </summary>
        /// <param name="username">Username to log in with.</param>
        /// <param name="password">Password to log in with.</param>
        /// <returns><c>true</c> if the user was able to log in, <c>false</c> if it failed.</returns>
        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logout from the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool Logout()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Change the current user's password.
        /// </summary>
        /// <param name="oldpassword">Current password.</param>
        /// <param name="newpassword">Password to change it to.</param>
        /// <returns><c>true</c> if successful.</returns>
        public bool ChangePassword(string oldpassword, string newpassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool StartServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool StopServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Restarts the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool RestartServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kill the server, immediately terminating the process and potentially losing data.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool KillServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Put the server to sleep.
        /// </summary>
        /// <remarks>
        /// "Sleep" in McMyAdmin is the same as stopping the server. 
        /// However, if someone tries to connect, McMyAdmin will restart the server, 
        /// and ask the player to try to reconnect in a few seconds.
        /// </remarks>
        /// <returns><c>true</c> if successful.</returns>
        public bool SleepServer()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the latest chat messages from the server.
        /// </summary>   
        /// <param name="timestamp">The earliest timestamp to get. Defaults to -1, which means get all Chat Messages in the server buffer.</param>
        /// <returns>
        /// An <see cref="IList"/> of <see cref="ChatMessage"/> objects that contain all the chat messages 
        /// in the McMyAdmin server with a timestamp greater than the one specified.
        /// </returns>
        public IList<ChatMessage> GetChat(long timestamp = -1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the latest server information.
        /// </summary>
        /// <returns><see cref="ServerInfo"/> object containing the server information.</returns>
        public ServerInfo GetStatus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a list of plugins in use on the server.
        /// </summary>
        /// <returns>An <see cref="IList"/> of <see cref="ServerPlugin"/> objects that contains information about the plugins that are installed.</returns>
        public IList<ServerPlugin> GetPlugins()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Perform a call on the API and retrieve the JSON serialised as a string.
        /// </summary>
        /// <param name="apimethod">API method to call.</param>
        /// <param name="parameters">Key-value pairs of the method call parameters.</param>
        /// <returns><see cref="string"/> containing the JSON response.</returns>
        public string MakeRawCall(string apimethod, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Queries the server.
        /// </summary>
        /// <param name="apimethod">Api method to call.</param>
        /// <param name="parameters">A key-value set of parameters to call.</param>
        /// <returns>String containing the server response.</returns>
        private string Query(string apimethod, IDictionary<string, string> parameters)
        {
            // Build the query string.
            StringBuilder query = new StringBuilder("/data.json?req=");
            query.Append(apimethod);

            // Add any parameters we have.
            foreach (string key in parameters.Keys)
            {
                string a = this.EscapeString(key);
                string b = this.EscapeString(parameters[key]);

                query.AppendFormat("&{0}={1}", a, b);
            }

            // Add the session token.
            query.AppendFormat("&MCMASESSIONID={0}", sessionToken);

            // Create the URL to request from.
            Uri requestUri = new Uri(string.Format("{0}{1}", ServerURL, query.ToString()));

            // Fix any spaces.
            this.ForceCanonicalPathAndQuery(requestUri);

            // Create the request
            HttpWebRequest request = WebRequest.Create(requestUri) as HttpWebRequest;

            // Add the cookies to the request.
            request.CookieContainer = new CookieContainer();
            if (this.cookies.Count != 0)
            {
                foreach (Cookie a in this.cookies)
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
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new FailedApiCallException(string.Format("Server returned an HTTP error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription), null);
                    }

                    // Set the cookies to be sent next time.
                    cookies = response.Cookies;

                    // Get the text response.
                    StreamReader httpReponse = new StreamReader(response.GetResponseStream(), true);

                    // Return it.
                    return httpReponse.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                // If we failed, throw the failed exception with the inner exception set to what cause this to fail.
                throw new FailedApiCallException("The API failed to make the call.", e);
            }
        }

        /// <summary>
        /// Method to force use of %2F in URLs (Thanks to http://stackoverflow.com/questions/781205/getting-a-url-with-an-url-encoded-slash)
        /// </summary>
        /// <param name="uri"><see cref="Uri"/> that contains the request to be made.</param>
        private void ForceCanonicalPathAndQuery(Uri uri)
        {
            string paq = uri.PathAndQuery; // need to access PathAndQuery
            FieldInfo flagsFieldInfo = typeof(Uri).GetField("m_Flags", BindingFlags.Instance | BindingFlags.NonPublic);
            ulong flags = (ulong)flagsFieldInfo.GetValue(uri);
            flags &= ~((ulong)0x30); // Flags.PathNotCanonical|Flags.QueryNotCanonical
            flagsFieldInfo.SetValue(uri, flags);
        }

        /// <summary>
        /// Escapes a string using Uri encoding
        /// </summary>
        /// <param name="toEscape">String to escape.</param>
        /// <returns>Escaped string.</returns>
        private string EscapeString(string toEscape)
        {
            // Try to escape it.
            string escaped = Uri.EscapeUriString(toEscape);

            // The above method doesn't seem to escape properly...
            escaped = escaped.Replace("/", "%2F");
            escaped = escaped.Replace("&", "%26");
            escaped = escaped.Replace("?", "%3F");
            escaped = escaped.Replace("=", "%3D");
            escaped = escaped.Replace("#", "%23");

            return escaped;
        }

        #endregion
    }
}
