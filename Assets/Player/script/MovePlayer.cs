using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField, Tooltip("移動スピード")]
    public float moveSpeed;
    private  Rigidbody2D rd;
    [SerializeField]
    private float maxSpeed;
    private Vector2  moveSpeedVector = new Vector2(0,0);
    private Animator moveAnime;
    public float jump_force;
    Vector3 POTITISONX=new Vector3 (0.71875f / 2f, 0,0);
    // Start is called before the first frame update
    float timer;
    Vector2 jump_up;
    public LayerMask StageLayer;
    public float tmp;
    bool a = false;
    public JumpScript jump_script;
    SoundManager soundManager;

    public AudioClip se_jump; // ジャンプ音のオーディオクリップをインスペクターで設定

    private AudioSource audioSource;

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        soundManager = FindObjectOfType<SoundManager>();
        rd = GetComponent<Rigidbody2D>();
        moveAnime = this.GetComponent<Animator>();
        jump_up =new  Vector2(0, jump_force);
    }
    void FixedUpdate()
    {
 
         timer += Time.deltaTime;
      
        moveSpeedVector.x = Input.GetAxisRaw("Horizontal");

        if (rd.velocity.x< maxSpeed && rd.velocity.x>-maxSpeed) rd.AddForce(moveSpeedVector*moveSpeed, ForceMode2D.Force);
        if(Input.GetAxisRaw("Horizontal")!=0)moveAnime.SetFloat("move", Input.GetAxisRaw("Horizontal"));
        if (timer > 2f)
        {
  
            timer = 0f;
        }
    //    if(a&&jump_script.isGround()) UnityEngine.Debug.Log("2grund");
        // UnityEngine.Debug.Log(jump_count);
    //    UnityEngine.Debug.Log("isground="+jump_script.isGround());
        if (Input.GetAxisRaw("Vertical") == 1 && jump_script.isGround()&&a==false)
        {
            jump(); 
            a = true;
        }
        else a = false;
        
    }
    // Update is called once per frame
   
   // bool groundChk()
    //{
    //    Vector3 start_position = transform.position-transform.up *tmp + POTITISONX;                     // Playerの中心を始点とする
    //    Vector3 end_position = transform.position - transform.up *tmp - POTITISONX; // Playerの足元を終点とする
    //    UnityEngine.Debug.DrawLine(start_position, end_position, Color.red);
    //    return Physics2D.Linecast(start_position, end_position, StageLayer);
    //}
    //bool groundChk()
    //{
    //    Vector2 position = transform.position;
    //    float radius = 0.001f;  // 足元の円の半径を調整
    //    Vector3 start_position = transform.position - transform.up * tmp + POTITISONX;
    //    Collider2D[] colliders = Physics2D.OverlapCircleAll(start_position, radius, StageLayer);
    //    UnityEngine.Debug.Log($"Checking ground at position: {start_position}, radius: {radius}");
    //    foreach (var collider in colliders)
    //    {
    //        if (collider.gameObject != gameObject)
    //        {
    //            return true;
    //        }
    //    }
    //    Vector3 end_position = transform.position - transform.up * tmp - POTITISONX;
    //    Collider2D[] colliders2 = Physics2D.OverlapCircleAll(start_position, radius, StageLayer);
    //    foreach (var collider in colliders2)
    //    {
    //        if (collider.gameObject != gameObject)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    void jump()
    {
        soundManager.PlaySE(SoundManager.SE_TYPE.ACTION,1);
        rd.AddForce(jump_up, ForceMode2D.Impulse);

    }
}
