using UnityEngine;

public class camela : MonoBehaviour
{
    private Transform target; // �v���C���[��Transform���w��
    public float smoothSpeed = 0.125f; // �J�����̈ړ������炩�ɂ��邽�߂̃X�s�[�h
    public Vector3 offset; // �J�����ƃv���C���[�̋����I�t�Z�b�g
    public float y_min;//y���̉����l��ݒ�
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
            transform.position=target.position;
        }
    }
    void LateUpdate()
    {
        if (target != null)
        {

            Vector3 desiredPosition = target.position + offset;
            Vector3 camelaPosition = transform.position;
            if (camelaPosition.y < y_min) camelaPosition.y = y_min;
            Vector3 smoothedPosition = Vector3.Lerp(camelaPosition, desiredPosition, smoothSpeed);
     
                transform.position = smoothedPosition;
        }
    }
}
