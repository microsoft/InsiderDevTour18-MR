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
using HoloToolkit.Unity;
using HoloToolkit.Sharing.SyncModel;

namespace HoloToolkit.Sharing
{
    /// <summary>
    /// Synchronizer to update and broadcast a transform object through our data model.
    /// </summary>
    public class TransformSynchronizer : MonoBehaviour
    {
        protected Vector3Interpolated Position;
        protected QuaternionInterpolated Rotation;
        protected Vector3Interpolated Scale;

        private SyncTransform transformDataModel;

        /// <summary>
        /// Data model to which this transform synchronization is tied to.
        /// </summary>
        public SyncTransform TransformDataModel
        {
            private get { return transformDataModel; }
            set
            {
                if (transformDataModel != value)
                {
                    if (transformDataModel != null)
                    {
                        transformDataModel.PositionChanged -= OnPositionChanged;
                        transformDataModel.RotationChanged -= OnRotationChanged;
                        transformDataModel.ScaleChanged -= OnScaleChanged;
                    }

                    transformDataModel = value;

                    if (transformDataModel != null)
                    {
                        // Set the position, rotation and scale to what they should be
                        transform.localPosition = transformDataModel.Position.Value;
                        transform.localRotation = transformDataModel.Rotation.Value;
                        transform.localScale = transformDataModel.Scale.Value;

                        // Initialize
                        Initialize();

                        // Register to changes
                        transformDataModel.PositionChanged += OnPositionChanged;
                        transformDataModel.RotationChanged += OnRotationChanged;
                        transformDataModel.ScaleChanged += OnScaleChanged;
                    }
                }
            }
        }

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (Position == null)
            {
                Position = new Vector3Interpolated(transform.localPosition);
            }
            if (Rotation == null)
            {
                Rotation = new QuaternionInterpolated(transform.localRotation);
            }
            if (Scale == null)
            {
                Scale = new Vector3Interpolated(transform.localScale);
            }
        }

        private void Update()
        {
            // Apply transform changes, if any
            if (Position.HasUpdate())
            {
                transform.localPosition = Position.GetUpdate(Time.deltaTime);
            }
            if (Rotation.HasUpdate())
            {
                transform.localRotation = Rotation.GetUpdate(Time.deltaTime);
            }
            if (Scale.HasUpdate())
            {
                transform.localScale = Scale.GetUpdate(Time.deltaTime);
            }
        }

        private void LateUpdate()
        {
            // Determine if the transform has changed locally, in which case we need to update the data model
            if (transform.localPosition != Position.Value ||
                Quaternion.Angle(transform.localRotation, Rotation.Value) > 0.2f ||
                transform.localScale != Scale.Value)
            {
                transformDataModel.Position.Value = transform.localPosition;
                transformDataModel.Rotation.Value = transform.localRotation;
                transformDataModel.Scale.Value = transform.localScale;

                // The object was moved locally, so reset the target positions to the current position
                Position.Reset(transform.localPosition);
                Rotation.Reset(transform.localRotation);
                Scale.Reset(transform.localScale);
            }
        }

        private void OnDestroy()
        {
            if (transformDataModel != null)
            {
                transformDataModel.PositionChanged -= OnPositionChanged;
                transformDataModel.RotationChanged -= OnRotationChanged;
                transformDataModel.ScaleChanged -= OnScaleChanged;
            }
        }

        private void OnPositionChanged()
        {
            Position.SetTarget(transformDataModel.Position.Value);
        }

        private void OnRotationChanged()
        {
            Rotation.SetTarget(transformDataModel.Rotation.Value);
        }

        private void OnScaleChanged()
        {
            Scale.SetTarget(transformDataModel.Scale.Value);
        }
    }
}
