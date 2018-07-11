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

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// The base class for button icon profiles
    /// </summary>
    public abstract class ButtonIconProfile : ButtonProfile
    {
        [Header("Defaults")]
        /// <summary>
        /// The icon returned when a requested icon is not found
        /// </summary>
        public Texture2D _IconNotFound;

        /// <summary>
        /// How quickly to animate changing icon alpha at runtime
        /// </summary>
        public float AlphaTransitionSpeed = 0.25f;

        /// <summary>
        /// The default material used for icons
        /// </summary>
        public Material IconMaterial;

        /// <summary>
        /// The default mesh used for icons
        /// </summary>
        public Mesh IconMesh;

        /// <summary>
        /// Property used to modify icon alpha
        /// If this is null alpha will not be applied
        /// </summary>
        public string AlphaColorProperty = "_Color";

        /// <summary>
        /// Gets a list of icon names - used primarily by editor scripts
        /// </summary>
        /// <returns></returns>
        public virtual List<string> GetIconKeys()
        {
            return null;
        }
        
        /// <summary>
        /// Searches for an icon
        /// If found, the icon texture is applied to the target renderer's material and the icon mesh is applied to the target mesh filter
        /// A default icon (_IconNotFound_) will be substituted if useDefaultIfNotFound is true
        /// </summary>
        /// <param name="iconName"></param>
        /// <param name="targetRenderer"></param>
        /// <param name="targetMesh"></param>
        /// <param name="useDefaultIfNotFound"></param>
        /// <returns></returns>
        public virtual bool GetIcon(string iconName, MeshRenderer targetRenderer, MeshFilter targetMesh, bool useDefaultIfNotFound)
        {
            return false;
        }        

        #if UNITY_EDITOR
        public virtual string DrawIconSelectField (string iconName)
        {
            iconName = UnityEditor.EditorGUILayout.TextField("Icon name", iconName);
            return iconName;
        }
        #endif
    }
}