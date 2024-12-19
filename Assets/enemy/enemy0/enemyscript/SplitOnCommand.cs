using UnityEngine;

public class SplitOnCommand : MonoBehaviour
{
    public GameObject splitPrefab; // 分裂後に生成されるオブジェクトのPrefab
    public int splitCount = 2; // 分裂する数
    public float splitForce = 5f; // 分裂時に加える力

    void Update()
    {
        // スペースキーが押されたら分裂する
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Split();
        }
    }

    void Split()
    {
        for (int i = 0; i < splitCount; i++)
        {
            // 新しいオブジェクトを生成
            GameObject newObject = Instantiate(splitPrefab, transform.position, transform.rotation);
            
            // ランダムな方向に力を加える
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            newObject.GetComponent<Rigidbody2D>().AddForce(randomDirection * splitForce, ForceMode2D.Impulse);
        }

        // 元のオブジェクトを破壊する
        Destroy(gameObject);
    }
}
