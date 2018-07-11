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
	public class CapsLockHighlight : MonoBehaviour
	{
		/// <summary>
		/// The highlight image to turn on and off.
		/// </summary>
		[SerializeField]
		private Image m_Highlight = null;

		/// <summary>
		/// The keyboard to check for caps locks
		/// </summary>
		private Keyboard m_Keyboard;
        		
		/// <summary>
		/// Unity Start method.
		/// </summary>
		private void Start()
		{
			m_Keyboard = this.GetComponentInParent<Keyboard>();
			UpdateState();
		}

		/// <summary>
		/// Unity update method.
		/// </summary>
		private void Update()
		{
			UpdateState();
		}

		/// <summary>
		/// Updates the visual state of the shift highlight.
		/// </summary>
		private void UpdateState()
		{
			bool isCapsLock = false;
			if (m_Keyboard != null)
			{
				isCapsLock = m_Keyboard.IsCapsLocked;
			}

			if (m_Highlight != null)
			{
				m_Highlight.enabled = isCapsLock;
			}
		}
	}
}
