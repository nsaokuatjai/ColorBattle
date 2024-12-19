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
                particles[i].remainingLifetime = 0; // �p�[�e�B�N��������
            }
        }

        particleSystem.SetParticles(particles, numParticlesAlive);
    }
    public float CalculateDistance(Vector2 point1, Vector2 point2)
    {
        // x���W��y���W�̍������߂�
        float dx = point2.x - point1.x;
        float dy = point2.y - point1.y;

        // �O�����̒藝���g���ċ������v�Z����
        float distance = Mathf.Sqrt(dx * dx + dy * dy);
        return distance;
    }

}

