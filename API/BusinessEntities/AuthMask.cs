// <copyright file="AuthMask.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>

namespace McMyAdminAPI.BusinessEntities
{
    /// <summary>
    /// Represents the user's authorisation mask.
    /// </summary>
    public struct AuthMask
    {
        #region Private Fields

        /// <summary>
        /// The user authorisation mask.
        /// </summary>
        private readonly int authmask;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="AuthMask"/> structure.
        /// </summary>
        /// <param name="authmask">The authorisation mask.</param>
        public AuthMask(int authmask)
        {
            this.authmask = authmask;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the user authorisation mask
        /// </summary>
        public int GetRawAuthMask
        {
            get { return authmask; }
        }

        /// <summary>
        /// Gets a value indicating whether the user can stop and kill the server.
        /// </summary>
        public bool CanStopServer
        { 
            get 
            { 
                return GetMaskComparison(1); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can start the server.
        /// </summary>
        public bool CanStartServer 
        { 
            get 
            { 
                return GetMaskComparison(2); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can restart the server.
        /// </summary>
        /// <remarks>
        /// There is no explicit permission for restart, but the user needs both 
        /// stop and start permissions to restart the server. This property reflects this.
        /// </remarks>
        public bool CanRestartServer 
        { 
            get 
            { 
                return CanStartServer && CanStopServer; 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can access the console.
        /// </summary>
        public bool CanAccessConsole 
        { 
            get 
            {
                return GetMaskComparison(4); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can modify the users and groups on the Minecraft server.
        /// </summary>
        public bool CanModifyMinecraftUsersAndGroups 
        { 
            get 
            { 
                return GetMaskComparison(8); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can alter the general game configuration.
        /// </summary>
        /// <remarks>
        /// These configuration properties are some of those that are found in the server.properties file.
        /// </remarks>
        public bool CanModifyMinecraftConfig 
        { 
            get 
            { 
                return GetMaskComparison(16); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can alter the config on the features panel.
        /// </summary>
        /// <remarks>
        /// These configuration properties are extras the McMyAdmin provide, such as 
        /// inclusion on the McMyAdmin server list.
        /// </remarks>
        public bool CanModifyFeaturesConfig 
        { 
            get 
            { 
                return GetMaskComparison(32); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can alter the server configuration.
        /// </summary>
        /// <remarks>
        /// There are the more destructive properties in the server.properties file.
        /// </remarks>
        public bool CanModifySettingsConfig 
        { 
            get 
            { 
                return GetMaskComparison(64); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can manage plugins.
        /// </summary>
        public bool CanManagePlugins 
        { 
            get 
            { 
                return GetMaskComparison(128); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can delete the world.
        /// </summary>
        public bool CanDeleteWorld 
        { 
            get 
            { 
                return GetMaskComparison(256); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can take a backup.
        /// </summary>
        public bool CanTakeBackup 
        { 
            get 
            { 
                return GetMaskComparison(512); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can restore from a backup.
        /// </summary>
        /// <remarks>
        /// The user must also be able to delete the world to restore a backup.
        /// </remarks>
        public bool CanRestoreBackup 
        { 
            get 
            { 
                return GetMaskComparison(1024) && CanDeleteWorld; 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can delete a backup.
        /// </summary>
        public bool CanDeleteBackup 
        { 
            get 
            { 
                return GetMaskComparison(2048); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can modify the McMyAdmin schedule
        /// </summary>
        public bool CanModifySchedule 
        { 
            get 
            {
                return GetMaskComparison(4096); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can update the Minecraft server.
        /// </summary>
        /// <remarks>
        /// The user must also be able to restart the server in order to be able to update the build.
        /// </remarks>
        public bool CanUpdateMinecraft 
        { 
            get 
            { 
                return GetMaskComparison(8192) && CanRestartServer; 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can perform diagnostics on the server.
        /// </summary>
        public bool CanPerformDiagnostics 
        { 
            get 
            { 
                return GetMaskComparison(32768); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can access the file manager.
        /// </summary>
        public bool CanAccessFileManager 
        { 
            get 
            { 
                return GetMaskComparison(65536); 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can upload files.
        /// </summary>
        public bool CanUploadFiles 
        { 
            get 
            { 
                return GetMaskComparison(131072) && CanAccessFileManager; 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can modify files.
        /// </summary>
        public bool CanModifyFiles 
        { 
            get 
            { 
                return GetMaskComparison(262144) && CanAccessFileManager; 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can upload executable files.
        /// </summary>
        public bool CanUploadExecutables 
        { 
            get 
            { 
                return GetMaskComparison(524288) && CanUploadFiles; 
            } 
        }

        /// <summary>
        /// Gets a value indicating whether the user can modify the permissions of other McMyAdmin users.
        /// </summary>
        public bool CanModifyOtherMcMyAdminUsers 
        { 
            get 
            { 
                return GetMaskComparison(1048576); 
            } 
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Calculates the bitwise AND operation on the <see cref="AuthMask"/> with the provided permission code.
        /// </summary>
        /// <param name="permissionCode">Integer that represents a permission.</param>
        /// <returns><c>true</c> if the comparison returns the code, <c>false</c> otherwise.</returns>
        private bool GetMaskComparison(int permissionCode)
        {
            return (authmask & permissionCode) == permissionCode;
        }

        #endregion
    }
}
