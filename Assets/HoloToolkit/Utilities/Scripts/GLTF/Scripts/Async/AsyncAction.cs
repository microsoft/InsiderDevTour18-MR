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
#if WINDOWS_UWP
using System.Threading.Tasks;
#else
using System.Threading;
#endif

namespace UnityGLTF
{
    /// <summary>
    /// Creates a thread to run multithreaded operations on
    /// </summary>
    public class AsyncAction
    {
        private bool _workerThreadRunning = false;
        private Exception _savedException;

        public IEnumerator RunOnWorkerThread(Action action)
        {
            _workerThreadRunning = true;

#if WINDOWS_UWP
            Task.Factory.StartNew(() =>
#else
            ThreadPool.QueueUserWorkItem((_) =>
#endif
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    _savedException = e;
                }

                _workerThreadRunning = false;
            });

            yield return Wait();

            if (_savedException != null)
            {
                throw _savedException;
            }
        }

        private IEnumerator Wait()
        {
            while (_workerThreadRunning)
            {
                yield return null;
            }
        }
    }
}
