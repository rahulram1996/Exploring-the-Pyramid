using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class afterGameUnityEvent : MonoBehaviour
{
    public UnityEvent afterGame;

    public void AfterGameUnityEvent()
    {
        afterGame.Invoke();
    }
}
