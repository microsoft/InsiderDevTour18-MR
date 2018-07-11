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
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Interface that is implemented by any class that wishes to influence how an audio source sounds.
    /// </summary>
    public interface IAudioInfluencer
    {
        /// <summary>
        /// Applies an audio effect.
        /// </summary>
        /// <param name="soundEmittingObject">The GameObject on which the effect is to be applied.</param>
        /// <param name="audioSource">The AudioSource that is emitting the sound.</param>
        /// <remarks>
        /// This method has been deprecated. The prefered method to call is ApplyEffect(GameObject).
        /// </remarks>
        [Obsolete("ApplyEffect(GameObject, AudioSource) as been deprecated. Using ApplyEffect(GameObject) is prefered.")]
        void ApplyEffect(GameObject soundEmittingObject, AudioSource audioSource);

        /// <summary>
        /// Applies an audio effect.
        /// </summary>
        /// <param name="soundEmittingObject">The GameObject on which the effect is to be applied.</param>
        void ApplyEffect(GameObject soundEmittingObject);

        /// <summary>
        /// Removes a previously applied audio effect.
        /// </summary>
        /// <param name="soundEmittingObject">The GameObject from which the effect is to be removed.</param>
        /// <param name="audioSource">The AudioSource that is emitting the sound.</param>
        /// <remarks>
        /// This method has been deprecated. The prefered method to call is ApplyEffect(GameObject).
        /// </remarks>
        [Obsolete("RemoveEffect(GameObject, AudioSource) as been deprecated. Using RemoveEffect(GameObject) is prefered.")]
        void RemoveEffect(GameObject soundEmittingObject, AudioSource audioSource);

        /// <summary>
        /// Removes a previously applied audio effect.
        /// </summary>
        /// <param name="soundEmittingObject">The GameObject from which the effect is to be removed.</param>
        void RemoveEffect(GameObject soundEmittingObject);
    }
}