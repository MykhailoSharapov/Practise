// <copyright file="Logger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    using System;

    /// <summary>
    /// Logger class to create log messages.
    /// </summary>
    public class Logger : ILogger
    {
        private const string TimeFormat = "hh:mm:ss";
        private static readonly Logger InstanceValue = new Logger();
        private readonly FileService fileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Construcor of logger need initialize fileservice to work with him.
        /// </summary>
        private Logger()
        {
            this.fileService = FileService.Instance;
        }

        /// <summary>
        /// Gets instance of logger to transfer it in plases where it will uses.
        /// </summary>
        public static Logger Instance => InstanceValue;

        /// <summary>
        /// Funk for write log with level error.
        /// </summary>
        /// <param name="message">text message.</param>
        /// <param name="ex">exception or null.</param>
        public void LogError(string message, Exception ex = null)
        {
            this.Log(LogLevel.Error, ex != null ? $"{message}:{ex}" : message);
        }

        /// <summary>
        /// Funk for write log with level Info.
        /// </summary>
        /// <param name="message">text message.</param>
        public void LogInfo(string message)
        {
            this.Log(LogLevel.Info, message);
        }

        /// <summary>
        /// Funk for write log with level warning.
        /// </summary>
        /// <param name="message">text message.</param>
        public void LogWarning(string message)
        {
            this.Log(LogLevel.Warning, message);
        }

        /// <summary>
        /// universal method for writing all types of messadges.
        /// </summary>
        /// <param name="logLevel">log level look in enums.</param>
        /// <param name="message">text of message.</param>
        public void Log(LogLevel logLevel, string message)
        {
            this.WriteData($"{DateTime.UtcNow.ToString(TimeFormat)}:{logLevel}:{message}");
        }

        private void WriteData(string data)
        {
            this.fileService.Write(data);
            Console.WriteLine(data);
        }
    }
}
