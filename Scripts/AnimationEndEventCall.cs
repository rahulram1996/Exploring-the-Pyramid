using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class AnimationEndEventCall : MonoBehaviour
{

    [SerializeField] private Animator animatorComponent;
    [SerializeField] private string animationStateName;

    public UnityEvent OnAnimationCompleted = new UnityEvent();

    private void Start()
    {
        animatorComponent = GetComponent<Animator>();
    }
    public void InitiateAnimationPlayCheck()
    {
        StartCoroutine(OldTimelineAnim());
    }

    IEnumerator OldTimelineAnim()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => !IsAnimationPlaying(animationStateName));
        OnAnimationCompleted?.Invoke();
    }
    bool IsAnimationPlaying(string stateName)
    {
        AnimatorStateInfo stateInfo = animatorComponent.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(stateName) && stateInfo.normalizedTime < 1.0f;
    }
}
