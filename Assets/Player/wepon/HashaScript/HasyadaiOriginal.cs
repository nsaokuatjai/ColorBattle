using System;
using System.Diagnostics;
using UnityEngine;

public  class HasyadaiOriginal : MonoBehaviour
{       //管理用に追加
   protected  ParticleSystem.Particle[] particles;
    [NonSerialized]
    public HasydaiManager hasydai_manager;
    protected ParticleSystem particleSystem;
    //発射台の攻撃力の倍率
    [NonSerialized]
    public float hasyadai_power;
    [NonSerialized]
    public GameObject[] hanabi;
    [NonSerialized]
    public int equipment_hanabi_num;

    protected bool isRmain=false;
    [NonSerialized]
    public int id_hanabi;
    //発射台を管理する数
    [NonSerialized]
    public int id_sikibetu;
    public virtual void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        //パーティカルシステム1つ1つを取得
        particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        hanabi = hasydai_manager.hanabi;
        if (hasydai_manager.debug)
        {
            if (id_sikibetu == 0) id_hanabi = hasydai_manager.id_hanabi;
            if (id_sikibetu == 1) id_hanabi = hasydai_manager.id_hanabi2;
        
        }
        else
        {
            if (id_sikibetu == 0) hanabi = hasydai_manager.Hanabi_obj0;
            if (id_sikibetu == 1) hanabi = hasydai_manager.Hanabi_obj1;
            id_hanabi = 0;
        }
    }
    void OnParticleCollision(GameObject other)
    {
        // 衝突したオブジェクトのタグを確認
        if (other.CompareTag("enemy"))
        {
            int numParticlesAlive = particleSystem.GetParticles(particles);
            // パーティクルが衝突したオブジェクトの名前を表示
            UnityEngine.Debug.Log("Particle collided with: " + other.name);

            for (int i = 0; i < numParticlesAlive; i++)
            {
                ParticleSystem.Particle particle = particles[i];
         

                    if (hanabi == null) return;
                    if (hanabi[id_hanabi] == null) return;
                UnityEngine.Debug.Log(particleSystem.transform.TransformPoint(particle.position));
                GameObject obj = Instantiate<GameObject>(hanabi[id_hanabi], particleSystem.transform.TransformPoint(particle.position), Quaternion.identity);
                       UnityEngine.Debug.Log(obj);
                    chenge_hanabi_date(obj);
                    //UnityEngine.Debug.Log("Particle Disappeared at Position: " + particle.position);
                    isRmain = true;
            }

            Destroy(gameObject);
        }
        else return;
    }

    public void chenge_hanabi_date(GameObject obj)
    {
        HanabiManegerOriginal script = obj.GetComponent<HanabiManegerOriginal>();
        script.hasyadai_power = hasyadai_power;
        script.hasydai_manager = hasydai_manager;
        script.id_sikibetu = id_sikibetu;
        script.id_sikibetu_Tama = id_hanabi;

    }

}