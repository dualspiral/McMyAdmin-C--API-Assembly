using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using McMyAdminAPI.DataTransferObjects;

namespace McMyAdminAPI.Interfaces
{
    /// <summary>
    /// Provides methods to call the McMyAdmin API
    /// </summary>
    public interface IMcmadApi
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether the user is logged in.
        /// </summary>
        bool IsLoggedIn { get; }

        /// <summary>
        /// Gets a value indicating the ServerURL this instance is calling.
        /// </summary>
        string ServerURL { get; }

        /// <summary>
        /// Gets a value indicating the Authorisation Mask for the logged in user.
        /// </summary>
        AuthMask AuthMask { get; }

        /// <summary>
        /// Gets a value indicating the User Mask for the currently logged in user.
        /// </summary>
        UserMask UserMask { get; }

        #endregion

        #region Session and User Methods

        /// <summary>
        /// Login to the server. Must be called before any other method.
        /// </summary>
        /// <param name="username">Username to log in with.</param>
        /// <param name="password">Password to log in with.</param>
        /// <returns><c>true</c> if the user was able to log in, <c>false</c> if it failed.</returns>
        bool Login(string username, string password);

        /// <summary>
        /// Logout from the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        bool Logout();

        /// <summary>
        /// Change the current user's password.
        /// </summary>
        /// <param name="oldpassword">Current password.</param>
        /// <param name="newpassword">Password to change it to.</param>
        /// <returns><c>true</c> if successful.</returns>
        bool ChangePassword(string oldpassword, string newpassword);

        #endregion

        #region Server State Management

        /// <summary>
        /// Starts the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        bool StartServer();

        /// <summary>
        /// Stops the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        bool StopServer();

        /// <summary>
        /// Restarts the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        bool RestartServer();

        /// <summary>
        /// Kill the server, immediately terminating the process and potentially losing data.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        bool KillServer();

        /// <summary>
        /// Puts the server to sleep.
        /// </summary>
        /// <remarks>
        /// "Sleep" in McMyAdmin is the same as stopping the server. 
        /// However, if someone tries to connect, McMyAdmin will restart the server, 
        /// and ask the player to try to reconnect in a few seconds.
        /// </remarks>
        /// <returns><c>true</c> if successful.</returns>
        bool SleepServer();

        #endregion

        #region Get Information

        /// <summary>
        /// Retrieves the latest chat messages from the server.
        /// </summary>   
        /// <param name="timestamp">The earliest timestamp to get. Defaults to -1, which means get all Chat Messages in the server buffer.</param>
        /// <returns>
        /// An <see cref="IList"/> of <see cref="ChatMessage"/> objects that contain all the chat messages 
        /// in the McMyAdmin server with a timestamp greater than the one specified.
        /// </returns>
        IList<ChatMessage> GetChat(long timestamp = -1);

        /// <summary>
        /// Retrieves the latest server information.
        /// </summary>
        /// <returns><see cref="ServerInfo"/> object containing the server information.</returns>
        ServerInfo GetStatus();

        /// <summary>
        /// Retrieves a list of plugins in use on the server.
        /// </summary>
        /// <returns>An <see cref="IList"/> of <see cref="ServerPlugin"/> objects that contains information about the plugins that are installed.</returns>
        IList<ServerPlugin> GetPlugins();

        #endregion

        #region Raw Call

        /// <summary>
        /// Perform a call on the API and retrieve the JSON serialised as a string.
        /// </summary>
        /// <param name="apimethod">API method to call.</param>
        /// <param name="parameters">Key-value pairs of the method call parameters.</param>
        /// <returns><see cref="string"/> containing the JSON response.</returns>
        string MakeRawCall(string apimethod, IDictionary<string, string> parameters);

        #endregion
    }
}
