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
    /// Structure that defines a timer. A timer can be scheduled through the TimerScheduler.
    /// </summary>
    public struct Timer
    {
        public int Id;

        public static Timer Invalid = new Timer(0);

        public Timer(int id)
        {
            Id = id;
        }

        public bool IsActive
        {
            get
            {
                return (Id != Invalid.Id) && TimerScheduler.Instance.IsTimerActive(this);
            }
        }

        public static Timer Start(float timeSeconds, TimerScheduler.Callback callback, bool loop = false)
        {
            if (TimerScheduler.IsInitialized)
            {
                return TimerScheduler.Instance.StartTimer(timeSeconds, callback, loop);
            }

            return Invalid;
        }

        public static Timer StartNextFrame(TimerScheduler.Callback callback)
        {
            if (TimerScheduler.IsInitialized)
            {
                return TimerScheduler.Instance.StartTimer(0.0f, callback, false, true);
            }

            return Invalid;
        }

        public void Stop()
        {
            if (TimerScheduler.IsInitialized)
            {
                TimerScheduler.Instance.StopTimer(this);
                Id = Invalid.Id;
            }
        }
    }
}