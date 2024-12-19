using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyAttackOriginal enemy_attack;
    [SerializeField]
    private EnemyMoveOriginal enemy_move;
    private GameObject player;
    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (enemy_attack != null) enemy_attack.setPlayer(player);
        enemy_move.setPlayer(player);
      //  enemy_move.setAnime(enemy_anime);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if(enemy_attack!=null) enemy_attack.attack();
        enemy_move.moves();
      
    }
}
