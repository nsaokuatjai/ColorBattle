using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SoundManager : MonoBehaviour
{
    public enum SE_TYPE{ ACTION, CLEAR, GAMEOVER }
 
    public AudioClip[] bgm;
    public AudioClip[] actionSE;
    public AudioClip[] clearSE;
    public AudioClip[] gameOverSE;
 
    [SerializeField]
    [Range(0, 1)]
    float bgmVolume = 1.0f;
    [SerializeField]
    [Range(0, 1)]
    float seVolume = 1.0f;
 
    AudioSource bgmAudioSource;
    AudioSource seAudioSource;
 
    void Awake ()
    {
        bgmAudioSource = gameObject.AddComponent<AudioSource>();
        seAudioSource = gameObject.AddComponent<AudioSource>();
    }
 
    //BGM再生。numに0未満を指定すると停止
    public void PlayBGM(int num)
    {
        if(num >= 0)
        {
            bgmAudioSource.clip = bgm[num];
            bgmAudioSource.loop = true;
            bgmAudioSource.volume = bgmVolume;
            bgmAudioSource.Play();
        }
        else
        {
            bgmAudioSource.Stop();
        }
    }
 
    //SE再生
    public void PlaySE(SE_TYPE seType, int num)
    {
        switch(seType)
        {
            case SE_TYPE.ACTION:
                seAudioSource.PlayOneShot(actionSE[num], seVolume);
                break;
 
            case SE_TYPE.CLEAR:
                seAudioSource.PlayOneShot(clearSE[num], seVolume);
                break;
 
            case SE_TYPE.GAMEOVER:
                seAudioSource.PlayOneShot(gameOverSE[num], seVolume);
                break;
        }
    }
 
    //ランダムでSE再生
    public void RandomSE(SE_TYPE seType)
    {
        int num = 0;
        int randomRange = 0;
 
        switch (seType)
        {
            case SE_TYPE.ACTION:
                randomRange = actionSE.Length;
                num = Random.Range(0, randomRange);
                PlaySE(SE_TYPE.ACTION, num);
                break;
 
            case SE_TYPE.CLEAR:
                randomRange = clearSE.Length;
                num = Random.Range(0, randomRange);
                PlaySE(SE_TYPE.CLEAR, num);
                break;
 
            case SE_TYPE.GAMEOVER:
                randomRange = gameOverSE.Length;
                num = Random.Range(0, randomRange);
                PlaySE(SE_TYPE.GAMEOVER, num);
                break;
        }
    }
 
}