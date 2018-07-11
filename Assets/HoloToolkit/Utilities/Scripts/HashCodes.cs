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

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Provides helper methods for combining hash codes of many properties or objects into an
    /// aggregated hash code.
    /// </summary>
    public static class HashCodes
    {
        public static int Combine(int first, int second)
        {
            // This algorithm is based on .Net 4.6.1's implementation of Tuple.
            return (((first << 5) + first) ^ second);
        }

        // NOTE: The following are generic to avoid boxing structs:

        public static int FromNullable<T1>(T1 toHash)
        {
            return (toHash == null)
                ? 0
                : toHash.GetHashCode();
        }

        public static int Combine<T1, T2>(T1 first, T2 second)
        {
            return Combine(FromNullable(first), FromNullable(second));
        }

        public static int Combine<T1, T2, T3>(T1 first, T2 second, T3 third)
        {
            return Combine(Combine(first, second), FromNullable(third));
        }

        public static int Combine<T1, T2, T3, T4>(T1 first, T2 second, T3 third, T4 fourth)
        {
            return Combine(Combine(first, second, third), FromNullable(fourth));
        }

        public static int Combine<T1, T2, T3, T4, T5>(T1 first, T2 second, T3 third, T4 fourth, T5 fifth)
        {
            return Combine(Combine(first, second, third, fourth), FromNullable(fifth));
        }

        public static int Combine<T1, T2, T3, T4, T5, T6>(T1 first, T2 second, T3 third, T4 fourth, T5 fifth, T6 sixth)
        {
            return Combine(Combine(first, second, third, fourth, fifth), FromNullable(sixth));
        }

        public static int Combine<T1, T2, T3, T4, T5, T6, T7>(T1 first, T2 second, T3 third, T4 fourth, T5 fifth, T6 sixth, T7 seventh)
        {
            return Combine(Combine(first, second, third, fourth, fifth, sixth), FromNullable(seventh));
        }

        public static int Combine<T1, T2, T3, T4, T5, T6, T7, T8>(T1 first, T2 second, T3 third, T4 fourth, T5 fifth, T6 sixth, T7 seventh, T8 eighth)
        {
            return Combine(Combine(first, second, third, fourth, fifth, sixth, seventh), FromNullable(eighth));
        }
    }
}
