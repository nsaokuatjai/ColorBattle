using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStart : MonoBehaviour
{
    // Start is called before the first frame update
    SoundManager soundManager;
    void Start()
    {
        soundManager = GetComponent<SoundManager>();
            soundManager.PlayBGM(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
