using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TechnoBabelGames;
using UnityEngine;

public class SkyConstellationController : MonoBehaviour
{
    public List<TBLineRendererComponent> tBLineRendererComponents = new List<TBLineRendererComponent>();

    [SerializeField] private float timer = 0;
    [SerializeField] private float totalTime = 8;

    private void Start()
    {
        foreach (TBLineRendererComponent tBLineRendererComponent in tBLineRendererComponents)
        {
            tBLineRendererComponent.lineRendererProperties.endColor = new Color(1, 1, 1, 0);
            tBLineRendererComponent.lineRendererProperties.startColor = new Color(1, 1, 1, 0);
            tBLineRendererComponent.SetLineRendererProperties();
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer <= (totalTime / 2))
        {
            float value = timer/ totalTime;
            foreach (TBLineRendererComponent tBLineRendererComponent in tBLineRendererComponents)
            {
                tBLineRendererComponent.lineRendererProperties.endColor = new Color(1, 1, 1, value/1.5f);
                tBLineRendererComponent.lineRendererProperties.startColor = new Color(1, 1, 1, value/1.5f);
                tBLineRendererComponent.SetLineRendererProperties();
            }
        }
        else if (timer > (totalTime / 2) && timer <= totalTime)
        {
            float value = timer / totalTime;
            value = 1 - value;
            foreach (TBLineRendererComponent tBLineRendererComponent in tBLineRendererComponents)
            {
                tBLineRendererComponent.lineRendererProperties.endColor = new Color(1, 1, 1, value / 1.5f);
                tBLineRendererComponent.lineRendererProperties.startColor = new Color(1, 1, 1, value/1.5f);
                tBLineRendererComponent.SetLineRendererProperties();
            }
        }
        else 
        {
            timer = 0;
        }
    }
}
