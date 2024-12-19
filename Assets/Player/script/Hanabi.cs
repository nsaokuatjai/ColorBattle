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
            // �p�[�e�B�N���̎c��������0.1�ȉ��ł���Ώ��ł����Ƃ݂Ȃ��A0���Ɠ��삵�Ȃ��Ȃ�̂Œ���
            if (particle.remainingLifetime <= 0.1f)
            {
            //�p�[�e�B�J����j��B�p�[�e�B�J��1��1��j�󂷂邱�Ƃ��ł��Ȃ��̂ł��ׂĂ�j�󂷂�

            Destroy(gameObject);
        }
    }
}
