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
using UnityEngine.PostProcessing;

namespace UnityEditor.PostProcessing
{
    using Settings = ScreenSpaceReflectionModel.Settings;

    [PostProcessingModelEditor(typeof(ScreenSpaceReflectionModel))]
    public class ScreenSpaceReflectionModelEditor : PostProcessingModelEditor
    {
        struct IntensitySettings
        {
            public SerializedProperty reflectionMultiplier;
            public SerializedProperty fadeDistance;
            public SerializedProperty fresnelFade;
            public SerializedProperty fresnelFadePower;
        }

        struct ReflectionSettings
        {
            public SerializedProperty blendType;
            public SerializedProperty reflectionQuality;
            public SerializedProperty maxDistance;
            public SerializedProperty iterationCount;
            public SerializedProperty stepSize;
            public SerializedProperty widthModifier;
            public SerializedProperty reflectionBlur;
            public SerializedProperty reflectBackfaces;
        }

        struct ScreenEdgeMask
        {
            public SerializedProperty intensity;
        }

        IntensitySettings m_Intensity;
        ReflectionSettings m_Reflection;
        ScreenEdgeMask m_ScreenEdgeMask;

        public override void OnEnable()
        {
            m_Intensity = new IntensitySettings
            {
                reflectionMultiplier = FindSetting((Settings x) => x.intensity.reflectionMultiplier),
                fadeDistance = FindSetting((Settings x) => x.intensity.fadeDistance),
                fresnelFade = FindSetting((Settings x) => x.intensity.fresnelFade),
                fresnelFadePower = FindSetting((Settings x) => x.intensity.fresnelFadePower)
            };

            m_Reflection = new ReflectionSettings
            {
                blendType = FindSetting((Settings x) => x.reflection.blendType),
                reflectionQuality = FindSetting((Settings x) => x.reflection.reflectionQuality),
                maxDistance = FindSetting((Settings x) => x.reflection.maxDistance),
                iterationCount = FindSetting((Settings x) => x.reflection.iterationCount),
                stepSize = FindSetting((Settings x) => x.reflection.stepSize),
                widthModifier = FindSetting((Settings x) => x.reflection.widthModifier),
                reflectionBlur = FindSetting((Settings x) => x.reflection.reflectionBlur),
                reflectBackfaces = FindSetting((Settings x) => x.reflection.reflectBackfaces)
            };

            m_ScreenEdgeMask = new ScreenEdgeMask
            {
                intensity = FindSetting((Settings x) => x.screenEdgeMask.intensity)
            };
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("This effect only works with the deferred rendering path.", MessageType.Info);

            EditorGUILayout.LabelField("Reflection", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(m_Reflection.blendType);
            EditorGUILayout.PropertyField(m_Reflection.reflectionQuality);
            EditorGUILayout.PropertyField(m_Reflection.maxDistance);
            EditorGUILayout.PropertyField(m_Reflection.iterationCount);
            EditorGUILayout.PropertyField(m_Reflection.stepSize);
            EditorGUILayout.PropertyField(m_Reflection.widthModifier);
            EditorGUILayout.PropertyField(m_Reflection.reflectionBlur);
            EditorGUILayout.PropertyField(m_Reflection.reflectBackfaces);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Intensity", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(m_Intensity.reflectionMultiplier);
            EditorGUILayout.PropertyField(m_Intensity.fadeDistance);
            EditorGUILayout.PropertyField(m_Intensity.fresnelFade);
            EditorGUILayout.PropertyField(m_Intensity.fresnelFadePower);
            EditorGUI.indentLevel--;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Screen Edge Mask", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(m_ScreenEdgeMask.intensity);
            EditorGUI.indentLevel--;
        }
    }
}
