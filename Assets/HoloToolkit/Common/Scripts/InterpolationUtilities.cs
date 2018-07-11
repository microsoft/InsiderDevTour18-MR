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
    /// Static class containing interpolation-related utility functions.
    /// </summary>
    public static class InterpolationUtilities
    {
        #region Exponential Decay

        public static float ExpDecay(float from, float to, float hLife, float dTime)
        {
            return Mathf.Lerp(from, to, ExpCoefficient(hLife, dTime));
        }

        public static Vector2 ExpDecay(Vector2 from, Vector2 to, float hLife, float dTime)
        {
            return Vector2.Lerp(from, to, ExpCoefficient(hLife, dTime));
        }

        public static Vector3 ExpDecay(Vector3 from, Vector3 to, float hLife, float dTime)
        {
            return Vector3.Lerp(from, to, ExpCoefficient(hLife, dTime));
        }

        public static Quaternion ExpDecay(Quaternion from, Quaternion to, float hLife, float dTime)
        {
            return Quaternion.Slerp(from, to, ExpCoefficient(hLife, dTime));
        }

        public static Color ExpDecay(Color from, Color to, float hLife, float dTime)
        {
            return Color.Lerp(from, to, ExpCoefficient(hLife, dTime));
        }


        public static float ExpCoefficient(float hLife, float dTime)
        {
            if (hLife == 0)
                return 1;

            return 1.0f - Mathf.Pow(0.5f, dTime / hLife);
        }

        #endregion
    }
}
