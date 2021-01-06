// <copyright file="FileService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// FileService created for writing messages to file.
    /// </summary>
    public class FileService
    {
        private const string FileExtension = ".txt";
        private const string FileNameMask = "hh.mm.ss dd.MM.yyyy";
        private const int CountSavedLogs = 3;
        private const string DirectoryPath = "Logs\\";
        private static readonly FileService InstanceValue = new FileService();
        private readonly string fileName;
        private readonly double fileLifetime = 2;
        private readonly StreamWriter sw;

        static FileService()
        {
        }

        private FileService()
        {
            this.CheckDirectory();
            this.CheckFilesInDirect();
            this.fileName = $"{DateTime.UtcNow.ToString(FileNameMask)}{FileExtension}";
            this.sw = new StreamWriter($"{DirectoryPath}{this.fileName}", true);
        }

        /// <summary>
        /// Gets instance of Logger setting for sigleton pattern release.
        /// </summary>
        public static FileService Instance => InstanceValue;

        /// <summary>
        /// Writing input message in file.
        /// </summary>
        /// <param name="text">input text.</param>
        public void Write(string text)
        {
            // File.AppendAllText($"{DirectoryPath}{this.fileName}", text);
            this.sw.WriteLine(text);
        }

        private void CheckDirectory()
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
        }

        private void CheckFilesInDirect()
        {
            var filesPath = Directory.GetFiles(DirectoryPath, $"*{FileExtension}", SearchOption.TopDirectoryOnly);
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
                    if (DateTime.UtcNow - files[i].CreationTimeUtc > TimeSpan.FromDays(this.fileLifetime) || i >= CountSavedLogs - 1)
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
    }
}
