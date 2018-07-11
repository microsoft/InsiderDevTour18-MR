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

namespace UnityEngine.PostProcessing
{
    public sealed class ChromaticAberrationComponent : PostProcessingComponentRenderTexture<ChromaticAberrationModel>
    {
        static class Uniforms
        {
            internal static readonly int _ChromaticAberration_Amount   = Shader.PropertyToID("_ChromaticAberration_Amount");
            internal static readonly int _ChromaticAberration_Spectrum = Shader.PropertyToID("_ChromaticAberration_Spectrum");
        }

        Texture2D m_SpectrumLut;

        public override bool active
        {
            get
            {
                return model.enabled
                       && model.settings.intensity > 0f
                       && !context.interrupted;
            }
        }

        public override void OnDisable()
        {
            GraphicsUtils.Destroy(m_SpectrumLut);
            m_SpectrumLut = null;
        }

        public override void Prepare(Material uberMaterial)
        {
            var settings = model.settings;
            var spectralLut = settings.spectralTexture;

            if (spectralLut == null)
            {
                if (m_SpectrumLut == null)
                {
                    m_SpectrumLut = new Texture2D(3, 1, TextureFormat.RGB24, false)
                    {
                        name = "Chromatic Aberration Spectrum Lookup",
                        filterMode = FilterMode.Bilinear,
                        wrapMode = TextureWrapMode.Clamp,
                        anisoLevel = 0,
                        hideFlags = HideFlags.DontSave
                    };

                    var pixels = new Color[3];
                    pixels[0] = new Color(1f, 0f, 0f);
                    pixels[1] = new Color(0f, 1f, 0f);
                    pixels[2] = new Color(0f, 0f, 1f);
                    m_SpectrumLut.SetPixels(pixels);
                    m_SpectrumLut.Apply();
                }

                spectralLut = m_SpectrumLut;
            }

            uberMaterial.EnableKeyword("CHROMATIC_ABERRATION");
            uberMaterial.SetFloat(Uniforms._ChromaticAberration_Amount, settings.intensity * 0.03f);
            uberMaterial.SetTexture(Uniforms._ChromaticAberration_Spectrum, spectralLut);
        }
    }
}
