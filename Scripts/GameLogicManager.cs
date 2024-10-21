using EasyUIAnimator;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.XR.Interaction.Toolkit;

public class GameLogicManager : MonoBehaviour
{
    /// <summary>
    /// Player 
    /// </summary>
    [SerializeField] private GameObject player;

    /// <summary>
    /// player vision tunnel control
    /// </summary>
    [SerializeField] private Material tunnelingVignetteMaterial;

    /// <summary>
    /// player vision tunnel control
    /// </summary>
    [SerializeField] private GameObject tunnelingVignette;
    /// <summary>
    /// Object related to the present timeline
    /// </summary>
    [SerializeField] private List<GameObject> currentTimelineObjects = new List<GameObject>();
    /// <summary>
    /// Object related to the ancient timeline
    /// </summary>
    [SerializeField] private List<GameObject> oldTimelineObjects = new List<GameObject>();
    /// <summary>
    /// Object related to the burial (Mummification) chamber
    /// </summary>
    [SerializeField] private List<GameObject> burialChamberObjects = new List<GameObject>();
    /// <summary>
    /// Object related to the queen's chamber
    /// </summary>
    [SerializeField] private List<GameObject> queensChamberObjects = new List<GameObject>();
    /// <summary>
    /// Object related to the king's chamber
    /// </summary>
    [SerializeField] private List<GameObject> kingssChamberObjects = new List<GameObject>();
    /// <summary>
    /// Current timeline skybox
    /// </summary>
    [SerializeField] private Material skyboxMorning;
    /// <summary>
    /// Night timeline skybox
    /// </summary>
    [SerializeField] private Material skyboxNight;

    [SerializeField] private Transform oldTimelineEntrance;
    [SerializeField] private Transform burialChamberEntrance;
    [SerializeField] private Transform queenChamberEntrance;
    [SerializeField] private Transform kingChamberEntrance;
    [SerializeField] private Transform newtimelineEntrance;
    [SerializeField] private Animator OldToNewTimelineTransition;
    [SerializeField] private GameObject mainCanvas;

    bool initialize = true;

    public void TurnOnMainCanva()
    {
        StartCoroutine(TurnOnMainCanvas());
    }

    private  IEnumerator TurnOnMainCanvas()
    { 
        yield return new WaitForSeconds(4);

        mainCanvas.SetActive(true);
    }

    public void QuitGame()
    { 
        Application.Quit();
    }

    private void Start()
    {
        //Fader.FadeIn();

        Show(level.currentTimeline);
        tunnelingVignette.GetComponent<Animator>().SetTrigger("Open");
        //if (skyboxMorning != null)
        //{
        //    RenderSettings.skybox = skyboxMorning;
        //    DynamicGI.UpdateEnvironment();
        //}
        SetMorningSkybox();

    }

    public void SetMorningSkybox()
    {
        if (skyboxMorning != null)
        {
            RenderSettings.skybox = skyboxMorning;
           DynamicGI.UpdateEnvironment();
        }
    }

    // Method to change the skybox to skybox2
    public void SetNightSkybox()
    {
        if (skyboxNight != null)
        {
            RenderSettings.skybox = skyboxNight;
            DynamicGI.UpdateEnvironment();
        }
    }

    /// <summary>
    /// Shows current timeline objects
    /// </summary>
    public void ShowCurrenttimeline()
    {
        Show(level.currentTimeline);
    }
    /// <summary>
    /// Shows ancient timeline objects
    /// </summary>
    public void ShowOldtimeline()
    {
        Show(level.oldTimeline);
    }
    /// <summary>
    /// Shows burial chamber objects
    /// </summary>
    public void ShowBurialChamber()
    {
        Show(level.burialChamber);
    }
    /// <summary>
    /// Shows queen's chamber objects
    /// </summary>
    public void ShowQueensChamber()
    {
        Show(level.queensChamber);
    }
    /// <summary>
    /// Shows King's chamber objects
    /// </summary>
    public void ShowKingsChamber()
    {
        Show(level.kingssChamber);
    }

    public void InitiateOldTimeLineAnimations()
    {
        OldToNewTimelineTransition.SetTrigger("OldTransitionInit");
        StartCoroutine(OldTimelineAnim());
    }

    IEnumerator OldTimelineAnim()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(()=> !IsAnimationPlaying("OldTimelineTransitionAnimation"));
        ShowOldtimeline();
    }
    bool IsAnimationPlaying(string stateName)
    {
        AnimatorStateInfo stateInfo = OldToNewTimelineTransition.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(stateName) && stateInfo.normalizedTime < 1.0f;
    }
    /// <summary>
    /// Load level
    /// </summary>
    /// <param name="loadLevel"></param>
    private void Show(level loadLevel)
    {
        StartCoroutine(ShowLevel(loadLevel));
    }

    IEnumerator ShowLevel(level loadLevel)
    {
        if (!initialize)
        {
            Fader.FadeOut();
            while (Fader.isFading) yield return null; 
        }
        yield return new WaitForSeconds(1);
        switch (loadLevel)
        {
            case level.currentTimeline:
                {
                    foreach (GameObject obj in currentTimelineObjects)
                        obj.SetActive(true);

                    foreach (GameObject obj in oldTimelineObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in burialChamberObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in queensChamberObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in kingssChamberObjects)
                        obj.SetActive(false);
                    InitiateTeleport(newtimelineEntrance);
                    SetMorningSkybox();
                    initialize = false;
                    break;
                }
            case level.oldTimeline:
                {
                    foreach (GameObject obj in currentTimelineObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in oldTimelineObjects)
                        obj.SetActive(true);

                    foreach (GameObject obj in burialChamberObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in queensChamberObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in kingssChamberObjects)
                        obj.SetActive(false);

                    SetNightSkybox();
                    InitiateTeleport(oldTimelineEntrance);

                    break;
                }
            case level.burialChamber:
                {
                    foreach (GameObject obj in currentTimelineObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in oldTimelineObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in burialChamberObjects)
                        obj.SetActive(true);

                    foreach (GameObject obj in queensChamberObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in kingssChamberObjects)
                        obj.SetActive(false);
                    InitiateTeleport(burialChamberEntrance);

                    break;
                }
            case level.queensChamber:
                {
                    foreach (GameObject obj in currentTimelineObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in oldTimelineObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in burialChamberObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in queensChamberObjects)
                        obj.SetActive(true);

                    foreach (GameObject obj in kingssChamberObjects)
                        obj.SetActive(false);
                    InitiateTeleport(queenChamberEntrance);

                    break;
                }
            case level.kingssChamber:
                {
                    foreach (GameObject obj in currentTimelineObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in oldTimelineObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in burialChamberObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in queensChamberObjects)
                        obj.SetActive(false);

                    foreach (GameObject obj in kingssChamberObjects)
                        obj.SetActive(true);
                    InitiateTeleport(kingChamberEntrance);

                    break;
                }

        }
    }

    /// <summary>
    /// Teleport function call
    /// </summary>
    /// <param name="location"></param>
    public void InitiateTeleport(Transform location)
    {
        //tunnelingVignetteMaterial.SetFloat("_ApertureSize", 1f);
        //tunnelingVignetteMaterial.SetFloat("_FeatheringEffect", 1f);
        //tunnelingVignette.GetComponent<Animator>().SetTrigger("Teleport");
        StartCoroutine(Teleport(location));
    }

    IEnumerator Teleport(Transform location)
    {
        while (Fader.isFading) yield return null;

        player.transform.position = location.position;
        Fader.FadeIn();
    }
}

/// <summary>
/// Game levels
/// </summary>
public enum level
{ 
    currentTimeline, oldTimeline, burialChamber, queensChamber, kingssChamber
}