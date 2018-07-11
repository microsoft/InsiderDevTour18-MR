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
    /// The AudioSourcesReference class encapsulates a cache of references to audio source components on a given
    /// local audio emitter game object. Used primarily by UAudioManager, it improves performance by bypassing
    /// having to requery for list of attached components on each use.
    /// </summary>
    public class AudioSourcesReference : MonoBehaviour
    {
        private List<AudioSource> audioSources;
        public List<AudioSource> AudioSources
        {
            get
            {
                return audioSources;
            }
        }

        public AudioSource AddNewAudioSource()
        {
            var source = this.gameObject.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.dopplerLevel = 0f;
            source.enabled = false;
            audioSources.Add(source);
            return source;
        }

        private void Awake()
        {
            audioSources = new List<AudioSource>();
            foreach (AudioSource audioSource in GetComponents<AudioSource>())
            {
                audioSources.Add(audioSource);
            }
        }

        private void OnDestroy()
        {
            // AudioSourcesReference created all these components and nothing else should use them.
            foreach (AudioSource audioSource in audioSources)
            {
                Object.Destroy(audioSource);
            }

            audioSources = null;
        }
    }
}