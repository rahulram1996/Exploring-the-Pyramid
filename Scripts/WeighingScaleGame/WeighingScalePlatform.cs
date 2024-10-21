using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeighingScalePlatform : MonoBehaviour
{
    public float totalMass;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Weight>() != null)
        {
            totalMass += other.GetComponent<Weight>().mass;           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Weight>() != null)
        {
            totalMass -= other.GetComponent<Weight>().mass;
        }
    }
}
