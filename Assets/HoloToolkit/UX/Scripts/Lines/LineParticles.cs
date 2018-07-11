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

using HoloToolkit.Unity;
using UnityEngine;

namespace HoloToolkit.Unity.UX
{
    [UseWith(typeof(LineBase))]
    public class LineParticles : LineRendererBase
    {
        const int GlobalMaxParticles = 2048;
        const float GlobalParticleStartLifetime = 0.5f;

        [Header("Particle Settings")]
        public Material LineMaterial;
        [Range(128, GlobalMaxParticles)]
        public int MaxParticles = GlobalMaxParticles;
        [Range(0.001f, 5f)]
        public float ParticleStartLifetime = GlobalParticleStartLifetime;

        [Header("Noise settings")]
        public bool ParticleNoiseOnDisabled = true;
        public Vector3 NoiseStrength = Vector3.one;
        public float NoiseFrequency = 1.2f;
        [Range(1, 10)]
        public int NoiseOcatives = 3;
        [Range(-10f, 10f)]
        public float NoiseSpeed = 1f;
        [Range(0.01f, 0.5f)]
        public float LifetimeAfterDisabled = 0.25f;
        public Gradient DecayGradient;

        [SerializeField]
        private ParticleSystem particles;
        private ParticleSystem.Particle[] mainParticleArray = new ParticleSystem.Particle[GlobalMaxParticles];
        private ParticleSystemRenderer mainParticleRenderer;
        private ParticleSystem.NoiseModule mainNoise;
        private float decayStartTime = 0f;

        protected void OnEnable()
        {
            particles = gameObject.EnsureComponent<ParticleSystem>();

            mainNoise = particles.noise;

            ParticleSystem.EmissionModule emission = particles.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(0);
            emission.rateOverDistance = new ParticleSystem.MinMaxCurve(0);
            emission.enabled = true;

            ParticleSystem.MainModule main = particles.main;
            main.loop = false;
            main.playOnAwake = false;
            main.maxParticles = Mathf.Min(MaxParticles, GlobalMaxParticles);
            main.simulationSpace = ParticleSystemSimulationSpace.World;

            ParticleSystem.ShapeModule shape = particles.shape;
            shape.enabled = false;

            mainParticleRenderer = particles.GetComponent<ParticleSystemRenderer>();
            mainParticleRenderer.sharedMaterial = LineMaterial;

            // Initialize our particles
            for (int i = 0; i < mainParticleArray.Length; i++)
            {
                ParticleSystem.Particle particle = mainParticleArray[i];
                particle.startColor = Color.white;
                particle.startSize = 1f;
                particle.startLifetime = float.MaxValue;
                particle.remainingLifetime = float.MaxValue;
                particle.velocity = Vector3.zero;
                particle.angularVelocity = 0;
                mainParticleArray[i] = particle;
            }
        }

        private void OnDisable()
        {
            if (mainParticleRenderer != null)
            {
                mainParticleRenderer.enabled = false;
            }
        }

        private void Update()
        {
            if (!Source.enabled)
            {
                mainNoise.enabled = ParticleNoiseOnDisabled;
                mainNoise.strengthX = NoiseStrength.x;
                mainNoise.strengthY = NoiseStrength.y;
                mainNoise.strengthZ = NoiseStrength.z;
                mainNoise.octaveCount = NoiseOcatives;
                mainNoise.scrollSpeed = NoiseSpeed;
                mainNoise.frequency = NoiseFrequency;

                if (decayStartTime < 0)
                {
                    decayStartTime = Time.unscaledTime;
                }
            }
            else
            {
                mainNoise.enabled = false;
                decayStartTime = -1;
            }

            if (Source.enabled)
            {
                for (int i = 0; i < NumLineSteps; i++)
                {
                    float normalizedDistance = (1f / (NumLineSteps - 1)) * i;
                    ParticleSystem.Particle particle = mainParticleArray[i];
                    particle.position = Source.GetPoint(normalizedDistance);
                    particle.startColor = GetColor(normalizedDistance);
                    particle.startSize = GetWidth(normalizedDistance);
                    mainParticleArray[i] = particle;
                }
            }
            else
            {
                int numDecayingParticles = particles.GetParticles(mainParticleArray);
                for (int i = 0; i < numDecayingParticles; i++)
                {
                    float normalizedDistance = (1f / (NumLineSteps - 1)) * i;
                    mainParticleArray[i].startColor = DecayGradient.Evaluate((Time.unscaledTime - decayStartTime) / LifetimeAfterDisabled) * GetColor(normalizedDistance);
                }
            }
            particles.SetParticles(mainParticleArray, NumLineSteps);
        }
    }
}