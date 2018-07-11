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

#if UNITY_WSA
#if UNITY_2017_2_OR_NEWER
using UnityEngine.XR.WSA;
#else
using UnityEngine.VR;
using UnityEngine.VR.WSA;
#endif
#endif

namespace HoloToolkit.Unity
{
    public class FadeManager : Singleton<FadeManager>
    {
        [Tooltip("If true, the FadeManager will update the shared material. Useful for fading multiple cameras that each render different layers.")]
        public bool FadeSharedMaterial;

        private Material fadeMaterial;
        private Color fadeColor = Color.black;

        private enum FadeState
        {
            idle = 0,
            fadingOut,
            FadingIn
        }

        public bool Busy
        {
            get
            {
                return currentState != FadeState.idle;
            }
        }

        private FadeState currentState;
        private float startTime;
        private float fadeOutTime;
        private Action fadeOutAction;
        private float fadeInTime;
        private Action fadeInAction;

        protected override void Awake()
        {
            // We want to check before calling base Awake
#if UNITY_WSA
#if UNITY_2017_2_OR_NEWER
            if (!HolographicSettings.IsDisplayOpaque)
#else
            if (VRDevice.isPresent)
#endif
            {
                Destroy(gameObject);
                return;
            }
#endif

            base.Awake();

            currentState = FadeState.idle;
            fadeMaterial = FadeSharedMaterial
                ? GetComponentInChildren<MeshRenderer>().sharedMaterial
                : GetComponentInChildren<MeshRenderer>().material;
        }

        private void Update()
        {
            if (Busy)
            {
                CalculateFade();
            }
        }

        private void CalculateFade()
        {
            float actionTime = currentState == FadeState.fadingOut ? fadeOutTime : fadeInTime;
            float timeBusy = Time.realtimeSinceStartup - startTime;
            float timePercentUsed = timeBusy / actionTime;
            if (timePercentUsed >= 1.0f)
            {
                Action callback = currentState == FadeState.fadingOut ? fadeOutAction : fadeInAction;
                if (callback != null)
                {
                    callback();
                }

                fadeColor.a = currentState == FadeState.fadingOut ? 1 : 0;
                fadeMaterial.color = fadeColor;

                currentState = currentState == FadeState.fadingOut ? FadeState.FadingIn : FadeState.idle;
                startTime = Time.realtimeSinceStartup;
            }
            else
            {
                fadeColor.a = currentState == FadeState.fadingOut ? timePercentUsed : 1 - timePercentUsed;
                fadeMaterial.color = fadeColor;
            }
        }

        protected override void OnDestroy()
        {
            if (fadeMaterial != null && !FadeSharedMaterial)
            {
                Destroy(fadeMaterial);
            }

            base.OnDestroy();
        }

        public bool DoFade(float _fadeOutTime, float _fadeInTime, Action _fadedOutAction, Action _fadedInAction)
        {
            if (Busy)
            {
                Debug.Log("Already fading");
                return false;
            }

            fadeOutTime = _fadeOutTime;
            fadeOutAction = _fadedOutAction;
            fadeInTime = _fadeInTime;
            fadeInAction = _fadedInAction;

            startTime = Time.realtimeSinceStartup;
            currentState = FadeState.fadingOut;
            return true;
        }
    }
}
