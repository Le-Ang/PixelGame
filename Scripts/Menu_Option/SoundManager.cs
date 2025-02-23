using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum MusicEffect {DIE, COLLECT, JUMP};
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioEffect;
    [SerializeField] private AudioSource audioSoundBG;
    [SerializeField] private Button bGMusicBtn;
    [SerializeField] private Button soundEffectBtn;
    private static Sprite bGMusicBtnSprite;
    private static Sprite bGMusicBtnMuteSprite;
    private static Sprite soundEffectBtnSprite;
    private static Sprite soundEffectBtnMuteSprite;
    public bool bGMusicIsMute;
    public BoolValue checkBGMusic;
    public bool soundEffectIsMute;
    public BoolValue checkSoundEffect;
    private AudioClip bgMusic;
    private AudioClip dieMusic;
    private AudioClip collectMusic;
    private AudioClip jumpMusic;
    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "End Screen")
        {
            bgMusic = Resources.Load<AudioClip>("BGM_04");
        }
        else
        {
            bgMusic = Resources.Load<AudioClip>("BGM_03");
        }
        dieMusic = Resources.Load<AudioClip>("death");
        collectMusic = Resources.Load<AudioClip>("collect");
        jumpMusic = Resources.Load<AudioClip>("jump");
        bGMusicBtnSprite = Resources.Load<Sprite>("bgMusic");
        bGMusicBtnMuteSprite = Resources.Load<Sprite>("bgMusicMute");
        soundEffectBtnSprite = Resources.Load<Sprite>("soundEffect");
        soundEffectBtnMuteSprite = Resources.Load<Sprite>("soundEffectMute");
    }
    private void Start()
    {        
        bGMusicIsMute = checkBGMusic.RuntimeValue;
        soundEffectIsMute = checkSoundEffect.RuntimeValue;
        audioSoundBG.loop = true;
        audioSoundBG.clip = bgMusic;
        if (bGMusicIsMute == false)
        {           
            PlayBGMusic();
        }
        if(bGMusicIsMute == true)
        {
            bGMusicBtn.image.sprite = bGMusicBtnMuteSprite;
        }
        if(soundEffectIsMute == true)
        {
            soundEffectBtn.image.sprite = soundEffectBtnMuteSprite;
            audioEffect.volume = 0;
        }
    }
    public void PlayBGMusic()
    {
        audioSoundBG.Play();
    }
    public void StopBGMusic()
    {
        audioSoundBG.Stop();
    }
    public void ManagerBGMusic()
    {
        if (!bGMusicIsMute)
        {
            bGMusicBtn.image.sprite = bGMusicBtnMuteSprite;
            bGMusicIsMute = true;
            checkBGMusic.RuntimeValue = bGMusicIsMute;
            audioSoundBG.Stop();
        }
        else
        {
            bGMusicBtn.image.sprite = bGMusicBtnSprite;
            bGMusicIsMute = false;
            checkBGMusic.RuntimeValue = bGMusicIsMute;
            audioSoundBG.Play();
        }
    }

    public void ManagerSoundEffect()
    {
        if(!soundEffectIsMute)
        {
            soundEffectBtn.image.sprite = soundEffectBtnMuteSprite;
            soundEffectIsMute = true;
            checkSoundEffect.RuntimeValue = soundEffectIsMute;
            audioEffect.volume=0;
        }
        else
        {
            soundEffectBtn.image.sprite = soundEffectBtnSprite;
            soundEffectIsMute = false;
            checkSoundEffect.RuntimeValue= soundEffectIsMute;
            audioEffect.volume=1;
        }
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
