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
using System.ComponentModel;
using System.Linq.Expressions;
using UnityEngine;

namespace HoloToolkit.Unity.SpatialMapping
{
    public static class PropertyChangedEventArgsEx
    {
        public static PropertyChangedEventArgsEx<TProperty> Create<TProperty>(string propertyName, TProperty oldValue, TProperty newValue)
        {
            return new PropertyChangedEventArgsEx<TProperty>(propertyName, oldValue, newValue);
        }

        public static PropertyChangedEventArgsEx<TProperty> Create<TProperty>(Expression<Func<TProperty>> memberGetter, TProperty oldValue, TProperty newValue)
        {
            return new PropertyChangedEventArgsEx<TProperty>(memberGetter, oldValue, newValue);
        }
    }

    [Serializable]
    public class PropertyChangedEventArgsEx<TProperty> : PropertyChangedEventArgs
    {
        public TProperty OldValue { get; private set; }
        public TProperty NewValue { get; private set; }

        public PropertyChangedEventArgsEx(string inPropertyName, TProperty inOldValue, TProperty inNewValue) :
            base(inPropertyName)
        {
            OldValue = inOldValue;
            NewValue = inNewValue;
        }

        public PropertyChangedEventArgsEx(Expression<Func<TProperty>> memberGetter, TProperty inOldValue, TProperty inNewValue) :
            this(GetMemberName(memberGetter), inOldValue, inNewValue)
        {
            // Nothing.
        }

        private static string GetMemberName(Expression<Func<TProperty>> memberGetter)
        {
            Debug.Assert(memberGetter.Body is MemberExpression);

            string memberName = ((MemberExpression)memberGetter.Body).Member.Name;
            return memberName;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} -> {2}",
                PropertyName,
                OldValue,
                NewValue
                );
        }
    }
}
