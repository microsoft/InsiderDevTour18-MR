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
using System;

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// Anim controller button offers as simple way to link button states to animation controller parameters
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class AnimControllerButton : Button
    {
        /// <summary>
        /// List of animation actions
        /// </summary>
        [HideInInspector]
        public AnimatorControllerAction[] AnimActions;

        /// <summary>
        /// Animator
        /// </summary>
        private Animator _animator;

        /// <summary>
        /// On state change
        /// </summary>
        public override void OnStateChange(ButtonStateEnum newState)
        {
            if (_animator == null)
            {
                _animator = this.GetComponent<Animator>();
            }

            if (AnimActions == null)
            {
                base.OnStateChange(newState);
                return;
            }

            for (int i = 0; i < AnimActions.Length; i++)
            {
                if (AnimActions[i].ButtonState == newState)
                {
                    switch (AnimActions[i].ParamType)
                    {
                        case AnimatorControllerParameterType.Bool:
                            _animator.SetBool(AnimActions[i].ParamName, AnimActions[i].BoolValue);
                            break;
                        case AnimatorControllerParameterType.Float:
                            _animator.SetFloat(AnimActions[i].ParamName, AnimActions[i].FloatValue);
                            break;
                        case AnimatorControllerParameterType.Int:
                            _animator.SetInteger(AnimActions[i].ParamName, AnimActions[i].IntValue);
                            break;
                        case AnimatorControllerParameterType.Trigger:
                            _animator.SetTrigger(AnimActions[i].ParamName);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                }
            }

            base.OnStateChange(newState);
        }
    }
}