using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup popupCG;

    [SerializeField] private TMPro.TextMeshProUGUI description;

    [SerializeField] private Button yesBtn;
    [SerializeField] private TMPro.TextMeshProUGUI yesBtnText;

    [SerializeField] private Button noBtn;
    [SerializeField] private TMPro.TextMeshProUGUI noBtnText;

    Action yesAction;
    Action noAction;

    public IEnumerator ShowPopUp(string Description, Action YesAction, Action NoAction, string YesBtnText, string NoBtnText, bool setTimer, float timer = 0)
    {
        popupCG.alpha = 1f;
        popupCG.interactable = true;
        popupCG.blocksRaycasts = true;

        if (YesBtnText != "")
        {
            yesBtn.gameObject.SetActive(true);
            yesBtnText.text = YesBtnText;

            yesAction = YesAction;

            yesBtn.onClick.AddListener(()=>
            {
                yesAction.Invoke();
            });
        }
        else
        {
            yesBtn = null;
            yesBtn.gameObject.SetActive(false);
        }


        if (NoBtnText != "")
        {
            noBtn.gameObject.SetActive(true);

            noBtnText.text = NoBtnText;

            noAction = NoAction;

            noBtn.onClick.AddListener(() =>
            {
                noAction.Invoke();
            });
        }
        else
        {
            noBtn = null;
            noBtn.gameObject.SetActive(false);
        }



        if (setTimer)
        {
            yield return new WaitForSeconds(timer);
            yesAction.Invoke();

        }
        ClosePopup();
    }

    public void ClosePopup()
    { 
    
    }
}
