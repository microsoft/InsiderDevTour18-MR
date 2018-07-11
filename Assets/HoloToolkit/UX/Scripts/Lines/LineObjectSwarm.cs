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

namespace HoloToolkit.Unity.UX
{
    [ExecuteInEditMode]
    public class LineObjectSwarm : MonoBehaviour
    {
        const int RandomValueResolution = 1024;

        public List<Transform> Objects = new List<Transform>();

        [Range(0, 100)]
        public int Seed = 0;

        [SerializeField]
        private LineBase source;

        [Header("Noise Settings")]
        public float ScaleMultiplier = 10f;
        public float SpeedMultiplier = 1f;
        public float StrengthMultiplier = 0.5f;
        public Vector3 AxisStrength = Vector3.one;
        public Vector3 AxisSpeed = Vector3.one;
        public Vector3 AxisOffset = Vector3.zero;

        private Vector3[] prevPoints;
        private System.Random randomPosition;
        private System.Random randomRotation;
        private FastSimplexNoise noise = new FastSimplexNoise();

        [Header("Swarm Settings")]
        [Range(0f, 1f)]
        public float NormalizedDistance = 0f;

        public Vector3 SwarmScale = Vector3.one;

        public AnimationCurve ObjectScale = AnimationCurve.Linear(0f, 1f, 1f, 1f);

        public AnimationCurve ObjectOffset = AnimationCurve.Linear(0f, 0f, 1f, 0f);

        public RotationTypeEnum RotationTypeOverride = RotationTypeEnum.None;

        public bool SwarmVelocities = true;

        public float VelocityBlend = 0.5f;

        public Vector3 RotationOffset = Vector3.zero;

        public Vector3 AxisScale = Vector3.one;

        public virtual LineBase Source
        {
            get
            {
                if (source == null)
                {
                    source = GetComponent<LineBase>();
                }
                return source;
            }
            set
            {
                source = value;
                if (source == null)
                {
                    enabled = false;
                }
            }
        }

        public Vector3 GetRandomPoint()
        {
            Vector3 randomPoint = Vector3.one;
            randomPoint.x = (float)randomPosition.Next(-RandomValueResolution, RandomValueResolution) / (RandomValueResolution * 2);
            randomPoint.y = (float)randomPosition.Next(-RandomValueResolution, RandomValueResolution) / (RandomValueResolution * 2);
            randomPoint.z = (float)randomPosition.Next(-RandomValueResolution, RandomValueResolution) / (RandomValueResolution * 2);

            return Vector3.Scale(randomPoint, SwarmScale);
        }

        public void Update()
        {
            UpdateCollection();

#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(gameObject);
#endif
        }

        public void UpdateCollection()
        {
            if (Source == null)
            {
                return;
            }

            if (prevPoints == null || prevPoints.Length != Objects.Count)
            {
                prevPoints = new Vector3[Objects.Count];
            }

            randomPosition = new System.Random(Seed);
            Vector3 linePoint = source.GetPoint(NormalizedDistance);
            Quaternion lineRotation = source.GetRotation(NormalizedDistance, RotationTypeOverride);

            for (int i = 0; i < Objects.Count; i++)
            {
                if (Objects[i] == null)
                {
                    continue;
                }

                Vector3 point = source.transform.TransformVector(GetRandomPoint());
                point.x = (float)(point.x + (noise.Evaluate((point.x + AxisOffset.x) * ScaleMultiplier, Time.unscaledTime * AxisSpeed.x * SpeedMultiplier)) * AxisStrength.x * StrengthMultiplier);
                point.y = (float)(point.y + (noise.Evaluate((point.y + AxisOffset.y) * ScaleMultiplier, Time.unscaledTime * AxisSpeed.y * SpeedMultiplier)) * AxisStrength.y * StrengthMultiplier);
                point.z = (float)(point.z + (noise.Evaluate((point.z + AxisOffset.z) * ScaleMultiplier, Time.unscaledTime * AxisSpeed.z * SpeedMultiplier)) * AxisStrength.z * StrengthMultiplier);

                Objects[i].position = point + linePoint;
                if (SwarmVelocities)
                {
                    Vector3 velocity = prevPoints[i] - point;
                    Objects[i].rotation = Quaternion.Lerp(lineRotation, Quaternion.LookRotation(velocity, Vector3.up), VelocityBlend);
                }
                else
                {
                    Objects[i].rotation = lineRotation;
                }
                Objects[i].Rotate(RotationOffset);

                prevPoints[i] = point;
            }
        }
    }
}
