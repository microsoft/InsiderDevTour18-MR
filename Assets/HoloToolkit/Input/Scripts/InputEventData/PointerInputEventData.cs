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
using UnityEngine.EventSystems;

namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// Describes a Unity pointer event that was generated by a specific input source and ID.
    /// </summary>
    public class PointerInputEventData : PointerEventData, IInputSourceInfoProvider
    {
        public IInputSource InputSource { get; set; }

        public uint SourceId { get; set; }

        public PointerInputEventData(EventSystem eventSystem) : base(eventSystem)
        {
        }

        public void Clear()
        {
            Reset();
            button = InputButton.Left;
            clickCount = 0;
            clickTime = 0;
            delta = Vector2.zero;
            dragging = false;
            eligibleForClick = false;
            pointerCurrentRaycast = default(RaycastResult);
            pointerDrag = null;
            pointerEnter = null;
            pointerId = 0;
            pointerPress = null;
            pointerPressRaycast = default(RaycastResult);
            position = Vector2.zero;
            pressPosition = Vector2.zero;
            rawPointerPress = null;
            scrollDelta = Vector2.zero;
            selectedObject = null;
            useDragThreshold = false;
            InputSource = null;
            SourceId = 0;
        }
    }
}