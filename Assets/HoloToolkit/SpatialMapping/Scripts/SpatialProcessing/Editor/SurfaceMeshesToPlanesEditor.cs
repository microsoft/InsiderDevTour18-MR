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

using UnityEditor;

namespace HoloToolkit.Unity.SpatialMapping
{
    /// <summary>
    /// Editor extension class to enable multi-selection of the 'Draw Planes' and 'Destroy Planes' options in the Inspector.
    /// </summary>
    [CustomEditor(typeof(SurfaceMeshesToPlanes))]
    public class SurfaceMeshesToPlanesEditor : Editor
    {
        private SerializedProperty drawPlanesMask;
        private SerializedProperty destroyPlanesMask;

        private void OnEnable()
        {
            drawPlanesMask = serializedObject.FindProperty("drawPlanesMask");
            destroyPlanesMask = serializedObject.FindProperty("destroyPlanesMask");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            drawPlanesMask.intValue = (int)((PlaneTypes)EditorGUILayout.EnumMaskField("Draw Planes",
                (PlaneTypes)drawPlanesMask.intValue));

            destroyPlanesMask.intValue = (int)((PlaneTypes)EditorGUILayout.EnumMaskField("Destroy Planes",
                (PlaneTypes)destroyPlanesMask.intValue));

            serializedObject.ApplyModifiedProperties();
        }
    }
}