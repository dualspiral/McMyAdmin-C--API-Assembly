// <copyright file="UserMask.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.DataTransferObjects
{
    /// <summary>
    /// Structure that contains the UserMask for a <see cref="Player"/>
    /// </summary>
    public struct UserMask
    {
        #region Private Fields

        /// <summary>
        /// The <see cref="UserMask"/> numeric representation.
        /// </summary>
        private int usermask;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialises a new instance of the <see cref="UserMask"/> structure.
        /// </summary>
        /// <param name="usermask">The user mask.</param>
        public UserMask(int usermask)
        {
            this.usermask = usermask;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the user authmask
        /// </summary>
        public int GetRawUserMask
        {
            get { return usermask; }
        }

        /// <summary>
        /// Gets a value indicating whether the user can change their password.
        /// </summary>
        /// <remarks>
        /// A <see cref="UserMask"/> that has the bit the represents 4 set denotes that they CANNOT change their password.
        /// </remarks>
        public bool CanChangePassword 
        { 
            get 
            { 
                return !GetMaskComparison(4); 
            } 
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Calculates the bitwise AND operation on the <see cref="UserMask"/> with the provided permission code.
        /// </summary>
        /// <param name="permissionCode">Integer that represents a permission.</param>
        /// <returns><c>true</c> if the comparison returns the code, <c>false</c> otherwise.</returns>
        private bool GetMaskComparison(int permissionCode)
        {
            return (usermask & permissionCode) == permissionCode;
        }

        #endregion
    }
}
