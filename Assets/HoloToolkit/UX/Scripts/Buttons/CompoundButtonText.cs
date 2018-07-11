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

using HoloToolkit.Unity;
using UnityEngine;

namespace HoloToolkit.Unity.Buttons
{
    [RequireComponent(typeof(CompoundButton))]
    public class CompoundButtonText : ProfileButtonBase<ButtonTextProfile>
    {
        [DropDownComponent]
        public TextMesh TextMesh;

        /// <summary>
        /// Turn off text entirely
        /// </summary>
        [EditableProp]
        public bool DisableText {
            get {
                return disableText;
            }
            set {
                if (disableText != value) {
                    disableText = value;
                    UpdateStyle();
                }
            }
        }

        [ShowIfBoolValue("DisableText", false)]
        [TextAreaProp(30)]
        public string Text {
            get {
                if (TextMesh == null) {
                    return string.Empty;
                }
                return TextMesh.text;
            }
            set {
                TextMesh.text = value;
            }
        }

        [ShowIfBoolValue("DisableText", false)]
        [RangeProp(0f, 1f)]
        public float Alpha {
            get {
                return alpha;
            }
            set {
                if (value != alpha) {
                    alpha = value;
                    UpdateStyle();
                }
            }
        }

        [ShowIfBoolValue("DisableText", false)]
        [Tooltip("Disregard the text style in the profile")]
        public bool OverrideFontStyle = false;

        [ShowIfBoolValue("OverrideFontStyle")]
        [ShowIfBoolValue("DisableText", false)]
        [Tooltip("Style to use for override.")]
        public FontStyle Style;

        [ShowIfBoolValue("DisableText", false)]
        [Tooltip("Disregard the anchor in the profile.")]
        public bool OverrideAnchor = false;

        [ShowIfBoolValue("OverrideAnchor")]
        [ShowIfBoolValue("DisableText", false)]
        [Tooltip("Anchor to use for override.")]
        public TextAnchor Anchor;

        [ShowIfBoolValue("DisableText", false)]
        [Tooltip("Disregard the size in the profile.")]
        public bool OverrideSize = false;
        
        [ShowIfBoolValue("OverrideSize")]
        [ShowIfBoolValue("DisableText", false)]
        [Tooltip("Size to use for override.")]
        public int Size = 72;

        [ShowIfBoolValue("DisableText", false)]
        [Tooltip("When true, no offset is applied to the text object.")]
        public bool OverrideOffset = false;

        [SerializeField]
        [HideInMRTKInspector]
        private float alpha = 1f;

        [SerializeField]
        [HideInMRTKInspector]
        private bool disableText = false;

        private void OnEnable()
        {
            UpdateStyle();
        }

        private void UpdateStyle()
        {
            if (TextMesh == null)
            {
                Debug.LogWarning("Text mesh was null in CompoundButtonText " + name);
                return;
            }

            if (DisableText)
            {
                TextMesh.gameObject.SetActive(false);
            }
            else
            {
                // Update text based on profile
                if (Profile != null)
                {
                    TextMesh.font = Profile.Font;
                    TextMesh.fontStyle = Profile.Style;
                    TextMesh.fontSize = OverrideSize ? Size : Profile.Size;
                    TextMesh.fontStyle = OverrideFontStyle ? Style : Profile.Style;
                    TextMesh.anchor = OverrideAnchor ? Anchor : Profile.Anchor;
                    TextMesh.alignment = Profile.Alignment;
                    Color c = Profile.Color;
                    c.a = alpha;
                    TextMesh.color = c;

                    // Apply offset
                    if (!OverrideOffset)
                    {
                        TextMesh.transform.localPosition = Profile.GetOffset(TextMesh.anchor);
                    }

                    TextMesh.gameObject.SetActive(true);
                }
            }
        }

        private void OnDrawGizmos ()
        {
            UpdateStyle();
        }

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(CompoundButtonText))]
        public class CustomEditor : MRTKEditor { }
#endif
    }
}