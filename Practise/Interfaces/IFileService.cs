// <copyright file="IFileService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    /// <summary>
    /// must have funks!.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Writing input message in file.
        /// </summary>
        /// <param name="text">input text.</param>
        void Write(string text);

        /// <summary>
        /// Delete File.
        /// </summary>
        /// <param name="path">path to file.</param>
        void DeleteFile(string path);

        /// <summary>
        /// Configure Directory, if not exist - create!.
        /// </summary>
        void CheckDirectory();

        /// <summary>
        /// Writing input message in file.
        /// </summary>
        /// <param name="text">input text.</param>
        void WriteData(string data);
    }
}
