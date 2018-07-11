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
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HoloToolkit.Unity
{
    // Indicates which components this class ought to be used with (though are not strictly required)
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class UseWithAttribute : Attribute
    {
        public Type[] UseWithTypes { get; private set; }

        // IL2CPP doesn't support attributes with object arguments that are array types
        public UseWithAttribute(Type useWithType1, Type useWithType2 = null, Type useWithType3 = null, Type useWithType4 = null, Type useWithType5 = null)
        {
            List<Type> types = new List<Type>() { useWithType1 };

            if (useWithType2 != null)
                types.Add(useWithType2);

            if (useWithType3 != null)
                types.Add(useWithType3);

            if (useWithType4 != null)
                types.Add(useWithType4);

            if (useWithType5 != null)
                types.Add(useWithType5);

            UseWithTypes = types.ToArray();
        }
    }
}