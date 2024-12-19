using System.Diagnostics;
using UnityEngine;

public class bossarea : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] obj;
    public Vector3[] spawnOffset;
    public GameObject[] oya_obj;
    public bossmane gameManager;

    void Start()
    {
        GameObject myObject = GameObject.Find("GameManeger");
        gameManager = myObject.GetComponent<bossmane>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        // プレイヤーなど特定のオブジェクトと接触した場合のみ生成する場合
        if (other.CompareTag("Player"))
        {
            int i = 0;
           
            // objectsToSpawn配列にあるすべてのオブジェクトを生成
            foreach (GameObject a in obj)
            {
                if(oya_obj[i]!=null) Instantiate(a, spawnOffset[i], Quaternion.identity, oya_obj[i].transform);
               else Instantiate(a, spawnOffset[i], Quaternion.identity);
                i++;

            }
            Destroy(gameObject);
            gameManager.startgame();
        }
    }
}
