using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackboss1 : EnemyAttackOriginal
{
    public SpriteRenderer spriteRenderer;
    //�U��1�p
    public GameObject game_object;
    //�U��2�p
    public GameObject game_object2;
    //�U��3�p
    public GameObject game_object3;
    //�U���Ԋu���ǎ��v�p
    private float time=10;
    //�N�[����������
    public float ctime1;
    //�A�j���[�^�[���Ǘ�
    public Animator enemy_anime; // �G�L�����N�^�[��Animator���w��
    //�A�j���[�^�[����U���^�C�~���O���擾
    public bool tama_attack_flag=false;
    private bool tama_attack_flag_tmp=false;
    //�e���o���ꏊ�����߂�A�j���[�^�[�Ŏw��
    public Vector3 tama_position;
    //attack2 potion
    public Vector3[] tama_position2;
    //attack2 ���x
    Vector2[] tama_vector;
    //attack2���I��������Ƃ����m
    public bool fin_attack2;
    GameObject[] attack2_obj;
    private Vector3 tama_position2_tmp;
    private float tmp_ctime1;
    //�A�j���[�^�[����U���^�C�~���O���擾
    public bool attack_flag2=false;
    public bool attack_flag3 = false;
    private bool attack_flag3_tmp = false;
    private bool attack_flag2_tmp = false;
    public Vector3 tama_position3;
    //��2�U���̍U���̊Ԋu
    public float attack_rate;
    public int attack_num;
    private bool isAttacking=false;
    int attack_count=0;
    Camera mainCamera;
    byte tmpr;
    byte tmpg;
    byte tmpb;
    private bool angre;
    public float muteki_time;
    public Vector3 attack3_verocity; 
        void Start()
    {
        tmp_ctime1 = ctime1;
        attack2_obj = new GameObject[tama_position2.Length];
        tama_vector = new Vector2[tama_position2.Length];
         mainCamera = Camera.main;

    }
    public override  void attack()
    {
        time += Time.deltaTime;
        Color current_color = spriteRenderer.color;
        tmpr = (byte)(current_color.r * 255f);
        tmpg = (byte)(current_color.g * 255f);
       tmpb = (byte)(current_color.b * 255f);
        if(muteki_time > time && angre)
        {
            Camera.main.backgroundColor = spriteRenderer.color;
        } 

        if ((tmpr < 120 || tmpg < 120 || tmpb < 120)&& angre==false)
        {
            // �J�����̔w�i�F��ݒ肷���
            Camera.main.backgroundColor = spriteRenderer.color;
           
            ctime1 *= 0.9f;
            angre=true;
            muteki_time += time;
        }
        else if (ctime1 < time && attack_count % 9 == 0)

        {
            attack_flag3_tmp=true;
            enemy_anime.SetTrigger("atk2");
            ctime1 += tmp_ctime1;
            attack_count += 1;
        }
        else if (ctime1 < time&& attack_count%2==0)
        {
            tama_attack_flag_tmp = true;
            enemy_anime.SetTrigger("atk"); //("attack1", true);
            ctime1 += tmp_ctime1;
            attack_count += 1;
       }
        else if(ctime1 < time && attack_count % 2 == 1)
        {

            enemy_anime.SetTrigger("atk1");
            ctime1 += tmp_ctime1;
            attack_count += 1;
            isAttacking = true;
            attack_flag2_tmp = true;
        }
        if(tama_attack_flag&& tama_attack_flag_tmp)
        {
            tama_attack_flag_tmp = false;
            tamaAttack();
        }
        if (attack_flag2&& isAttacking)
        {
            isAttacking = false;
            attack_flag2 =false;
            attack2();
           
        }
        if (fin_attack2&& attack_flag2_tmp)
        {

            fin_attack2 =false;
            attack_flag2 = false;
            startAttack();
        }
        if (attack_flag3&& attack_flag3_tmp)
        {
            attack_flag3_tmp=false;
            attack_flag3 = false;
            attack3();
        }
    }
    private void tamaAttack()
    {
     
   
       GameObject obj= Instantiate<GameObject>(game_object, gameObject.transform.position + tama_position, Quaternion.identity);
        if (angre)
        {
            AttackObjboss1 script = obj.GetComponent<AttackObjboss1>();
            script.bunnretu += 1;
            obj.transform.localScale=obj.transform.localScale* 2;
            script.attack_power *= 2;
        }
        tama_attack_flag =false;
        
    }
    private void attack2()
    {

        StartCoroutine(PerformAttacks());

    }
    private IEnumerator PerformAttacks()
    {

        Vector3 tmp;
        Vector3 directionToPlayer = player.transform.position - gameObject.transform.position; 
        float range = 4f;
        for (int i = 0; i < attack_num; i++)
        {
            int j = i - 2;

            tmp = directionToPlayer;
            //�U���̕��̍L��
            tmp.x += j * range;
            tama_vector[i] = tmp.normalized;
           
        }
      
        for (int i = 0; i < attack_num; i++)
        {
       
             tama_position2_tmp = tama_position2[i];
            if (gameObject.transform.localScale.x < 0) { tama_position2_tmp.x *= -1; }
            attack2_obj[i]=Instantiate<GameObject>(game_object2, transform.position + tama_position2_tmp, Quaternion.identity, gameObject.transform);
            if (angre == true)
            {
                AttackEnemyboss1 attack = attack2_obj[i].GetComponent<AttackEnemyboss1>();
                UnityEngine.Debug.Log("tmpr="+ tmpr);
                attack.r = tmpr;
                attack.b = tmpb;
                attack.g = tmpg;
                attack.attack_power *=2 ;
            }
                //���Ԋu�ōU��
                yield return new WaitForSeconds(attack_rate);  // �w�肵�����ԑҋ@
        }
 

        isAttacking = false;


    }
    void startAttack()
    {
        for (int i = 0; i < attack_num; i++)
        {if (attack2_obj[i] == null) break;
      
            ParticleShooter script = attack2_obj[i].GetComponent<ParticleShooter>();
            script.velocity = tama_vector[i];
            script.hasya_flag = true;

        }
        attack_flag2_tmp = false;


    }
    void attack3()
    {
        Vector3 tmp = tama_position3;
        if (gameObject.transform.localScale.x < 0) { tmp.x *= -1; }
        GameObject obj = Instantiate<GameObject>(game_object3, transform.position + tmp, Quaternion.identity); 
        Attack3Objboss1  script = obj.GetComponent<Attack3Objboss1>();
        tmp=attack3_verocity;
        if (gameObject.transform.localScale.x < 0) { tmp.x *= -1; }
        script.rb.velocity = tmp;
    }

}
