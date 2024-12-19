using UnityEngine;

public class ParticleShooter2 : MonoBehaviour
{
    public ParticleSystem particleSystem; // �p�[�e�B�N���V�X�e��
    public Vector2 velocity; // ���O�ɐݒ肷�鑬�x
    ParticleSystem.VelocityOverLifetimeModule velocityModule;

    void Start()
    {
        // �p�[�e�B�N���V�X�e���̏����ݒ�
         velocityModule = particleSystem.velocityOverLifetime;
        FireParticles();

    }

    void Update()
    {
    //if(velocity!=null)
   
    }

    void FireParticles()
    {
     

        // ���x��ݒ�
        ParticleSystem.MinMaxCurve xVelocity = new ParticleSystem.MinMaxCurve(velocity.x);
        ParticleSystem.MinMaxCurve yVelocity = new ParticleSystem.MinMaxCurve(velocity.y);
        velocityModule.x = xVelocity;
        velocityModule.y = yVelocity;
    }
}
