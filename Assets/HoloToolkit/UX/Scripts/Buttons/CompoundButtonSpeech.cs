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
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// This class will automatically link buttons to speech keywords
    /// (Currently disabled)
    /// </summary>
    [RequireComponent (typeof(CompoundButton))]
    public class CompoundButtonSpeech : MonoBehaviour, ISpeechHandler
    {
        public enum KeywordSourceEnum
        {
            None,
            LocalOverride,
            ButtonText,
        }

        /// <summary>
        /// Source of the keyword to be used
        /// By default the text in a CompoundButtonText component will be used
        /// </summary>
        [HideInMRTKInspector]
        public KeywordSourceEnum KeywordSource = KeywordSourceEnum.ButtonText;

        /// <summary>
        /// Keyword used when KeywordSource is set to LocalOverride
        /// </summary>
        [HideInMRTKInspector]
        public string Keyword = string.Empty;

        /// <summary>
        /// Variable to keep track of previous button text in case the button text changes after registration.
        /// </summary>
        private string prevButtonText;

        /// <summary>
        /// The final keyword that is registered with the Keyword Manager
        /// </summary>
        private string keyWord;

        /// <summary>
        /// Have internal member reference to button
        /// </summary>
        private CompoundButton m_button;

        /// <summary>
        /// Have internal member reference to button
        /// </summary>
        private CompoundButtonText m_button_text;

        public void Start ()
        {
            // Disable if no microphone devices are found
            if (Microphone.devices.Length == 0) {
                enabled = false;
                return;
            }

            if (KeywordSource == KeywordSourceEnum.None)
                return;

            keyWord = string.Empty;

            // Assign internal cached components
            m_button = GetComponent<CompoundButton>();
            m_button_text = GetComponent<CompoundButtonText>();

            switch (KeywordSource)
            {
                case KeywordSourceEnum.ButtonText:
                default:
                    keyWord = prevButtonText = m_button_text.Text;
                    break;

                case KeywordSourceEnum.LocalOverride:
                    keyWord = Keyword;
                    break;
            }


        }

        public void Update()
        {
            // Check if Button text has changed. If so, remove previous keyword and add new button text
            if (KeywordSource == KeywordSourceEnum.ButtonText &&
                prevButtonText != null &&
                m_button_text.Text != prevButtonText)
            {
                prevButtonText = m_button_text.Text;
            }
        }

        private void OnDestroy()
        {
            if (string.IsNullOrEmpty(this.keyWord))
                return;

        }

        /// <summary>
        /// On Speech keyword recognizer handle speech event
        /// </summary>
        /// <param name="eventData"></param>
        public void OnSpeechKeywordRecognized(SpeechEventData eventData)
        {
            if (!gameObject.activeSelf || !enabled)
                return;

            if(eventData.RecognizedText.Equals(keyWord))
            {
                // Send a pressed message to the button through the InputManager
                m_button.TriggerClicked();
            }
        }

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(CompoundButtonSpeech))]
        public class CustomEditor : MRTKEditor
        {
            protected override void DrawCustomFooter() {
                CompoundButtonSpeech speechButton = (CompoundButtonSpeech)target;

                bool microphoneEnabled = UnityEditor.PlayerSettings.WSA.GetCapability(UnityEditor.PlayerSettings.WSACapability.Microphone);
                if (!microphoneEnabled) {
                    DrawWarning("Microphone capability not present. Speech recognition will be disabled.");
                    return;
                }

                UnityEditor.EditorGUILayout.LabelField("Keyword source", UnityEditor.EditorStyles.miniBoldLabel);
                speechButton.KeywordSource = (CompoundButtonSpeech.KeywordSourceEnum)UnityEditor.EditorGUILayout.EnumPopup(speechButton.KeywordSource);
                CompoundButtonText text = speechButton.GetComponent<CompoundButtonText>();
                switch (speechButton.KeywordSource) {
                    case CompoundButtonSpeech.KeywordSourceEnum.ButtonText:
                    default:
                        if (text == null) {
                            DrawError("No CompoundButtonText component found.");
                        } else if (string.IsNullOrEmpty(text.Text)) {
                            DrawWarning("No keyword found in button text.");
                        } else {
                            UnityEditor.EditorGUILayout.LabelField("Keyword: " + text.Text);
                        }
                        break;

                    case CompoundButtonSpeech.KeywordSourceEnum.LocalOverride:
                        speechButton.Keyword = UnityEditor.EditorGUILayout.TextField(speechButton.Keyword);
                        break;

                    case CompoundButtonSpeech.KeywordSourceEnum.None:
                        UnityEditor.EditorGUILayout.LabelField("(Speech control disabled)", UnityEditor.EditorStyles.miniBoldLabel);
                        break;
                }
            }

            private void EnableMicrophone() {
                UnityEditor.PlayerSettings.WSA.SetCapability(UnityEditor.PlayerSettings.WSACapability.Microphone, true);
            }

            private void AddText() {
                CompoundButtonSpeech speechButton = (CompoundButtonSpeech)target;
                speechButton.gameObject.AddComponent<CompoundButtonText>();
            }
        }
#endif
    }
}
