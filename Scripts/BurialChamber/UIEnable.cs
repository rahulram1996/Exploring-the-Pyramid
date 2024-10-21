using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnable : MonoBehaviour
{

    public GameObject UI;
    public GameObject currentParticle;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter..");
        if (other.CompareTag("Player"))
        {
            UI.SetActive(true);

            StartCoroutine(CloseCurrentParticleEffect());
        }
    }
    public IEnumerator CloseCurrentParticleEffect()
    {
        yield return new WaitForSeconds(5);
        currentParticle.SetActive(false);

    }


}

