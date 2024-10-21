using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource voiceOverSource;
    [SerializeField] private AudioSource backgroundMusicSource;

    [SerializeField] private AudioClip currentVoiceOverClip;
    [SerializeField] private AudioClip currentBackgroundMusicClip;

    [SerializeField] bool voiceOverRepeat = false;
    [SerializeField] float voiceOverRepeatInterval = 60;
    [SerializeField] float timer;

    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (voiceOverRepeat)
        {
            timer += Time.deltaTime;
            if (timer >= voiceOverRepeatInterval)
            {
                PlayVoiceOverClip();
                timer = 0;
            }
        }
        else
            timer = 0;
    }

    public void StopVoiceOverRepeat()
    {
        voiceOverRepeat = false;
    }

    public void ReadyVoiceOverClip(AudioClip currentVoiceOverClip, bool repeat = false, float intervalToRepeat = 60, bool playImmediately = true)
    { 
        this.currentVoiceOverClip = currentVoiceOverClip;
        voiceOverSource.clip = this.currentVoiceOverClip;
        voiceOverRepeat = repeat;
        voiceOverRepeatInterval = intervalToRepeat;
        if (playImmediately)
        {
            PlayVoiceOverClip(); 
        }
    }

    void PlayVoiceOverClip()
    {
        voiceOverSource.Play();
    }

    public void PlayBackgroundMusicClip(AudioClip currentBackgroundMusicClip, bool repeat = false)
    {
        this.currentBackgroundMusicClip = currentBackgroundMusicClip;
        backgroundMusicSource.clip = this.currentBackgroundMusicClip;
        if (repeat)
            backgroundMusicSource.loop = true;
        else
            backgroundMusicSource.loop = false;

        backgroundMusicSource.Play();
    }
}
