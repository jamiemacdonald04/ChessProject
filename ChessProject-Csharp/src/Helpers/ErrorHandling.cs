// <copyright file="ErrorHandling.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Core.Helpers
{
    using System;
    using System.IO;
    using SolarWinds.MSP.Chess.Core.Interface;

    /// <summary>
    /// error handling for the different types of apps.
    /// </summary>
    internal sealed class ErrorHandling : IErrorHandling
    {
        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="exception">Handling exceptions.</param>
        void IErrorHandling.HandleError(Exception exception)
        {
            var doSomthingHere = exception.StackTrace;
        }

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="exception">Handle errors for file not found exceptions.</param>
        void IErrorHandling.HandleError(FileNotFoundException exception)
        {
            var doSomthingHere = exception.StackTrace;
        }
    }
}
