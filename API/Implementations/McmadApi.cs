﻿using System;
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
        /// The class that makes calls to the server.
        /// </summary>
        private readonly IServerCaller servercaller;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="McmadApi"/> class.
        /// </summary>
        /// <param name="servercaller">The <see cref="IServerCaller"/> to use.</param>
        internal McmadApi(IServerCaller servercaller) 
        {
            this.servercaller = servercaller;
        }

        #endregion

        #region IMcmadApi

        /// <summary>
        /// Gets a value indicating whether the user has successfully logged in.
        /// </summary>
        public bool IsLoggedIn
        {
            get
            {
                return servercaller.IsLoggedIn;
            }
        }

        /// <summary>
        /// Gets the server URL for the server that this instance is calling as a <see cref="string"/>.
        /// </summary>
        public string ServerURL
        {
            get 
            { 
                return servercaller.ServerURL; 
            }
        }

        /// <summary>
        /// Gets the Authorisation Mask for the logged in user.
        /// </summary>
        public AuthMask AuthorisationMask
        {
            get; private set;
        }

        /// <summary>
        /// Gets the User Mask for the logged in user.
        /// </summary>
        public UserMask UserPermissionMask
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
            CheckLoggedIn();
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
            CheckLoggedIn();
            CheckUserPermissionsForMethod("CanChangePassword");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool StartServer()
        {
            CheckLoggedIn();
            CheckUserPermissionsForMethod("CanStartServer");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool StopServer()
        {
            CheckLoggedIn();
            CheckUserPermissionsForMethod("CanStopServer");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Restarts the server.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool RestartServer()
        {
            CheckLoggedIn();
            CheckUserPermissionsForMethod("CanRestartServer");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kill the server, immediately terminating the process and potentially losing data.
        /// </summary>
        /// <returns><c>true</c> if successful.</returns>
        public bool KillServer()
        {
            CheckLoggedIn();
            CheckUserPermissionsForMethod("CanStopServer");
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
            CheckLoggedIn();
            CheckUserPermissionsForMethod("CanStopServer");
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
            CheckLoggedIn();
            CheckUserPermissionsForMethod("CanAccessConsole");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the latest server information.
        /// </summary>
        /// <returns><see cref="ServerInfo"/> object containing the server information.</returns>
        public ServerInfo GetStatus()
        {
            CheckLoggedIn();
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a list of plugins in use on the server.
        /// </summary>
        /// <returns>An <see cref="IList"/> of <see cref="ServerPlugin"/> objects that contains information about the plugins that are installed.</returns>
        public IList<ServerPlugin> GetPlugins()
        {
            CheckLoggedIn();
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
        /// Utility method to check if a user is logged in. If not, throws a <see cref="NotLoggedInException"/>
        /// </summary>
        private void CheckLoggedIn()
        {
            // If we are not logged in, throw the exception.
            if (!this.servercaller.IsLoggedIn)
            {
                throw new NotLoggedInException("No session ID. You must login before you can use this method.", null);
            }
        }

        /// <summary>
        /// Utility method to check if a user has permissions for the requested method using the <see cref="AuthorisationMask"/>. If not, throws a <see cref="NoPermissionException"/>
        /// </summary>
        private void CheckAuthMaskPermissionsForMethod(string permissions)
        {
            // If we are not logged in, throw the exception.
            if ((bool)typeof(AuthMask).GetProperty(permissions).GetValue(this.AuthorisationMask, null))
            {
                throw new NoPermissionException("No permssions for this method. Please contact your server admin if you believe this is in error.", null);
            }
        }

        /// <summary>
        /// Utility method to check if a user has permissions for the requested method using the <see cref="UserPermissionsMask"/>. If not, throws a <see cref="NoPermissionException"/>
        /// </summary>
        private void CheckUserPermissionsForMethod(string permissions)
        {
            // If we are not logged in, throw the exception.
            if ((bool)typeof(UserMask).GetProperty(permissions).GetValue(this.AuthorisationMask, null))
            {
                throw new NoPermissionException("No permssions for this method - failed check " + permissions + ". Please contact your server admin if you believe this is in error.", null);
            }
        }

        #endregion
    }
}