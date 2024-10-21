using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayVoiceOverTrigger : MonoBehaviour
{
    public bool repeat = false;
    public float repeatInterval = 60;
    public bool playImmediately = true;

    public float delayTime = 0;

    public UnityEvent VoiceOverPlayed = new UnityEvent();
    public AudioClip clip;

    [Header("Controlled by script (Don't Modify, only for developer reference)")]
    [SerializeField] bool playOnce = false;

    IEnumerator play()
    {
        yield return new WaitUntil(() => !AudioManager.instance.voiceOverSource.isPlaying);

        yield return new WaitForSeconds(delayTime);
        playOnce = true;
        AudioManager.instance.ReadyVoiceOverClip(clip, repeat, repeatInterval, playImmediately);

        yield return new WaitUntil(() => !AudioManager.instance.voiceOverSource.isPlaying);
        VoiceOverPlayed?.Invoke();
    }
    public void PlayClip()
    {
        if (!playOnce)
        {
            StartCoroutine(play()); 
        }
    }
}
