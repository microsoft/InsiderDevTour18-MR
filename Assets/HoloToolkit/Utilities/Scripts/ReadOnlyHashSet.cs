// MIT License
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// A wrapper for <see cref="HashSet{T}"/> that doesn't allow modification of the set. This is
    /// useful for handing out references to a set that is going to be modified internally, without
    /// giving external consumers the opportunity to accidentally modify the set.
    /// </summary>
    public class ReadOnlyHashSet<TElement> :
        ICollection<TElement>,
        IEnumerable<TElement>,
        IEnumerable
    {
        private readonly HashSet<TElement> underlyingSet;

        public ReadOnlyHashSet(HashSet<TElement> underlyingSet)
        {
            Debug.Assert(underlyingSet != null, "underlyingSet cannot be null.");

            this.underlyingSet = underlyingSet;
        }

        public int Count
        {
            get { return underlyingSet.Count; }
        }

        bool ICollection<TElement>.IsReadOnly
        {
            get { return true; }
        }

        void ICollection<TElement>.Add(TElement item)
        {
            throw NewWriteDeniedException();
        }

        void ICollection<TElement>.Clear()
        {
            throw NewWriteDeniedException();
        }

        public bool Contains(TElement item)
        {
            return underlyingSet.Contains(item);
        }

        public void CopyTo(TElement[] array, int arrayIndex)
        {
            underlyingSet.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return underlyingSet.GetEnumerator();
        }

        bool ICollection<TElement>.Remove(TElement item)
        {
            throw NewWriteDeniedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return underlyingSet.GetEnumerator();
        }

        private NotSupportedException NewWriteDeniedException()
        {
            return new NotSupportedException("ReadOnlyHashSet<TElement> is not directly writable.");
        }
    }

    public static class ReadOnlyHashSetRelatedExtensions
    {
        public static ReadOnlyHashSet<TElement> AsReadOnly<TElement>(this HashSet<TElement> set)
        {
            return new ReadOnlyHashSet<TElement>(set);
        }
    }
}
