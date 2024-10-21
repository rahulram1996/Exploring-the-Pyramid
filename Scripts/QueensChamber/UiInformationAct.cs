using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInformationAct : MonoBehaviour
{
    public GameObject UI;
    public GameObject currentParticle, NextParticle;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter..");
        if (other.CompareTag("Player"))
        {
            UI.SetActive(true);
        }

        StartCoroutine(CloseCurrentParticleEffect());
    }
    public IEnumerator CloseCurrentParticleEffect()
    {
        yield return new WaitForSeconds(3);
        currentParticle.SetActive(false);
        NextParticle.SetActive(true);
    }
}
