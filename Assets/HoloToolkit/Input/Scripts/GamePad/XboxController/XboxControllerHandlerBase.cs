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
using System.Collections;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    public class XboxControllerHandlerBase : GamePadHandlerBase, IXboxControllerHandler
    {
        protected enum GestureState
        {
            SelectButtonUnpressed,
            SelectButtonPressed,
            NavigationStarted,
            HoldStarted
        }

        [SerializeField]
        [Tooltip("Elapsed time for hold started gesture in seconds.")]
        protected float HoldStartedInterval = 2.0f;

        [SerializeField]
        [Tooltip("Elapsed time for hold completed gesture in seconds.")]
        protected float HoldCompletedInterval = 3.0f;

        [SerializeField]
        [Tooltip("The action button that is used to select.  Analogous to air tap on HoloLens and trigger press with motion controllers.")]
        protected XboxControllerMappingTypes SelectButton = XboxControllerMappingTypes.XboxA;

        [SerializeField]
        [Tooltip("The Horizontal Axis that navigation events take place")]
        protected XboxControllerMappingTypes HorizontalNavigationAxis = XboxControllerMappingTypes.XboxLeftStickHorizontal;

        [Tooltip("The Vertical Axis that navigation events take place")]
        protected XboxControllerMappingTypes VerticalNavigationAxis = XboxControllerMappingTypes.XboxLeftStickVertical;

        protected GestureState CurrentGestureState = GestureState.SelectButtonUnpressed;

        protected Vector3 NormalizedOffset;

        protected Coroutine HoldStartedRoutine;

        public virtual void OnXboxInputUpdate(XboxControllerEventData eventData)
        {
            if (string.IsNullOrEmpty(GamePadName))
            {
                GamePadName = eventData.GamePadName;
            }

            if (XboxControllerMapping.GetButton_Down(SelectButton, eventData))
            {
                CurrentGestureState = GestureState.SelectButtonPressed;

                InputManager.Instance.RaiseSourceDown(eventData.InputSource, eventData.SourceId, InteractionSourcePressInfo.Select);

                HoldStartedRoutine = StartCoroutine(HandleHoldStarted(eventData));
            }

            if (XboxControllerMapping.GetButton_Pressed(SelectButton, eventData))
            {
                HandleNavigation(eventData);
            }

            if (XboxControllerMapping.GetButton_Up(SelectButton, eventData))
            {
                HandleSelectButtonReleased(eventData);
            }

            // Consume this event
            eventData.Use();
        }

        protected virtual void HandleSelectButtonReleased(XboxControllerEventData eventData)
        {
            InputManager.Instance.RaiseSourceUp(eventData.InputSource, eventData.SourceId, InteractionSourcePressInfo.Select);

            if (HoldStartedRoutine != null)
            {
                StopCoroutine(HoldStartedRoutine);
            }

            switch (CurrentGestureState)
            {
                case GestureState.NavigationStarted:
                    InputManager.Instance.RaiseNavigationCompleted(eventData.InputSource, eventData.SourceId, Vector3.zero);
                    break;
                case GestureState.HoldStarted:
                    InputManager.Instance.RaiseHoldCompleted(eventData.InputSource, eventData.SourceId);
                    break;
                default:
                    InputManager.Instance.RaiseInputClicked(eventData.InputSource, eventData.SourceId, InteractionSourcePressInfo.Select, 1);
                    break;
            }

            CurrentGestureState = GestureState.SelectButtonUnpressed;
        }

        protected virtual IEnumerator HandleHoldStarted(XboxControllerEventData eventData)
        {
            yield return new WaitForSeconds(HoldStartedInterval);

            if (CurrentGestureState == GestureState.HoldStarted || CurrentGestureState == GestureState.NavigationStarted)
            {
                yield break;
            }

            CurrentGestureState = GestureState.HoldStarted;

            InputManager.Instance.RaiseHoldStarted(eventData.InputSource, eventData.SourceId);
        }

        protected virtual void HandleNavigation(XboxControllerEventData eventData)
        {
            float displacementAlongX = XboxControllerMapping.GetAxis(HorizontalNavigationAxis, eventData);
            float displacementAlongY = XboxControllerMapping.GetAxis(VerticalNavigationAxis, eventData);

            if (displacementAlongX == 0.0f && displacementAlongY == 0.0f && CurrentGestureState != GestureState.NavigationStarted) { return; }

            NormalizedOffset.x = displacementAlongX;
            NormalizedOffset.y = displacementAlongY;
            NormalizedOffset.z = 0f;

            if (CurrentGestureState != GestureState.NavigationStarted)
            {
                if (CurrentGestureState == GestureState.HoldStarted)
                {
                    InputManager.Instance.RaiseHoldCanceled(eventData.InputSource, eventData.SourceId);
                }

                CurrentGestureState = GestureState.NavigationStarted;

                // Raise navigation started event.
                InputManager.Instance.RaiseNavigationStarted(eventData.InputSource, eventData.SourceId);
            }
            else
            {
                // Raise navigation updated event.
                InputManager.Instance.RaiseNavigationUpdated(eventData.InputSource, eventData.SourceId, NormalizedOffset);
            }
        }

        [Obsolete("Use XboxControllerMapping.GetButton_Up")]
        protected static bool OnButton_Up(XboxControllerMappingTypes buttonType, XboxControllerEventData eventData)
        {
            return XboxControllerMapping.GetButton_Up(buttonType, eventData);
        }

        [Obsolete("Use XboxControllerMapping.GetButton_Pressed")]
        protected static bool OnButton_Pressed(XboxControllerMappingTypes buttonType, XboxControllerEventData eventData)
        {
            return XboxControllerMapping.GetButton_Pressed(buttonType, eventData);
        }

        [Obsolete("Use XboxControllerMapping.GetButton_Down")]
        protected static bool OnButton_Down(XboxControllerMappingTypes buttonType, XboxControllerEventData eventData)
        {
            return XboxControllerMapping.GetButton_Down(buttonType, eventData);
        }
    }
}
