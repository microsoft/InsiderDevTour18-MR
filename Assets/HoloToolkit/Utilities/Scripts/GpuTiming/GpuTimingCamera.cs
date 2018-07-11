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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using UnityEngine;

namespace HoloToolkit.Unity
{
	/// <summary>
	/// Tracks the GPU time spent rendering a camera.
	/// For stereo rendering sampling is made from the beginning of the left eye to the end of the right eye.
	/// </summary>
	public class GpuTimingCamera : MonoBehaviour
	{
		public string TimingTag = "Frame";

		private Camera timingCamera;

		private void Start()
		{
			timingCamera = GetComponent<Camera>();
			Debug.Assert(timingCamera, "GpuTimingComponent must be attached to a Camera.");
		}

		protected void OnPreRender()
		{
			if (timingCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Left || timingCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Mono)
			{
				GpuTiming.BeginSample(TimingTag);
			}
		}

		protected void OnPostRender()
		{
			if (timingCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Right || timingCamera.stereoActiveEye == Camera.MonoOrStereoscopicEye.Mono)
			{
				GpuTiming.EndSample();
			}
		}
	}
}