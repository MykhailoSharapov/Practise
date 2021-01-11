// <copyright file="FilePathDateComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Custom data comparer for sorting file names via date.
    /// </summary>
    public class FilePathDateComparer : IComparer<FileInfo>
    {
        /// <summary>
        /// funk for compairing filepath via date.
        /// </summary>
        /// <param name="x">first date.</param>
        /// <param name="y">second date.</param>
        /// <returns>int result of compairing.</returns>
        public int Compare(FileInfo x, FileInfo y)
        {
            if (x.CreationTimeUtc < y.CreationTimeUtc)
            {
                return 1;
            }
            else if (x.CreationTimeUtc > y.CreationTimeUtc)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
