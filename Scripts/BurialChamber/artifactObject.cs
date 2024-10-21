using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artifactObject : MonoBehaviour
{
    private Animator artifactAnimator;
    private Animation anim;

    private string medical = "Medical";

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        Debug.Log("Artifact Object Called..");
        //artifactAnimator.Play(medical);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
