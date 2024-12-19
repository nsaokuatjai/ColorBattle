using UnityEngine;

public class camela : MonoBehaviour
{
    private Transform target; // プレイヤーのTransformを指定
    public float smoothSpeed = 0.125f; // カメラの移動を滑らかにするためのスピード
    public Vector3 offset; // カメラとプレイヤーの距離オフセット
    public float y_min;//y軸の下限値を設定
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
