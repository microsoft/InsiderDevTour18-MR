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

using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Script to control writing the Debug.Log output to a control.
    /// </summary>
    public class DebugPanel : SingleInstance<DebugPanel>
    {
        /// <summary>
        /// The text mesh we will write log messages to
        /// </summary>
        private TextMesh textMesh;

        /// <summary>
        /// Using two queues, one for the current frame and one for the next frame
        /// </summary>
        private Queue<string> logMessages = new Queue<string>();
        private Queue<string> nextLogMessages = new Queue<string>();

        /// <summary>
        /// Track the max # of log messages we will allow in our Queue
        /// </summary>
        private int maxLogMessages = 30;

        /// <summary>
        /// If another script wants to make a log entry per frame they will implement this delegate.
        /// </summary>
        /// <returns></returns>
        public delegate string GetLogLine();

        /// <summary>
        /// A list of GetLogLine delegates to call for per frame information.
        /// </summary>
        private List<GetLogLine> externalLogs = new List<GetLogLine>();

        private void Awake()
        {
            textMesh = GetComponent<TextMesh>();
            Application.logMessageReceivedThreaded += Application_logMessageReceivedThreaded;
        }

        private void Update()
        {
            string logMessageString = CalculateLogMessageString();
            textMesh.text = logMessageString;
        }

        /// <summary>
        /// Formats the log messages into a string
        /// </summary>
        /// <returns>The formatted string</returns>
        private string CalculateLogMessageString()
        {
            string logMessageString = "Per Frame Data:\n------\n";
            for (int index = 0; index < externalLogs.Count; index++)
            {
                string nextExternalLine = externalLogs[index]();
                if (!string.IsNullOrEmpty(nextExternalLine))
                {
                    logMessageString += string.Format("{0}\n", nextExternalLine);
                }
            }

            logMessageString += "------\n";

            lock (logMessages)
            {
                while (logMessages.Count > 0)
                {
                    string nextMessage = logMessages.Dequeue();
                    logMessageString += string.Format("{0}\n", nextMessage);
                    // for the next frame...
                    nextLogMessages.Enqueue(nextMessage);
                }

                Queue<string> tmp = logMessages;
                logMessages = nextLogMessages;
                nextLogMessages = tmp;
                nextLogMessages.Clear();
            }

            return logMessageString;
        }

        /// <summary>
        /// Called when the application calls Debug.Log and friends
        /// </summary>
        /// <param name="condition">The message</param>
        /// <param name="stackTrace">The stack trace</param>
        /// <param name="type">The type of log</param>
        private void Application_logMessageReceivedThreaded(string condition, string stackTrace, LogType type)
        {
            LogCallback(condition, stackTrace, type);
        }

        private void LogCallback(string message, string stack, LogType logType)
        {
            lock (logMessages)
            {
                while (logMessages.Count > maxLogMessages)
                {
                    logMessages.Dequeue();
                }

                logMessages.Enqueue(message);
                if (logType != LogType.Log)
                {
                    // Also add the stack. This will push us beyond our max messages, but it is a soft limit, 
                    // and the stack information is valuable in error/warning cases.
                    logMessages.Enqueue(stack);
                }
            }
        }

        /// <summary>
        /// Call this to register your script to provide a debug string each frame.
        /// </summary>
        /// <param name="callback">The delegate to call back</param>
        public void RegisterExternalLogCallback(GetLogLine callback)
        {
            externalLogs.Add(callback);
        }

        /// <summary>
        /// Call this when you no longer want to provide a debug string each frame.
        /// </summary>
        /// <param name="callback">The callback to stop calling</param>
        public void UnregisterExternalLogCallback(GetLogLine callback)
        {
            if (externalLogs.Contains(callback))
            {
                externalLogs.Remove(callback);
            }
        }
    }
}