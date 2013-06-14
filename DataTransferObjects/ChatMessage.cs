using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.DataTransferObjects
{
    /// <summary>
    /// Contains a chat message recieved from the server.
    /// </summary>
    public struct ChatMessage : IComparable
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the date and time on the message.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the user who sent the message (as determined by McMyAdmin).
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets whether the message is a chat message (as determined by McMyAdmin).
        /// </summary>
        public bool IsChat { get; set; }

        /// <summary>
        /// Gets or sets the timestamp as recieved by McMyAdmin
        /// </summary>
        public long Timestamp { get; set; }

        #endregion

        #region IComparable

        /// <summary>
        /// Implementation of the <see cref="IComparable"/> interface. Allows the chat messages to be sorted by Timestamp.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            // If the object we are comparing to isn't actually there, return 1.
            if (obj == null)
            {
                return 1;
            }

            // The other object should be a ChatMessage.
            ChatMessage otherMessage = (ChatMessage)obj;
            
            // Compare the timestamps.
            return Timestamp.CompareTo(otherMessage.Timestamp);
        }

        #endregion
    }
}
