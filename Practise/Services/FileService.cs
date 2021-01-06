// <copyright file="FileService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// FileService created for writing messages to file.
    /// </summary>
    public class FileService
    {
        static SemaphoreSlim sem = new SemaphoreSlim(1, 1);
        private static readonly Lazy<FileService> InstanceValue = new Lazy<FileService>(() => new FileService());
        private readonly string fileName;
        private readonly StreamWriter sw;

        static FileService()
        {
        }

        private FileService()
        {
            this.CheckDirectory();
            this.CheckFilesInDirect();
            this.fileName = this.GetFileName();
            this.sw = new StreamWriter($"{LoggerConfigurations.DirectoryPath}{this.fileName}", true);
        }

        /// <summary>
        /// Gets instance of Logger setting for sigleton pattern release.
        /// </summary>
        public static FileService Instance => InstanceValue.Value;

        /// <summary>
        /// Writing input message in file.
        /// </summary>
        /// <param name="text">input text.</param>
        public void Write(string text)
        {
            sem.Wait();
            this.sw.WriteLine(text);
            sem.Release();
        }

        /// <summary>
        /// Writing input message in file asyncronous.
        /// </summary>
        /// <param name="text">input text.</param>
        public void WriteAsync(string text)
        {
            sem.WaitAsync();
            this.sw.WriteLineAsync(text);
            sem.Release();
        }

        /// <summary>
        /// Writing input message in file asyncronous.
        /// </summary>
        public void WriteBackUp()
        {
            Thread.Sleep(1000);
            File.Copy($"{LoggerConfigurations.DirectoryPath}{this.fileName}", $"{LoggerConfigurations.BackUpDirectoryPath}{this.GetFileName()}");
        }

        private void CheckDirectory()
        {
            if (!Directory.Exists(LoggerConfigurations.DirectoryPath))
            {
                Directory.CreateDirectory(LoggerConfigurations.DirectoryPath);
            }
            if (!Directory.Exists(LoggerConfigurations.BackUpDirectoryPath))
            {
                Directory.CreateDirectory(LoggerConfigurations.BackUpDirectoryPath);
            }
        }

        private void CheckFilesInDirect()
        {
            var filesPath = Directory.GetFiles(LoggerConfigurations.DirectoryPath, $"*{LoggerConfigurations.FileExtension}", SearchOption.TopDirectoryOnly);
            if (filesPath.Length > 0)
            {
                var files = new List<FileInfo>();

                foreach (string path in filesPath)
                {
                    files.Add(new FileInfo(path));
                }

                files.Sort(new FilePathDateComparer());

                for (var i = 0; i < files.Count; i++)
                {
                    if (DateTime.UtcNow - files[i].CreationTimeUtc > TimeSpan.FromDays(LoggerConfigurations.FileLifetime) || i >= LoggerConfigurations.CountSavedLogs - 1)
                    {
                        this.DeleteFile(files[i].FullName);
                    }
                }
            }
        }

        private void DeleteFile(string path)
        {
            File.Delete(path);
        }

        private string GetFileName()
        {
            return $"{DateTime.UtcNow.ToString(LoggerConfigurations.FileNameMask)}{LoggerConfigurations.FileExtension}";
        }
    }
}
