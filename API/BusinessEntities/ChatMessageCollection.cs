// <copyright file="ChatMessageCollection.cs">
// Copyright (c) 2014. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace McMyAdminAPI.BusinessEntities
{
    /// <summary>
    /// Returns a <see cref="ReadOnlyCollection{T}"/> of <see cref="ChatMessage"/> objects, along with
    /// metadata.
    /// </summary>
    public class ChatMessageCollection : ReadOnlyCollection<ChatMessage>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ChatMessageCollection"/> class.
        /// </summary>
        /// <param name="chatMessages">The list of chat messages.</param>
        /// <param name="startingTimestamp">The timestamp used to make the request to generate this object.</param>
        public ChatMessageCollection(IList<ChatMessage> chatMessages, long startingTimestamp)
            : base(chatMessages)
        {
            this.MinimumTimestamp = startingTimestamp;
            if (chatMessages.Count > 0)
            {
                this.LastTimestamp = chatMessages.Select(x => x.Timestamp).Max();
            }
            else
            {
                this.LastTimestamp = startingTimestamp;
            }
        }

        /// <summary>
        /// Gets the timestamp that was used to request the messages. No <see cref="ChatMessage"/> should have a timestamp lower than this.
        /// </summary>
        public long MinimumTimestamp { get; private set; }

        /// <summary>
        /// Gets the latest timestamp in the collection. If this and <seealso cref="MinimumTimestamp"/> are the same, it is likely no
        /// <see cref="ChatMessage"/>s were returned.
        /// </summary>
        public long LastTimestamp { get; private set; }
    }
}
