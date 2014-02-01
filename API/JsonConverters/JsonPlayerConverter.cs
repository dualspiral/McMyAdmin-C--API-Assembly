// <copyright file="IServerCaller.cs">
// Copyright (c) 2013-2014. Licensed under the MIT License.
// <author>Dr Daniel Naylor</author>
// </copyright>
using System;
using System.Collections.Generic;
using McMyAdminAPI.BusinessEntities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McMyAdminAPI.JsonConverters
{
    /// <summary>
    /// Converts from a set of players in JSON to Player objects.
    /// </summary>
    public class JsonPlayerConverter : JsonConverter
    {
        /// <summary>
        /// Indicates whether the object can be converted.
        /// </summary>
        /// <param name="objectType">The <see cref="Type"/> ob object to be converted.</param>
        /// <returns><code>true</code> if the object can be converted.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<Player>).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Reads the Json and deserializes it.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> that reads the object.</param>
        /// <param name="objectType">The <see cref="Type"/> of object to create.</param>
        /// <param name="existingValue">The object that currently exists.</param>
        /// <param name="serializer">The <see cref="JsonSerializer"/> to use.</param>
        /// <returns>The deserialised object.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            // Create the target object. We perform the serialization manually at this step.
            var target = new List<Player>();
            foreach (var obj in jsonObject)
            {
                target.Add(JsonConvert.DeserializeObject<Player>(obj.Value.ToString()));
            }

            return target;
        }

        /// <summary>
        /// Writes the Json to a Json string.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to use.</param>
        /// <param name="value">The object to serialise.</param>
        /// <param name="serializer">The serializer to use.</param>
        /// <remarks>As we are only using this as a deserialisation engine, we don't implement this method.</remarks>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
