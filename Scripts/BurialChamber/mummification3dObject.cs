using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mummification3dObject : MonoBehaviour
{
    private Vector3 originPosition;
    public GameObject artifactObject;

    // Start is called before the first frame update
    void Start()
    {

    }
    
    public void IntArtifactObject()
    {
        Debug.Log("IntArtifactObject");
        //artifactObject = (GameObject)Instantiate(artifactObject, originPosition, Quaternion.identity);
        artifactObject.SetActive(true);
    }
}
