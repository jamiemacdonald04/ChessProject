// <copyright file="IntegerHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SolarWinds.MSP.Chess.Helpers
{
    /// <summary>
    /// Help with some integer parsing.
    /// </summary>
    public static class IntegerHelper
    {
        /// <summary>
        /// Parses the string as integer or zero.
        /// </summary>
        /// <param name="stringToParse">The string to parse.</param>
        /// <returns>an zero integer if it is not an integer.</returns>
        public static int ParseStringAsIntegerOrZero(string stringToParse)
        {
            int.TryParse(stringToParse, out int parsedInteger);
            return parsedInteger;
        }
    }
}
