using UnityEngine;

public class hanni : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float areaSize;
    private Vector3 point;
    void Start()
    {
       point = new Vector3(0,0,0);
        UnityEngine.Debug.Log(particleSystem.main.maxParticles);
    }
    void Update()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        int numParticlesAlive = particleSystem.GetParticles(particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            Vector3 pos = particles[i].position;
            UnityEngine.Debug.Log(pos);
            UnityEngine.Debug.Log(Vector3.Distance(pos, point));
            if (Vector3.Distance(pos, point)>areaSize)
            {
                particles[i].remainingLifetime = 0; // パーティクルを消す
            }
        }

        particleSystem.SetParticles(particles, numParticlesAlive);
    }
    public float CalculateDistance(Vector2 point1, Vector2 point2)
    {
        // x座標とy座標の差を求める
        float dx = point2.x - point1.x;
        float dy = point2.y - point1.y;

        // 三平方の定理を使って距離を計算する
        float distance = Mathf.Sqrt(dx * dx + dy * dy);
        return distance;
    }

}

