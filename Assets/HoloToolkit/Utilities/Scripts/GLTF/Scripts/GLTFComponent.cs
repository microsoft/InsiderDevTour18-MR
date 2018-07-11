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

using System.Collections;
using System.IO;
using UnityEngine;

namespace UnityGLTF
{
    /// <summary>
    /// Component to load a GLTF scene with
    /// </summary>
    class GLTFComponent : MonoBehaviour
    {
        public string Url = "";
        public bool Multithreaded = true;
        public bool UseStream = false;

        public int MaximumLod = 300;

        public Shader GLTFStandard = null;
        public Shader GLTFStandardSpecular = null;
        public Shader GLTFConstant = null;

        public bool addColliders = false;

        public Stream GLTFStream = null;

        public bool IsLoaded { get; set; }

        IEnumerator Start()
        {
            GLTFSceneImporter loader = null;

            if (UseStream)
            {
                string fullPath = "";

                if (GLTFStream == null)
                {
                    fullPath = Path.Combine(Application.streamingAssetsPath, Url);
                    GLTFStream = File.OpenRead(fullPath);
                }

                loader = new GLTFSceneImporter(
                    fullPath,
                    GLTFStream,
                    gameObject.transform,
                    addColliders
                    );
            }
            else
            {
                loader = new GLTFSceneImporter(
                    Url,
                    gameObject.transform,
                    addColliders
                    );
            }

            loader.SetShaderForMaterialType(GLTFSceneImporter.MaterialType.PbrMetallicRoughness, GLTFStandard);
            loader.SetShaderForMaterialType(GLTFSceneImporter.MaterialType.KHR_materials_pbrSpecularGlossiness, GLTFStandardSpecular);
            loader.SetShaderForMaterialType(GLTFSceneImporter.MaterialType.CommonConstant, GLTFConstant);
            loader.MaximumLod = MaximumLod;
            yield return loader.Load(-1, Multithreaded);

            if (GLTFStream != null)
            {
#if WINDOWS_UWP
                GLTFStream.Dispose();
#else
                GLTFStream.Close();
#endif

                GLTFStream = null;
            }
            
            IsLoaded = true;
        }

        public IEnumerator WaitForModelLoad()
        {
            while (!IsLoaded)
            {
                yield return null;
            }
        }
    }
}
