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
using UnityEngine.UI;

namespace HoloToolkit.UI.Keyboard
{
    public class SymbolDisableHighlight : MonoBehaviour
    {
        /// <summary>
        /// The text field to update.
        /// </summary>
        [SerializeField]
        private Text m_TextField = null;

        /// <summary>
        /// The text field to update.
        /// </summary>
        [SerializeField]
        private Image m_ImageField = null;

        /// <summary>
        /// The color to switch to when the button is disabled.
        /// </summary>
        [SerializeField]
        private Color m_DisabledColor = Color.grey;

        /// <summary>
        /// The color the text field starts as.
        /// </summary>
        private Color m_StartingColor = Color.white;

        /// <summary>
        /// The button to check for disabled/enabled.
        /// </summary>
        private Button m_Button = null;

        /// <summary>
        /// Standard Unity start.
        /// </summary>
        private void Start()
        {
            if (m_TextField != null)
            {
	            m_StartingColor = m_TextField.color;
            }

            if (m_ImageField != null)
            {
                m_StartingColor = m_ImageField.color;
            }

            m_Button = GetComponentInParent<Button>();

            UpdateState();
        }

        /// <summary>
        /// Standard Unity update.
        /// </summary>
        private void Update()
        {
            UpdateState();
        }

        /// <summary>
        /// Updates the visual state of the text based on the buttons state.
        /// </summary>
        private void UpdateState()
        {
            if (m_TextField != null && m_Button != null)
            {
	            m_TextField.color = m_Button.interactable ? m_StartingColor : m_DisabledColor;
            }

            if (m_ImageField != null && m_Button != null)
            {
                m_ImageField.color = m_Button.interactable ? m_StartingColor : m_DisabledColor;
            }
        }
	}
}
