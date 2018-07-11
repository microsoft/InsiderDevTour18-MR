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
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    public class SceneLauncherButton : MonoBehaviour, IInputClickHandler
    {
        public int SceneIndex { get; set; }

        public string SceneName
        {
            set
            {
                gameObject.name = value;
                textMesh.text = value;
            }
        }

        public Color HighlightedTextColor;

        public GameObject MenuReference;

        public bool EnableDebug;

        private TextMesh textMesh;
        private Color originalTextColor;

        private void Awake()
        {
            textMesh = GetComponentInChildren<TextMesh>();
            Debug.Assert(textMesh != null, "SceneLauncherButton must contain a TextMesh.");
            originalTextColor = textMesh.color;
        }

        private void Update()
        {
            IsHighlighted = GazeManager.Instance.HitObject == gameObject;
        }

        private bool IsHighlighted
        {
            set
            {
                textMesh.color = value ? HighlightedTextColor : originalTextColor;
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (EnableDebug)
            {
                Debug.LogFormat("SceneLauncher: Loading scene {0}: {1}", SceneIndex, SceneManager.GetSceneAt(SceneIndex).name);
            }

            MenuReference.SetActive(false);
            SceneManager.LoadSceneAsync(SceneIndex, LoadSceneMode.Single);
        }
    }
}
