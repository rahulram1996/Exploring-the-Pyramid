using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPivotHandler : MonoBehaviour
{
    public Camera cam;
    public GameObject pivotUI;

    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        Quaternion rot = Quaternion.Lerp(pivotUI.transform.rotation, cam.transform.rotation, 5 * Time.deltaTime);
        pivotUI.transform.rotation = new Quaternion(pivotUI.transform.rotation.x, rot.y, pivotUI.transform.rotation.z, pivotUI.transform.rotation.w);
    }
}
