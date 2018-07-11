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

using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Extension methods and helper functions for various math data
    /// </summary>
    public static class MathExtensions
    {
        public static int MostSignificantBit(this int x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);

            return x & ~(x >> 1);
        }

        public static int PowerOfTwoGreaterThanOrEqualTo(this int v)
        {
            if (Mathf.IsPowerOfTwo(v))
            {
                return v;
            }

            return Mathf.NextPowerOfTwo(v);
        }

        public static Int3 PowerOfTwoGreaterThanOrEqualTo(this Int3 v)
        {
            return new Int3(PowerOfTwoGreaterThanOrEqualTo(v.x),
                            PowerOfTwoGreaterThanOrEqualTo(v.y),
                            PowerOfTwoGreaterThanOrEqualTo(v.z));
        }

        public static int CubicToLinearIndex(Int3 ndx, Int3 size)
        {
            return (ndx.x) +
                   (ndx.y * size.x) +
                   (ndx.z * size.x * size.y);
        }

        public static Int3 LinearToCubicIndex(int linearIndex, Int3 size)
        {
            return new Int3((linearIndex / 1) % size.x,
                            (linearIndex / size.x) % size.y,
                            (linearIndex / (size.x * size.y)) % size.z);
        }

        public static Vector3 ClampComponentwise(Vector3 value, Vector3 min, Vector3 max)
        {
            return new Vector3(Mathf.Clamp(value.x, min.x, max.x),
                               Mathf.Clamp(value.y, min.y, max.y),
                               Mathf.Clamp(value.z, min.z, max.z));
        }
    }
}