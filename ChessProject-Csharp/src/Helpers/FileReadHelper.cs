// <copyright file="FileReadHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Helpers
{
    using System.IO;

    /// <summary>
    /// Works with files read data.
    /// </summary>
    internal sealed class FileReadHelper : IChessData
    {
        /// <summary>
        /// Reads the JSON text file and returns the type object deserialised.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns>An object of the type that is defined.</returns>
        T IChessData.ReadAndDeserialseIntoType<T>(string filePath)
        {
            string fileData = File.ReadAllText(filePath);
            T deserialisedData = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(
            fileData,
            new Newtonsoft.Json.JsonSerializerSettings
            {
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            });
            return deserialisedData;
        }
    }
}
