using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusicTrigger : MonoBehaviour
{
    public AudioClip clip;

    public void PlayClip()
    { 
        AudioManager.instance.PlayBackgroundMusicClip(clip);
    }
}
