using UnityEngine;

public class ParticleShooter2 : MonoBehaviour
{
    public ParticleSystem particleSystem; // パーティクルシステム
    public Vector2 velocity; // 事前に設定する速度
    ParticleSystem.VelocityOverLifetimeModule velocityModule;

    void Start()
    {
        // パーティクルシステムの初期設定
         velocityModule = particleSystem.velocityOverLifetime;
        FireParticles();

    }

    void Update()
    {
    //if(velocity!=null)
   
    }

    void FireParticles()
    {
     

        // 速度を設定
        ParticleSystem.MinMaxCurve xVelocity = new ParticleSystem.MinMaxCurve(velocity.x);
        ParticleSystem.MinMaxCurve yVelocity = new ParticleSystem.MinMaxCurve(velocity.y);
        velocityModule.x = xVelocity;
        velocityModule.y = yVelocity;
    }
}
