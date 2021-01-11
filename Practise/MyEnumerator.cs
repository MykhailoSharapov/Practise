// <copyright file="MyEnumerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Practise
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// it is my enumerator.
    /// </summary>
    /// <typeparam name="T">some type.</typeparam>
    public class MyEnumerator<T> : IEnumerator
    {
        private T[] collection;
        private int curIndex;
        private T curBox;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyEnumerator{T}"/> class.
        /// </summary>
        /// <param name="source">Some collection.</param>
        public MyEnumerator(T[] source)
        {
            this.collection = source;
            this.curIndex = -1;
            this.curBox = default(T);
        }

        /// <summary>
        /// Gets get current element.
        /// </summary>
        public T Current
        {
            get { return this.curBox; }
        }

        /// <summary>
        /// Gets get esc4che chtoto.
        /// </summary>
        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        /// <summary>
        /// next element.
        /// </summary>
        /// <returns> boolan.</returns>
        public bool MoveNext()
        {
            // Avoids going beyond the end of the collection.
            if (++this.curIndex >= this.collection.Length)
            {
                return false;
            }
            else
            {
                // Set current box to next item in collection.
                this.curBox = this.collection[this.curIndex];
            }

            return true;
        }

        /// <summary>
        /// reset position.
        /// </summary>
        public void Reset() => this.curIndex = -1;

        /// <summary>
        /// dospisab;e.
        /// </summary>
        public void Dispose() => this.Dispose();
    }
}
