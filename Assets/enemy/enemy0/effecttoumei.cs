using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class effecttoumei : MonoBehaviour
{

    private Material material;
    private ParticleSystem particleSystem;
    ParticleSystem.Particle[] particles;
    public float toumei_time;
    Color tmp_color;
    void Start()
    {  // パーティクルシステムコンポーネントを取得

        particleSystem = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];

        //    UnityEngine.Debug.Log("  lifetime" + lifetime);
        //   GetComponent<Renderer>().material.color = new Color32(r, g, b, 255);
    }
    // Update is called once per frame
    void Update()
    {
        int numParticlesAlive = particleSystem.GetParticles(particles);
        for (int i = 0; i < numParticlesAlive; i++)
        {
            ParticleSystem.Particle particle = particles[i];

            //ParticleSystem.Particle particle = particles[0];
            UnityEngine.Debug.Log("particle.remainingLifetime" + particle.remainingLifetime);
            if (particle.remainingLifetime < toumei_time)
            {
                UnityEngine.Debug.Log(" material" + GetComponent<Renderer>().material.color.a);
                tmp_color = GetComponent<Renderer>().material.color;
                tmp_color.a =  (particle.remainingLifetime / toumei_time);
                UnityEngine.Debug.Log("  tmp_color.a" + tmp_color.a);

                GetComponent<Renderer>().material.color = tmp_color;

            }
        }
    }
}
