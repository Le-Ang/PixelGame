using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum MusicEffect {DIE, COLLECT, JUMP};
public class SoundManager : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioEffect;
    [SerializeField] private AudioSource audioSoundBG;
    private AudioClip bgMusic;
    private AudioClip dieMusic;
    private AudioClip collectMusic;
    private AudioClip jumpMusic;
    private static bool BGMusicIsNotPlay = true;
    private void Awake()
    {             
        bgMusic = Resources.Load<AudioClip>("BGM_03");
        dieMusic = Resources.Load<AudioClip>("death");
        collectMusic = Resources.Load<AudioClip>("collect");
        jumpMusic = Resources.Load<AudioClip>("jump");
        DontDestroyOnLoad(transform.gameObject);
    }
    private void Start()
    {
        //audioEffect = GetComponent<AudioSource>();
        //audioSoundBG = GetComponent<AudioSource>();
        audioSoundBG.loop = true;
        audioSoundBG.clip = bgMusic;
        //audioSoundBG.Play();
        if (BGMusicIsNotPlay == true)
        {
            BGMusicIsNotPlay = false;
            PlayBGMusic();
        }
        
    }
    public void PlayBGMusic()
    {
        //string assetPath = AssetDatabase.GetAssetPath(audioSoundBG.clip.GetInstanceID());
        //Debug.Log(assetPath);
        audioSoundBG.Play();
    }
    public void StopBGMusic()
    {
        audioSoundBG.Stop();
    }
    public void PlaySoundEffect(MusicEffect music)
    {
        switch (music)
        {
            case MusicEffect.DIE:
                audioEffect.PlayOneShot(dieMusic); 
                break;
            case MusicEffect.COLLECT:
                audioEffect.PlayOneShot(collectMusic); 
                break;
            case MusicEffect.JUMP:
                audioEffect.PlayOneShot(jumpMusic); 
                break;
            default:
                Debug.Log("Khong co sound"); 
                break;
        }
    }
}
