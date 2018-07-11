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

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// A convenient way to play sounds in response to button actions / states
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ButtonSounds : MonoBehaviour
    {
        const float MinTimeBetweenSameClip = 0.1f;

        // Direct interaction clips
        public AudioClip ButtonCanceled;
        public AudioClip ButtonHeld;
        public AudioClip ButtonPressed;
        public AudioClip ButtonReleased;

        // State change clips
        public AudioClip ButtonObservation;
        public AudioClip ButtonObservationTargeted;
        public AudioClip ButtonTargeted;

        private AudioSource audioSource;
        private static string lastClipName;
        private static float lastClipTime;

        void Start ()
        {
            Button button = GetComponent<Button>();
            button.OnButtonCanceled += OnButtonCanceled;
            button.OnButtonHeld += OnButtonHeld;
            button.OnButtonPressed += OnButtonPressed;
            button.OnButtonReleased += OnButtonReleased;
            button.StateChange += StateChange;

            audioSource = GetComponent<AudioSource>();
        }

        void StateChange(ButtonStateEnum newState)
        {
            switch (newState)
            {
                case ButtonStateEnum.Observation:
                    PlayClip(ButtonObservation);
                    break;

                case ButtonStateEnum.ObservationTargeted:
                    PlayClip(ButtonObservationTargeted);
                    break;

                case ButtonStateEnum.Targeted:
                    PlayClip(ButtonTargeted);
                    break;

                default:
                    break;
            }
        }

        void OnButtonCanceled(GameObject go)
        {
            PlayClip(ButtonCanceled);
        }

        void OnButtonHeld(GameObject go)
        {
            PlayClip(ButtonHeld);
        }

        void OnButtonPressed(GameObject go)
        {
            PlayClip(ButtonPressed);
        }

        void OnButtonReleased (GameObject go)
        {
            PlayClip(ButtonReleased);
        }

        void PlayClip (AudioClip clip)
        {
            if (clip != null)
            {
                // Don't play the clip if we're spamming it
                if (clip.name == lastClipName && (lastClipTime - Time.realtimeSinceStartup) < MinTimeBetweenSameClip)
                    return;

                lastClipName = clip.name;
                lastClipTime = Time.realtimeSinceStartup;
                if (audioSource != null)
                {
                    audioSource.PlayOneShot(clip);
                }
                else
                {
                    AudioSource.PlayClipAtPoint(clip, transform.position);
                }
            }
        }
    }
}