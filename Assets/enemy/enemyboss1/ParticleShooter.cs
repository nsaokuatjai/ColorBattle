using UnityEngine;

public class ParticleShooter : MonoBehaviour
{
    public ParticleSystem particleSystem; // �p�[�e�B�N���V�X�e��
    public Vector2 velocity; // ���O�ɐݒ肷�鑬�x
    public float speed;
    public bool hasya_flag; // ���˃t���O
    public bool hasya_flag_mid; // ���˃t���O��
    private Vector3 tmp_size;
    public float size;
    ParticleSystem.VelocityOverLifetimeModule velocityModule;

    void Start()
    {
        // �p�[�e�B�N���V�X�e���̏����ݒ�
         velocityModule = particleSystem.velocityOverLifetime;
        velocityModule.enabled = false; // ������Ԃł͖����ɂ��Ă���
      
    }

    void Update()
    {
        // hasya_flag��true�ɂȂ����ꍇ�Ƀp�[�e�B�N���𔭎�
        if (hasya_flag)
        {
            FireParticles();
            hasya_flag_mid=true;
            hasya_flag = false; // ��x���˂�����t���O��߂�
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

        // �q�I�u�W�F�N�g��e�I�u�W�F�N�g�������
        gameObject.transform.SetParent(null);

        // ���̃X�P�[����ݒ肵�ăT�C�Y���ێ�
        gameObject.transform.localScale = originalScale;
        // �p�[�e�B�N���V�X�e����velocityOverLifetime���W���[����L�������A���x��ݒ�
        velocityModule.enabled = true;

        //// ���x��ݒ�
        ParticleSystem.MinMaxCurve xVelocity = new ParticleSystem.MinMaxCurve(velocity.x * speed);
        ParticleSystem.MinMaxCurve yVelocity = new ParticleSystem.MinMaxCurve(velocity.y * speed);
        velocityModule.x = xVelocity;
        velocityModule.y = yVelocity;
        // ���x��ݒ�

    }
}
