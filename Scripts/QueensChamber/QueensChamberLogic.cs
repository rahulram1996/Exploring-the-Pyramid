using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QueensChamberLogic : MonoBehaviour
{
    public float artifactsFound;

    public UnityEvent queensChamberPuzzleCompleted = new UnityEvent();
    public void UpdateFoundArtifact()
    {
        artifactsFound += 1;
        if(artifactsFound == 4)
            queensChamberPuzzleCompleted?.Invoke();
    }
}
