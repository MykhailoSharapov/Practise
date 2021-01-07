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
        private static readonly Lazy<Logger> InstanceValue = new Lazy<Logger>(() => new Logger());
        private static int logMessagesCount;

        static Logger()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Construcor of logger need initialize fileservice to work with him.
        /// </summary>
        private Logger()
        {
        }

        /// <summary>
        /// delegate for messages count.
        /// </summary>
        /// <param name="count">count.</param>
        /// <returns>message.</returns>
        public delegate string LogCountHandler(int count);

        /// <summary>
        /// event for count.
        /// </summary>
        public event LogCountHandler LogHandler;

        /// <summary>
        /// Gets instance of logger to transfer it in plases where it will uses.
        /// </summary>
        public static Logger Instance => InstanceValue.Value;

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
            this.WriteData($"{DateTime.UtcNow.ToString(LoggerConfigurations.TimeFormat)}:{logLevel}:{message}");
        }

        /// <summary>
        /// threepercent.
        /// </summary>
        /// <param name="x">count.</param>
        /// <returns>message.</returns>
        public string LogHandlerAction(int x)
        {
            var result = string.Empty;
            if (x % 3 == 0)
            {
                FileService.Instance.WriteBackUp();
            }

            if (x % 10 == 0)
            {
                result = $"----------------------{x.ToString()} strok-----------------------";
            }

            return result;
        }

        private void WriteData(string data)
        {
            logMessagesCount++;
            FileService.Instance.WriteAsync(data);
            Console.WriteLine(data);
            if (logMessagesCount % 10 == 0)
            {
                var message = this.LogHandler.Invoke(logMessagesCount);
                if (!message.Equals(string.Empty))
                {
                    FileService.Instance.WriteAsync(message);
                }
            }
        }
    }
}
