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
    public sealed class VignetteComponent : PostProcessingComponentRenderTexture<VignetteModel>
    {
        static class Uniforms
        {
            internal static readonly int _Vignette_Color    = Shader.PropertyToID("_Vignette_Color");
            internal static readonly int _Vignette_Center   = Shader.PropertyToID("_Vignette_Center");
            internal static readonly int _Vignette_Settings = Shader.PropertyToID("_Vignette_Settings");
            internal static readonly int _Vignette_Mask     = Shader.PropertyToID("_Vignette_Mask");
            internal static readonly int _Vignette_Opacity  = Shader.PropertyToID("_Vignette_Opacity");
        }

        public override bool active
        {
            get
            {
                return model.enabled
                       && !context.interrupted;
            }
        }

        public override void Prepare(Material uberMaterial)
        {
            var settings = model.settings;
            uberMaterial.SetColor(Uniforms._Vignette_Color, settings.color);

            if (settings.mode == VignetteModel.Mode.Classic)
            {
                uberMaterial.SetVector(Uniforms._Vignette_Center, settings.center);
                uberMaterial.EnableKeyword("VIGNETTE_CLASSIC");
                float roundness = (1f - settings.roundness) * 6f + settings.roundness;
                uberMaterial.SetVector(Uniforms._Vignette_Settings, new Vector4(settings.intensity * 3f, settings.smoothness * 5f, roundness, settings.rounded ? 1f : 0f));
            }
            else if (settings.mode == VignetteModel.Mode.Masked)
            {
                if (settings.mask != null && settings.opacity > 0f)
                {
                    uberMaterial.EnableKeyword("VIGNETTE_MASKED");
                    uberMaterial.SetTexture(Uniforms._Vignette_Mask, settings.mask);
                    uberMaterial.SetFloat(Uniforms._Vignette_Opacity, settings.opacity);
                }
            }
        }
    }
}
