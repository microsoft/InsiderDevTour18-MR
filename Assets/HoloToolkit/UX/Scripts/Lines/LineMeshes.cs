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
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace HoloToolkit.Unity.UX
{
    [UseWith(typeof(LineBase))]
    public class LineMeshes : LineRendererBase
    {
        readonly string InvisibleShaderName = "MixedRealityToolkit/InvisibleShader";

        [Header("Instanced Mesh Settings")]
        public Mesh LineMesh;

        public Material LineMaterial;

        [MaterialProperty(MaterialPropertyAttribute.PropertyTypeEnum.Color, "LineMaterial")]
        public string ColorProp = "_Color";

        // Command buffer properties
        private MaterialPropertyBlock linePropertyBlock;
        private int colorID;
        private Matrix4x4[] meshTransforms;
        private Vector4[] colorValues;
        private bool executeCommandBuffer = false;
        private Dictionary<Camera, CommandBuffer> cameras = new Dictionary<Camera, CommandBuffer>();
        // OnWillRenderObject helpers
        private MeshRenderer onWillRenderHelper;
        private Mesh onWillRenderMesh;
        private Material onWillRenderMat;
        private Vector3[] meshVertices = new Vector3[3];

        protected void OnEnable()
        {
            if (LineMaterial == null)
            {
                Debug.LogError("Line material cannot be null.");
                enabled = false;
                return;
            }

            if (linePropertyBlock == null)
            {
                LineMaterial.enableInstancing = true;
                linePropertyBlock = new MaterialPropertyBlock();
                colorID = Shader.PropertyToID(ColorProp);
            }

            if (onWillRenderHelper == null)
            {   // OnWillRenderObject won't be called unless there's a renderer attached
                // and if the renderer's bounds are visible.
                // So we create a simple 1-triangle mesh to ensure it's always called.
                // Hacky, but it works.
                onWillRenderHelper = gameObject.AddComponent<MeshRenderer>();
                onWillRenderHelper.receiveShadows = false;
                onWillRenderHelper.shadowCastingMode = ShadowCastingMode.Off;
                onWillRenderHelper.lightProbeUsage = LightProbeUsage.Off;
                onWillRenderHelper.motionVectorGenerationMode = MotionVectorGenerationMode.ForceNoMotion;

                onWillRenderMesh = new Mesh();
                onWillRenderMesh.vertices = meshVertices;
                onWillRenderMesh.triangles = new int[] { 0, 1, 2 };

                MeshFilter helperMeshFilter = gameObject.AddComponent<MeshFilter>();
                helperMeshFilter.sharedMesh = onWillRenderMesh;

                // Create an 'invisible' material so the mesh doesn't show up pink
                onWillRenderMat = new Material(Shader.Find(InvisibleShaderName));
                onWillRenderHelper.sharedMaterial = onWillRenderMat;
            }
        }

        private void Update()
        {
            executeCommandBuffer = false;

            if (Source.enabled)
            {
                if (meshTransforms == null || meshTransforms.Length != NumLineSteps)
                {
                    meshTransforms = new Matrix4x4[NumLineSteps];
                }

                if (colorValues == null || colorValues.Length != NumLineSteps)
                {
                    colorValues = new Vector4[NumLineSteps];
                    linePropertyBlock.Clear();
                }

                for (int i = 0; i < NumLineSteps; i++)
                {
                    float normalizedDistance = (1f / (NumLineSteps - 1)) * i;
                    colorValues[i] = GetColor(normalizedDistance);
                    meshTransforms[i] = Matrix4x4.TRS(Source.GetPoint(normalizedDistance), Source.GetRotation(normalizedDistance), Vector3.one * GetWidth(normalizedDistance));
                }

                linePropertyBlock.SetVectorArray(colorID, colorValues);

                executeCommandBuffer = true;
            }
        }

        private void OnDisable()
        {
            foreach (KeyValuePair<Camera, CommandBuffer> cam in cameras)
            {
                if (cam.Key != null)
                {
                    cam.Key.RemoveCommandBuffer(CameraEvent.AfterForwardOpaque, cam.Value);
                }
            }
            cameras.Clear();
        }

        private void OnWillRenderObject()
        {
            Camera cam = Camera.current;
            CommandBuffer buffer = null;
            if (!cameras.TryGetValue(cam, out buffer))
            {
                buffer = new CommandBuffer();
                buffer.name = "Line Mesh Renderer " + cam.name;
                cam.AddCommandBuffer(CameraEvent.AfterForwardOpaque, buffer);
                cameras.Add(cam, buffer);
            }

            buffer.Clear();
            if (executeCommandBuffer)
            {
                buffer.DrawMeshInstanced(LineMesh, 0, LineMaterial, 0, meshTransforms, meshTransforms.Length, linePropertyBlock);
            }
        }

        private void LateUpdate()
        {
            // Update our helper mesh so OnWillRenderObject will be called
            meshVertices[0] = transform.InverseTransformPoint(Source.GetPoint(0.0f));// - transform.position;
            meshVertices[1] = transform.InverseTransformPoint(Source.GetPoint(0.5f));// - transform.position;
            meshVertices[2] = transform.InverseTransformPoint(Source.GetPoint(1.0f));// - transform.position;
            onWillRenderMesh.vertices = meshVertices;
            onWillRenderMesh.RecalculateBounds();
        }

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(LineMeshes))]
        public class CustomEditor : MRTKEditor { }
#endif
    }
}