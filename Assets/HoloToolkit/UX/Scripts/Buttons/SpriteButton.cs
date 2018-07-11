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

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// Sprite button is a sprite renderer interactable with state data for button state
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteButton : Button
    {
        /// <summary>
        /// Button State data set for different interaction states
        /// </summary>
        [Header("Sprite Button")]
        [Tooltip("Button State information")]
        public SpriteButtonDatum[] ButtonStates = new SpriteButtonDatum[]{ new SpriteButtonDatum((ButtonStateEnum)0), new SpriteButtonDatum((ButtonStateEnum)1),
            new SpriteButtonDatum((ButtonStateEnum)2), new SpriteButtonDatum((ButtonStateEnum)3),
            new SpriteButtonDatum((ButtonStateEnum)4), new SpriteButtonDatum((ButtonStateEnum)5) };


        private SpriteRenderer _renderer;

        /// <summary>
        /// Callback override function to change sprite, color and scale on button state change
        /// </summary>
        /// <param name="newState">
        /// A <see cref="ButtonStateEnum"/> for the new button state.
        /// </param>
        public override void OnStateChange(ButtonStateEnum newState)
        {
            if (_renderer == null)
                _renderer = this.GetComponent<SpriteRenderer>();

            if (ButtonStates[(int)newState].ButtonSprite != null)
            {
                _renderer.sprite = ButtonStates[(int)newState].ButtonSprite;
                _renderer.color = ButtonStates[(int)newState].SpriteColor;
            }

            if (this.transform.localScale != ButtonStates[(int)newState].Scale)
                this.transform.localScale = ButtonStates[(int)newState].Scale;

            base.OnStateChange(newState);
        }
    }
}