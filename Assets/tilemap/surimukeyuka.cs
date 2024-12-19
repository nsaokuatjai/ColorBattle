using UnityEngine;

public class surimukeyuka : MonoBehaviour
{

    private PlatformEffector2D _platformEffector;
   // public Collider2D feld_c;
    bool is_tach;
    void Awake()
    {
        _platformEffector = GetComponent<PlatformEffector2D>();
    }

    //void Update()
    //{

    //}
    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            //is_tach = true;
            UnityEngine.Debug.Log("sdouw");
            _platformEffector.rotationalOffset = 180;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        _platformEffector.rotationalOffset = 0;
       // is_tach =false;
    }
    //void FixedUpdate()
    //{
    //    //if (Input.GetKeyDown(KeyCode.S)) UnityEngine.Debug.Log("sdouw");
    //    //if (Input.GetKeyDown(KeyCode.DownArrow)) UnityEngine.Debug.Log("DownArrow");
    //    //if (is_tach) UnityEngine.Debug.Log("is_tach");
    //    if (is_tach&&(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
    //    {
    //        if (Input.GetKeyDown(KeyCode.S)) UnityEngine.Debug.Log("180");
    //        _platformEffector.rotationalOffset = 180;
    //        is_tach = false;
    //     }
    //        else
    //        {
    //            _platformEffector.rotationalOffset = 0;
    //        }
    //}
}