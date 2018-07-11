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

using System.IO;
using UnityEditor;
using UnityEngine;
using HoloToolkit.Unity;

namespace HoloToolkit.Sharing
{
    public static class SharingMenu
    {
        [MenuItem("Mixed Reality Toolkit/Sharing Service/Launch Sharing Service", false, 100)]
        public static void LaunchSessionServer()
        {
            string filePathName = @"External\HoloToolkit\Sharing\Server\SharingService.exe";

            if (!File.Exists(filePathName))
            {
                Debug.LogError("Sharing service does not exist at location: " + filePathName);
                Debug.LogError("Please enable the Sharing Service via HoloToolkit -> Configure -> Apply Project Settings.");
                return;
            }

            ExternalProcess.FindAndLaunch(filePathName, @"-local");
        }

        [MenuItem("Mixed Reality Toolkit/Sharing Service/Launch Session Manager", false, 101)]
        public static void LaunchSessionUI()
        {
            string filePathName = @"External\HoloToolkit\Sharing\Tools\SessionManager\x86\SessionManager.UI.exe";

            if (!File.Exists(filePathName))
            {
                Debug.LogError("Session Manager UI does not exist at location: " + filePathName);
                Debug.LogError("Please enable the Sharing Service via HoloToolkit -> Configure -> Apply Project Settings.");
                return;
            }

            ExternalProcess.FindAndLaunch(filePathName);
        }

        [MenuItem("Mixed Reality Toolkit/Sharing Service/Launch Profiler", false, 103)]
        public static void LaunchProfilerX()
        {
            string filePathName = @"External\HoloToolkit\Sharing\Tools\Profiler\x86\ProfilerX.exe";

            if (!File.Exists(filePathName))
            {
                Debug.LogError("Profiler does not exist at location: " + filePathName);
                Debug.LogError("Please enable the Sharing Service via HoloToolkit -> Configure -> Apply Project Settings.");
                return;
            }

            ExternalProcess.FindAndLaunch(filePathName);
        }
    }
}