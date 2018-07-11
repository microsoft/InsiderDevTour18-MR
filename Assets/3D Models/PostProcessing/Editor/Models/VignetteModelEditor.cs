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
    using VignetteMode = VignetteModel.Mode;
    using Settings = VignetteModel.Settings;

    [PostProcessingModelEditor(typeof(VignetteModel))]
    public class VignetteModelEditor : PostProcessingModelEditor
    {
        SerializedProperty m_Mode;
        SerializedProperty m_Color;
        SerializedProperty m_Center;
        SerializedProperty m_Intensity;
        SerializedProperty m_Smoothness;
        SerializedProperty m_Roundness;
        SerializedProperty m_Mask;
        SerializedProperty m_Opacity;
        SerializedProperty m_Rounded;

        public override void OnEnable()
        {
            m_Mode = FindSetting((Settings x) => x.mode);
            m_Color = FindSetting((Settings x) => x.color);
            m_Center = FindSetting((Settings x) => x.center);
            m_Intensity = FindSetting((Settings x) => x.intensity);
            m_Smoothness = FindSetting((Settings x) => x.smoothness);
            m_Roundness = FindSetting((Settings x) => x.roundness);
            m_Mask = FindSetting((Settings x) => x.mask);
            m_Opacity = FindSetting((Settings x) => x.opacity);
            m_Rounded = FindSetting((Settings x) => x.rounded);
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(m_Mode);
            EditorGUILayout.PropertyField(m_Color);

            if (m_Mode.intValue < (int)VignetteMode.Masked)
            {
                EditorGUILayout.PropertyField(m_Center);
                EditorGUILayout.PropertyField(m_Intensity);
                EditorGUILayout.PropertyField(m_Smoothness);
                EditorGUILayout.PropertyField(m_Roundness);
                EditorGUILayout.PropertyField(m_Rounded);
            }
            else
            {
                var mask = (target as VignetteModel).settings.mask;

                // Checks import settings on the mask, offers to fix them if invalid
                if (mask != null)
                {
                    var importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(mask)) as TextureImporter;

                    if (importer != null) // Fails when using an internal texture
                    {
#if UNITY_5_5_OR_NEWER
                        bool valid = importer.anisoLevel == 0
                            && importer.mipmapEnabled == false
                            //&& importer.alphaUsage == TextureImporterAlphaUsage.FromGrayScale
                            && importer.alphaSource == TextureImporterAlphaSource.FromGrayScale
                            && importer.textureCompression == TextureImporterCompression.Uncompressed
                            && importer.wrapMode == TextureWrapMode.Clamp;
#else
                        bool valid = importer.anisoLevel == 0
                            && importer.mipmapEnabled == false
                            && importer.grayscaleToAlpha == true
                            && importer.textureFormat == TextureImporterFormat.Alpha8
                            && importer.wrapMode == TextureWrapMode.Clamp;
#endif

                        if (!valid)
                        {
                            EditorGUILayout.HelpBox("Invalid mask import settings.", MessageType.Warning);

                            GUILayout.Space(-32);
                            using (new EditorGUILayout.HorizontalScope())
                            {
                                GUILayout.FlexibleSpace();
                                if (GUILayout.Button("Fix", GUILayout.Width(60)))
                                {
                                    SetMaskImportSettings(importer);
                                    AssetDatabase.Refresh();
                                }
                                GUILayout.Space(8);
                            }
                            GUILayout.Space(11);
                        }
                    }
                }

                EditorGUILayout.PropertyField(m_Mask);
                EditorGUILayout.PropertyField(m_Opacity);
            }
        }

        void SetMaskImportSettings(TextureImporter importer)
        {
#if UNITY_5_5_OR_NEWER
            importer.textureType = TextureImporterType.SingleChannel;
            //importer.alphaUsage = TextureImporterAlphaUsage.FromGrayScale;
            importer.alphaSource = TextureImporterAlphaSource.FromGrayScale;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
#else
            importer.textureType = TextureImporterType.Advanced;
            importer.grayscaleToAlpha = true;
            importer.textureFormat = TextureImporterFormat.Alpha8;
#endif

            importer.anisoLevel = 0;
            importer.mipmapEnabled = false;
            importer.wrapMode = TextureWrapMode.Clamp;
            importer.SaveAndReimport();
        }
    }
}
