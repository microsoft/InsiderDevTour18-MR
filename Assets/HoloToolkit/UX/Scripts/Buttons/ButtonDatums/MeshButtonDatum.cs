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

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// Mesh Button State Data Set
    /// </summary>
    [Serializable]
    public class MeshButtonDatum
    {
        /// <summary>
        /// Constructor for mesh button datum
        /// </summary>
        public MeshButtonDatum(ButtonStateEnum state) { this.ActiveState = state; this.Name = state.ToString(); }

        /// <summary>
        /// Name string for datum entry
        /// </summary>
        public string Name;
        /// <summary>
        /// Button state the datum is active in
        /// </summary>
        public ButtonStateEnum ActiveState = ButtonStateEnum.Observation;
        /// <summary>
        /// Button mesh color to use in active state
        /// </summary>
        public Color StateColor = Color.white;
        /// <summary>
        /// Offset to translate mesh to in active state.
        /// </summary>
        public Vector3 Offset;
        /// <summary>
        /// Scale for mesh button in active state
        /// </summary>
        public Vector3 Scale;
    }
}
