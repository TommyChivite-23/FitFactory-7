using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static Action<AudioClip> OnPlayBGM;
    public static Action<AudioClip> OnPlaySFX;

    [SerializeField] AudioSource bgmAS, sfxAS;
    [SerializeField] AudioClip defaultBGM;


    private void PlaySFX(AudioClip audioClip)
    {
        sfxAS.PlayOneShot(audioClip);
    }

    //Stops music and assigns clip
    private void PlayBGM(AudioClip audioClip)
    {
        bgmAS.Stop();
        bgmAS.clip = audioClip;
        bgmAS.loop = true;
        bgmAS.Play();
    }

    //Event Handlers
    private void OnEnable()
    {
        OnPlayBGM += PlayBGM;
        OnPlaySFX += PlaySFX;

        CountDownController.OnCountDownDone += PlayDefaultBGM;
    }

    private void OnDisable()
    {
        OnPlayBGM -= PlayBGM;
        OnPlaySFX -= PlaySFX;

        CountDownController.OnCountDownDone -= PlayDefaultBGM;
    }

    private void PlayDefaultBGM()
    {
        PlayBGM(defaultBGM);
    }
}
