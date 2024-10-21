using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConstellationSocket : MonoBehaviour
{
    /// <summary>
    /// Shows if this socket is right in constellation
    /// </summary>
    [SerializeField] bool isCorrectSocket;
    /// <summary>
    /// Shows if this socket interactino is complete or not
    /// </summary>
    [SerializeField] bool socketInteractionComplete;
    /// <summary>
    /// Diamond game object attached to the socket
    /// </summary>
    [SerializeField] private GameObject diamondSocketed;
    [SerializeField] private Material diamondHightlight;

    /// <summary>
    /// Public access to isCorrectSocket variable
    /// </summary>
    public bool IsCorrectSocket { get { return isCorrectSocket; } }
    /// <summary>
    /// Public access to socketInteractionComplete variable
    /// </summary>
    public bool SocketInteractionComplete { get { return socketInteractionComplete; } }

    /// <summary>
    /// Gets called when this socket is interacted with a diamond
    /// </summary>
    /// <param name="diamond"></param>
    public void SocketInteractionUpdate(GameObject diamond)
    {
        if (isCorrectSocket)
        {
            if (diamond != null && diamond.GetComponent<XRGrabInteractable>() != null)
            {
                //diamond.GetComponent<XRGrabInteractable>().enabled = false;
                diamond.layer = LayerMask.NameToLayer("Diamond");
                socketInteractionComplete = true;
                ConstellationGameManager.Instance.OnConstellationSocketUpdated();
                StartCoroutine(correctDiamondUpdate(diamond));
            }
        }
        else
        {
            if (diamond != null && diamond.GetComponent<XRGrabInteractable>() != null)
            {
                StartCoroutine(WrongDiamondUpdate(diamond));
            }
        }

    }

    IEnumerator correctDiamondUpdate(GameObject diamond)
    {
        yield return new WaitForSeconds(1f);
        diamond.GetComponent<MeshRenderer>().sharedMaterial = diamondHightlight;
    }

    IEnumerator WrongDiamondUpdate(GameObject diamond)
    {
        yield return new WaitForSeconds(1.5f);
        diamond.GetComponent<XRGrabInteractable>().enabled = false;
        yield return new WaitForSeconds(0.15f);
        diamond.GetComponent<XRGrabInteractable>().enabled = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            diamondSocketed = other.gameObject;
            if (diamondSocketed != null)
            {
                SocketInteractionUpdate(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            diamondSocketed = null;
        }
    }
}
