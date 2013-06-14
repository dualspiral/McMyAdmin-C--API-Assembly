using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.DataTransferObjects
{
    public struct UserMask
    {
         #region Private Fields

        /// <summary>
        /// The usermask.
        /// </summary>
        private int usermask;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the UserMask structure.
        /// </summary>
        /// <param name="authmask">The user mask.</param>
        public UserMask(int usermask)
        {
            this.usermask = usermask;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets whether the user can change their password.
        /// </summary>
        /// <remarks>
        /// A usermask that has the bit the represents 4 set denotes that they CANNOT change their password.
        /// </remarks>
        public bool CanChangePassword { get { return !GetMaskComparison(4); } }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Calculates the bitwise AND operation on the authmask with the provided permission code.
        /// </summary>
        /// <param name="permissionCode">Integer that represents a permission.</param>
        /// <returns><see cref="true"/> if the comparision returns the code, <see cref="false"/> otherwise.</returns>
        private bool GetMaskComparison(int permissionCode)
        {
            return (usermask & permissionCode) == permissionCode;
        }

        #endregion
    }
}
