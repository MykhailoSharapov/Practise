// <copyright file="LoggerConfigurations.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    /// <summary>
    /// config.
    /// </summary>
    public static class LoggerConfigurations
    {
        /// <summary>
        /// time format.
        /// </summary>
        public static readonly string TimeFormat = "hh:mm:ss";

        /// <summary>
        /// file extension.
        /// </summary>
        public static readonly string FileExtension = ".txt";

        /// <summary>
        /// filemask.
        /// </summary>
        public static readonly string FileNameMask = "hh.mm.ss dd.MM.yyyy";

        /// <summary>
        /// savedlogs.
        /// </summary>
        public static readonly int CountSavedLogs = 3;

        /// <summary>
        /// directoryPath.
        /// </summary>
        public static readonly string DirectoryPath = "Logs\\";

        /// <summary>
        /// directoryPath.
        /// </summary>
        public static readonly string BackUpDirectoryPath = "BackUp\\";

        /// <summary>
        /// daylifes.
        /// </summary>
        public static readonly double FileLifetime = 2;

        static LoggerConfigurations()
        {
            Logger.Instance.LogHandler += Logger.Instance.LogHandlerAction;
        }
    }
}
