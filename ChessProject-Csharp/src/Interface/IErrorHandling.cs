// <copyright file="IErrorHandling.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Interface
{
    using System;
    using System.IO;

    /// <summary>
    /// interface for handling errors.
    /// </summary>
    internal interface IErrorHandling
    {
        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="exception">Handling exceptions.</param>
        internal void HandleError(Exception exception);

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="exception">Handles file not found exceptions.</param>
        internal void HandleError(FileNotFoundException exception);
    }
}
