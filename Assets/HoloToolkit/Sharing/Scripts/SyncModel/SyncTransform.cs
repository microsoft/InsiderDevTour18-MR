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
using HoloToolkit.Unity;

namespace HoloToolkit.Sharing.SyncModel
{
    /// <summary>
    /// This class implements the Transform object primitive for the syncing system.
    /// It does the heavy lifting to make adding new transforms to a class easy.
    /// A transform defines the position, rotation and scale of an object.
    /// </summary>
    public class SyncTransform : SyncObject
    {
        [SyncData] public SyncVector3 Position = new SyncVector3("Position");
        [SyncData] public SyncQuaternion Rotation = new SyncQuaternion("Rotation");
        [SyncData] public SyncVector3 Scale = new SyncVector3("Scale");

        public event Action PositionChanged;
        public event Action RotationChanged;
        public event Action ScaleChanged;

        public SyncTransform(string field)
            : base(field)
        {
            Position.ObjectChanged += OnPositionChanged;
            Rotation.ObjectChanged += OnRotationChanged;
            Scale.ObjectChanged += OnScaleChanged;
        }

        private void OnPositionChanged(SyncObject obj)
        {
            PositionChanged.RaiseEvent();
        }

        private void OnRotationChanged(SyncObject obj)
        {
            RotationChanged.RaiseEvent();
        }

        private void OnScaleChanged(SyncObject obj)
        {
            ScaleChanged.RaiseEvent();
        }
    }
}
