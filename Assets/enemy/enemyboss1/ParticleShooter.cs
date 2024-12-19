using UnityEngine;

public class ParticleShooter : MonoBehaviour
{
    public ParticleSystem particleSystem; // パーティクルシステム
    public Vector2 velocity; // 事前に設定する速度
    public float speed;
    public bool hasya_flag; // 発射フラグ
    public bool hasya_flag_mid; // 発射フラグ中
    private Vector3 tmp_size;
    public float size;
    ParticleSystem.VelocityOverLifetimeModule velocityModule;

    void Start()
    {
        // パーティクルシステムの初期設定
         velocityModule = particleSystem.velocityOverLifetime;
        velocityModule.enabled = false; // 初期状態では無効にしておく
      
    }

    void Update()
    {
        // hasya_flagがtrueになった場合にパーティクルを発射
        if (hasya_flag)
        {
            FireParticles();
            hasya_flag_mid=true;
            hasya_flag = false; // 一度発射したらフラグを戻す
        }
        if (hasya_flag_mid)
        {
            tmp_size = gameObject.transform.localScale;
            tmp_size.x += size;
            tmp_size.y += size;
            gameObject.transform.localScale = tmp_size;
        }
    }

    void FireParticles()
    {
        Vector3 originalScale = gameObject.transform.localScale;

        // 子オブジェクトを親オブジェクトから解除
        gameObject.transform.SetParent(null);

        // 元のスケールを設定してサイズを維持
        gameObject.transform.localScale = originalScale;
        // パーティクルシステムのvelocityOverLifetimeモジュールを有効化し、速度を設定
        velocityModule.enabled = true;

        //// 速度を設定
        ParticleSystem.MinMaxCurve xVelocity = new ParticleSystem.MinMaxCurve(velocity.x * speed);
        ParticleSystem.MinMaxCurve yVelocity = new ParticleSystem.MinMaxCurve(velocity.y * speed);
        velocityModule.x = xVelocity;
        velocityModule.y = yVelocity;
        // 速度を設定

    }
}
