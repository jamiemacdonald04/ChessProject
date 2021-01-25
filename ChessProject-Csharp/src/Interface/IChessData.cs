// <copyright file="IChessData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Helpers
{
    /// <summary>
    /// Works with files read data.
    /// </summary>
    internal interface IChessData
    {
        /// <summary>
        /// Reads the JSON text file and returns the type object deserialised.
        /// </summary>
        /// <typeparam name="T">The type to return.</typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns>An object of the type that is defined.</returns>
        internal T ReadAndDeserialseIntoType<T>(string filePath);
    }
}
