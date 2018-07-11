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

using System.Text;
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Extensions for the UnityEngine.LayerMask class.
    /// </summary>
    public static class LayerMaskExtensions
    {
        public const int LayerCount = 32;

        private static string[] layerMaskNames;
        public static string[] LayerMaskNames
        {
            get
            {
                if (layerMaskNames == null)
                {
                    layerMaskNames = new string[LayerCount];
                    for (int layer = 0; layer < LayerCount; ++layer)
                    {
                        layerMaskNames[layer] = LayerMask.LayerToName(layer);
                    }
                }

                return layerMaskNames;
            }
        }

        public static string GetDisplayString(this LayerMask layerMask)
        {
            StringBuilder stringBuilder = null;
            for (int layer = 0; layer < LayerCount; ++layer)
            {
                if ((layerMask & (1 << layer)) != 0)
                {
                    if (stringBuilder == null)
                    {
                        stringBuilder = new StringBuilder();
                    }
                    else
                    {
                        stringBuilder.Append(" | ");
                    }

                    stringBuilder.Append(LayerMaskNames[layer]);
                }
            }

            return stringBuilder == null ? "None" : stringBuilder.ToString();
        }
    }
}