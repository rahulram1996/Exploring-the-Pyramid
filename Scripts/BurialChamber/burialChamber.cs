using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burialChamber : MonoBehaviour
{
    public AudioSource FirstVoiceOver;
    public AudioSource LooksLikeVoiceOver;
    public AudioSource FinalVoiceOver;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FirstVoiceOver Play..");
        FirstVoiceOver.Play();
    }

    public void LookLikeVoiceOverplay()
    {
        LooksLikeVoiceOver.Play();
    }

    public void FinalVoiceOverplay()
    {
        FinalVoiceOver.Play();
    }
}
