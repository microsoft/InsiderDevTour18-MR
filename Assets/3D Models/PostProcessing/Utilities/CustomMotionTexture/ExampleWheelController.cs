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

public class ExampleWheelController : MonoBehaviour
{
    public float acceleration;
    public Renderer motionVectorRenderer; // Reference to the custom motion vector renderer

    Rigidbody m_Rigidbody;

    static class Uniforms
    {
        internal static readonly int _MotionAmount = Shader.PropertyToID("_MotionAmount");
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>(); // Get reference to rigidbody
        m_Rigidbody.maxAngularVelocity = 100; // Set max velocity for rigidbody
    }

    void Update()
    {
        if (Input.GetKey (KeyCode.UpArrow)) // Rotate forward
            m_Rigidbody.AddRelativeTorque(new Vector3(-1 * acceleration, 0, 0), ForceMode.Acceleration); // Add forward torque to mesh
        else if (Input.GetKey (KeyCode.DownArrow)) // Rotate backward
            m_Rigidbody.AddRelativeTorque(new Vector3(1 * acceleration, 0, 0), ForceMode.Acceleration); // Add backward torque to mesh

        float m = -m_Rigidbody.angularVelocity.x / 100; // Calculate multiplier for motion vector texture

        if (motionVectorRenderer) // If the custom motion vector texture renderer exists
            motionVectorRenderer.material.SetFloat(Uniforms._MotionAmount, Mathf.Clamp(m, -0.25f, 0.25f)); // Set the multiplier on the renderer's material
    }
}
