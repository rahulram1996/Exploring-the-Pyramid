using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConstellationGameManager : MonoBehaviour
{
    /// <summary>
    /// Static object instance
    /// </summary>
    public static ConstellationGameManager Instance;

    /// <summary>
    /// Correct constellation sockets
    /// </summary>
    [SerializeField] private List<ConstellationSocket> constellationSockets = new List<ConstellationSocket>();

    /// <summary>
    /// Event gets called on completing the constellation game
    /// </summary>
    public UnityEvent OnConstellationGameCompleted = new UnityEvent();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //Add the correct socket locations to the list
        foreach (ConstellationSocket socket in FindObjectsOfType<ConstellationSocket>()) 
        {
            if (socket.IsCorrectSocket)
            { 
                constellationSockets.Add(socket);
            }
        }
    }

    /// <summary>
    /// Gets called whenever a gem is placed in the correct location and checks if all the gems are placed to form the constellation
    /// </summary>
    public void OnConstellationSocketUpdated()
    {

        bool constellationsSet = true;
        foreach (ConstellationSocket socket in constellationSockets)
        {
            if (!socket.SocketInteractionComplete)
            {
                constellationsSet = false;
                break;
            }
        }

        if(constellationsSet)
            OnConstellationGameCompleted.Invoke();
    }
}
