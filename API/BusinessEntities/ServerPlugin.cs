// <copyright file="ServerPlugin.cs">
// Copyright (c) 2013. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>

namespace McMyAdminAPI.BusinessEntities
{
    /// <summary>
    /// Describes a plugin.
    /// </summary>
    public class ServerPlugin
    {
        /// <summary>
        /// Gets or sets the name of the plugin.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the version of the plugin.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the description of the plugin.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the author of the plugin.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plugin is enabled or not.
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
