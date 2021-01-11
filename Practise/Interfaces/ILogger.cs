// <copyright file="ILogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    using System;

    /// <summary>
    /// Must have functions.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Funk for write log with level error.
        /// </summary>
        /// <param name="message">text message.</param>
        /// <param name="ex">exception or null.</param>
        void LogError(string message, Exception ex = null);

        /// <summary>
        /// Funk for write log with level Info.
        /// </summary>
        /// <param name="message">text message.</param>
        void LogInfo(string message);

        /// <summary>
        /// Funk for write log with level warning.
        /// </summary>
        /// <param name="message">text message.</param>
        void LogWarning(string message);

        /// <summary>
        /// universal method for writing all types of messadges.
        /// </summary>
        /// <param name="logLevel">log level look in enums.</param>
        /// <param name="message">text of message.</param>
        void Log(LogLevel logLevel, string message);
    }
}
