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
    /// A behaviour designed to help child behaviours take certain actions only after Start has been called.
    /// </summary>
    [Obsolete]
    public abstract class StartAwareBehaviour : MonoBehaviour
    {
        #region MonoBehaviour implementation

        protected virtual void OnEnable()
        {
            if (IsStarted)
            {
                OnEnableAfterStart();
            }
        }

        protected virtual void OnDisable()
        {
            if (IsStarted)
            {
                OnDisableAfterStart();
            }
        }

        protected virtual void Start()
        {
            IsStarted = true;
            OnEnableAfterStart();
        }

        #endregion

        protected bool IsStarted { get; private set; }

        /// <summary>
        /// This method is similar to Unity's OnEnable method, except that it's called only after Start. This
        /// means all <see cref="Singleton{T}"/> classes will have had a chance to run their Awake methods and
        /// <see cref="Singleton{T}.Instance"/> will be safe to use.
        /// </summary>
        protected virtual void OnEnableAfterStart()
        {
            Debug.Assert(IsStarted, "OnEnableAfterStart should only occur after Start.");
        }

        /// <summary>
        /// This method is similar to Unity's OnDisable method, except that it's called only after Start. This
        /// means all <see cref="Singleton{T}"/> classes will have had a chance to run their Awake methods and
        /// <see cref="Singleton{T}.Instance"/> will be safe to use.
        /// </summary>
        protected virtual void OnDisableAfterStart()
        {
            Debug.Assert(IsStarted, "OnDisableAfterStart should only occur after Start.");
        }
    }
}
