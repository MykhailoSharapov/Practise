// <copyright file="Shlist.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Practise
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// my own List named Sharapov LIST.
    /// </summary>
    /// <typeparam name="T">any param.</typeparam>
    public class Shlist<T> : IEnumerable
    {
        private readonly int randMinDelay = 100;
        private readonly int randMaxDelay = 500;
        private T[] source;

        /// <summary>
        /// Initializes a new instance of the <see cref="Shlist{T}"/> class.
        /// </summary>
        public Shlist()
        {
            this.source = new T[1];
        }

        /// <summary>
        /// Gets count of memory which use shlist.
        /// </summary>
        public int Capacity => this.source.Length;

        /// <summary>
        /// Gets elemts count in shlist.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// get current element in shlist.
        /// </summary>
        /// <param name="i">position.</param>
        /// <returns>oject.</returns>
        public T this[int i]
        {
            get
            {
                this.ThrowIfInvalid(i);
                return this.source[i];
            }

            set
            {
                this.ThrowIfInvalid(i);
                this.source[i] = value;
            }
        }

        /// <summary>
        /// my async add.
        /// </summary>
        /// /// <param name="x">some value to add.</param>
        public void AddAsync(T x)
        {
            Task.Run(async () =>
            {
                await Task.Delay(this.GetRandNum());
                this.Add(x);
            });
        }

        /// <summary>
        /// my async addRange.
        /// </summary>
        /// /// <param name="x">some array to add.</param>
        public void AddRangeAsync(T[] x)
        {
            Task.Run(async () =>
            {
                await Task.Delay(this.GetRandNum());
                this.AddRange(x);
            });
        }

        /// <summary>
        /// my async addRange.
        /// </summary>
        /// /// <param name="x">some list to add.</param>
        public void AddRangeAsync(Shlist<T> x)
        {
            Task.Run(async () =>
            {
                await Task.Delay(this.GetRandNum());
                this.AddRange(x);
            });
        }

        /// <summary>
        /// my async addRange.
        /// </summary>
        /// /// <param name="x">some list to add.</param>
        public void AddRangeAsync(List<T> x)
        {
            Task.Run(async () =>
            {
                await Task.Delay(this.GetRandNum());
                this.AddRange(x);
            });
        }

        /// <summary>
        /// my async removeItem.
        /// </summary>
        /// /// <param name="x">some list to add.</param>
        public void RemoveItemAsync(int x)
        {
            Task.Run(async () =>
            {
                await Task.Delay(this.GetRandNum());
                this.RemoveAt(x);
            });
        }

        /// <summary>
        /// MyWhereFunk.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> Where(Func<T, bool> expression)
        {
            return this.ConvertIEnumerableToIReadOnly(this.source.Where(expression));
        }

        /// <summary>
        /// MySelectFunk.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<bool> Select(Func<T, bool> expression) => this.ConvertIEnumerableToIReadOnly(this.source.Select(expression));

        /// <summary>
        /// MyOrderByFunk.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> OrderBy(Func<T, bool> expression) => this.ConvertIEnumerableToIReadOnly(this.source.OrderBy(expression));

        /// <summary>
        /// MyOrderByDescendingFunk.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> OrderByDistinct(Func<T, bool> expression) => this.ConvertIEnumerableToIReadOnly(this.source.OrderByDescending(expression));

        /// <summary>
        /// MyGroupByFunk.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<IGrouping<bool, T>> GroupBy(Func<T, bool> expression) => this.ConvertIGroupingToIReadOnly(this.source.GroupBy(expression));

        /// <summary>
        /// MyReverseFunc.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> Reverse() => this.ConvertIEnumerableToIReadOnly(this.source.Reverse());

        /// <summary>
        /// MyAllFunc.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public bool All(Func<T, bool> expression) => this.source.All(expression);

        /// <summary>
        /// MyAnyFunc.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public bool Any(Func<T, bool> expression) => this.source.Any(expression);

        /// <summary>
        /// MyCountFunc.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public int CountLinQ(Func<T, bool> expression) => this.source.Count(expression);

        /// <summary>
        /// MyTakeFunc.
        /// </summary>
        /// <param name="count">count.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> Take(int count) => this.ConvertIEnumerableToIReadOnly(this.source.Take(count));

        /// <summary>
        /// MySkipFunc.
        /// </summary>
        /// <param name="count">count.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> Skip(int count) => this.ConvertIEnumerableToIReadOnly(this.source.Skip(count));

        /// <summary>
        /// MyCountFunc.
        /// </summary>
        /// <param name="count">count.</param>
        /// <returns>readonlyCollection.</returns>
        public int CountLinQ() => this.source.Count();

        /// <summary>
        /// MyDistinktFunc.
        /// </summary>
        /// <param name="expression">lambda.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> Distinct() => this.ConvertIEnumerableToIReadOnly(this.source.Distinct());

        /// <summary>
        /// MyDistinktFunc.
        /// </summary>
        /// <returns>readonlyCollection.</returns>
        public IEnumerable<T> DistinctEnum() => this.source.Distinct();

        /// <summary>
        /// MyDistinktFunc.
        /// </summary>
        /// <param name="someEnuberable">some enumerable.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> Expect(IEnumerable<T> someEnuberable) => this.ConvertIEnumerableToIReadOnly(this.source.Except(someEnuberable));

        /// <summary>
        /// MyIntersectFunc.
        /// </summary>
        /// <param name="someEnuberable">some enumerable.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> Intersect(IEnumerable<T> someEnuberable) => this.ConvertIEnumerableToIReadOnly(this.source.Intersect(someEnuberable));

        /// <summary>
        /// MyConcatFunc.
        /// </summary>
        /// <param name="someEnuberable">some enumerable.</param>
        /// <returns>readonlyCollection.</returns>
        public IReadOnlyCollection<T> Concat(IEnumerable<T> someEnuberable) => this.ConvertIEnumerableToIReadOnly(this.source.Concat(someEnuberable));

        /// <summary>
        /// MyFirstFunc.
        /// </summary>
        /// <returns>some type.</returns>
        public T First() => this.source.First();

        /// <summary>
        /// MyFirstOrDefaultFunc.
        /// </summary>
        /// <returns>some type.</returns>
        public T FirstOrDefault() => this.source.FirstOrDefault();

        /// <summary>
        /// MySingleFunc.
        /// </summary>
        /// <returns>some type.</returns>
        public T Single() => this.source.Single();

        /// <summary>
        /// MySingleOrDefaultFunc.
        /// </summary>
        /// <returns>some type.</returns>
        public T SingleOrDefault() => this.source.SingleOrDefault();

        /// <summary>
        /// MyElementAtFunc.
        /// </summary>
        /// /// <param name="index">index.</param>
        /// <returns>some type.</returns>
        public T ElementAt(int index) => this.source.ElementAt(index);

        /// <summary>
        /// MyElementAtOrDefaultFunc.
        /// </summary>
        /// /// <param name="index">index.</param>
        /// <returns>some type.</returns>
        public T ElementAtOrDefault(int index) => this.source.ElementAtOrDefault(index);

        /// <summary>
        /// MyLastFunc.
        /// </summary>
        /// <returns>some type.</returns>
        public T Last() => this.source.Last();

        /// <summary>
        /// MyLastOrDefaultFunc.
        /// </summary>
        /// <returns>some type.</returns>
        public T LastOrDefault() => this.source.LastOrDefault();

        /// <summary>
        /// Clone function to copy list.
        /// </summary>
        /// <returns>Shlist.</returns>
        public Shlist<T> CloneAs()
        {
            Shlist<T> list = new Shlist<T>();
            for (var i = 0; i < this.Count; i++)
            {
                list.Add(this.source[i]);
            }

            return list;
        }

        /// <summary>
        /// MyFunkAddSomeRange.
        /// </summary>
        /// <param name="someRange">some range.</param>
        public void AddRange(Shlist<T> someRange)
        {
            foreach (T t in someRange)
            {
                this.Add(t);
            }
        }

        /// <summary>
        /// MyFunkAddSomeRange.
        /// </summary>
        /// <param name="someRange">some range.</param>
        public void AddRange(List<T> someRange)
        {
            foreach (T t in someRange)
            {
                this.Add(t);
            }
        }

        /// <summary>
        /// MyFunkAddSomeRange.
        /// </summary>
        /// <param name="someRange">some range.</param>
        public void AddRange(T[] someRange)
        {
            foreach (T t in someRange)
            {
                this.Add(t);
            }
        }

        /// <summary>
        /// Funk to copy shlist.
        /// </summary>
        /// <returns>return copied shlist.</returns>
        public object Clone() => this.CloneAs();

        /// <summary>
        /// Cut capasity to actual length.
        /// </summary>
        public void TrimExcess() => Array.Resize(ref this.source, this.Count);

        /// <summary>
        /// founding index of input element.
        /// </summary>
        /// <param name="x">founding element.</param>
        /// <returns>position.</returns>
        public int IndexOf(T x)
        {
            int i = 0;
            while ((i < this.Count) && (!this.source[i].Equals(x)))
            {
                i++;
            }

            if (i == this.Count)
            {
                return -1;
            }

            return i;
        }

        /// <summary>
        /// Insert some vale to fixed position.
        /// </summary>
        /// <param name="index">position for input.</param>
        /// <param name="x">object to input.</param>
        public void InsertAt(int index, T x)
        {
            this.ThrowIfInvalid(index);
            this.Insert(index, x);
        }

        /// <summary>
        /// Remove some value in fixed position.
        /// </summary>
        /// <param name="index">position for remove.</param>
        public void RemoveAt(int index)
        {
            this.ThrowIfInvalid(index);
            for (var i = index; i < this.Count - 1; i++)
            {
                this.source[i] = this.source[i + 1];
            }

            this.source[this.Count - 1] = default(T);
            this.Count--;
        }

        /// <summary>
        /// Add element in first position.
        /// </summary>
        /// <param name="x">element to add.</param>
        public void AddFirst(T x) => this.Insert(0, x);

        /// <summary>
        /// element add before some index.
        /// </summary>
        /// <param name="target">position.</param>
        /// <param name="x">element.</param>
        public void AddBefore(T target, T x) => this.InsertAt(this.IndexOf(target) - 1, x);

        /// <summary>
        /// element add in some index.
        /// </summary>
        /// <param name="x">element.</param>
        public void Add(T x) => this.Insert(this.Count, x);

        /// <summary>
        /// element add after some index.
        /// </summary>
        /// <param name="target">position.</param>
        /// <param name="x">element.</param>
        public void AddAfter(T target, T x) => this.InsertAt(this.IndexOf(target) + 1, x);

        /// <summary>
        /// element remove in first position.
        /// </summary>
        public void RemoveFirst() => this.RemoveAt(0);

        /// <summary>
        /// element remove in last position.
        /// </summary>
        public void RemoveLast() => this.RemoveAt(this.Count - 1);

        /// <summary>
        /// element remove before some element.
        /// </summary>
        /// <param name="x">elemnt.</param>
        public void RemoveBefore(T x) => this.RemoveAt(this.IndexOf(x) - 1);

        /// <summary>
        /// element remove.
        /// </summary>
        /// <param name="x">elemnt.</param>
        public void Remove(T x) => this.RemoveAt(this.IndexOf(x));

        /// <summary>
        /// element remove after some element.
        /// </summary>
        /// <param name="x">elemnt.</param>
        public void RemoveAfter(T x) => this.RemoveAt(this.IndexOf(x) + 1);

        /// <summary>
        /// clearList.
        /// </summary>
        public void Clear()
        {
            //Array.Resize(ref this.source, 1);
            this.source = new T[1];
        }

        /// <summary>
        /// sorting.
        /// </summary>
        public void Sort()
        {
            Array.Sort(this.source);
        }

        /// <summary>
        /// get enumerator.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator GetEnumerator() => new MyEnumerator<T>(this.source);

        private void ThrowIfInvalid(int index)
        {
            if ((index < 0) || (index >= this.Count))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private void TryResize()
        {
            this.Count++;
            if (this.source.Length < this.Count)
            {
                Array.Resize(ref this.source, this.source.Length == 0 ? 1 : this.source.Length * 2);
            }
        }

        private void Insert(int index, T x)
        {
            this.TryResize();
            for (var i = this.Count - 1; i > index; i--)
            {
                this.source[i] = this.source[i - 1];
            }

            this.source[index] = x;
        }

        private IReadOnlyCollection<T> ConvertIEnumerableToIReadOnly(IEnumerable<T> collection)
        {
            return collection.ToList().AsReadOnly();
        }

        private IReadOnlyCollection<bool> ConvertIEnumerableToIReadOnly(IEnumerable<bool> collection)
        {
            return collection.ToArray().ToList().AsReadOnly();
        }

        private IReadOnlyCollection<IGrouping<bool, T>> ConvertIGroupingToIReadOnly(IEnumerable<IGrouping<bool, T>> collection)
        {
            return collection.ToList().AsReadOnly();
        }

        private int GetRandNum()
        {
            return new Random().Next(this.randMinDelay, this.randMaxDelay);
        }
    }
}
