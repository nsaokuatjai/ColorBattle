using System.Diagnostics;
using UnityEngine;

public class Hasyadai : HasyadaiOriginal
{
    //パーティカルシステム1つ1つを取得
    void Start()
    {
        base.Start();
   

    }

    void Update()
    {
        int numParticlesAlive = particleSystem.GetParticles(particles);
        //パーティカルの全体に実行する
        for (int i = 0; i < numParticlesAlive; i++)
        {
            ParticleSystem.Particle particle = particles[i];

            //if (particleSystem.particleCount == 0)
            //{
            //    // パーティクルが存在しない場合の処理
            //}
            // パーティクルの残存寿命が0.1以下であれば消滅したとみなす、0だと動作しなくなるので注意
            //    UnityEngine.Debug.Log("particle.remainingLifetime" + particle.remainingLifetime);
          //  UnityEngine.Debug.Log(particle.remainingLifetime);
            if (particle.remainingLifetime <= 0.1f)
            {
               
                if (hanabi == null) return;
                if (hanabi[id_hanabi] == null) return;
                GameObject obj = Instantiate<GameObject>(hanabi[id_hanabi], particleSystem.transform.TransformPoint(particle.position), Quaternion.identity);
                chenge_hanabi_date(obj);
                 //UnityEngine.Debug.Log("Particle Disappeared at Position: " + particle.position);
                 isRmain = true;

            }
       }
      //  
        if (isRmain)
        {
            //パーティカルを破壊。パーティカル1つ1つを破壊することができないのですべてを破壊する

            Destroy(gameObject);
        }

    }
}