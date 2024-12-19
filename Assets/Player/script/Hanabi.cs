using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanabi : HanabiOriginal
{
    protected ParticleSystem particleSystem;
    ParticleSystem.Particle[] particles;
    // Start is called before the first frame update
    public  void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
    }

    // Update is called once per frame
    void Update()
    {

            ParticleSystem.Particle particle = particles[0];
            // パーティクルの残存寿命が0.1以下であれば消滅したとみなす、0だと動作しなくなるので注意
            if (particle.remainingLifetime <= 0.1f)
            {
            //パーティカルを破壊。パーティカル1つ1つを破壊することができないのですべてを破壊する

            Destroy(gameObject);
        }
    }
}
