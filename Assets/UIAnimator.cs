using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;
using System;

public enum TweanType 
{
   FadeIn,
   RightToCenter,
   LeftToCenter, 
   CenterToRight, 
   CenterToLeft,
   BottomToCenter,
   CenterToBottom
}
public class UIAnimator : MonoBehaviour
{
    private RectTransform rectTransform;
    public TweanType tweanType;
    public float offSet;
    public float tweanTime;
    public Ease ease;
    private Vector3 targetPos;
    public bool animateOnEnable = true;
    public UnityEvent onComplete;
    public UnityEvent onCompleteCommon;
    public UnityEvent onCompleteRight;
    public UnityEvent onCompleteLeft;
    public UnityEvent onCompleteBottom;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnEnable()
    {
        if(animateOnEnable)
            DoAnimation();
    }

    public void DoAnimation()
    {
        switch (tweanType)
        {
            case TweanType.FadeIn:
                FadeIn();
                break;
            case TweanType.RightToCenter:
                RightToCenter();
                break;

            case TweanType.LeftToCenter:
                LeftToCenter();
                break;

            case TweanType.CenterToRight:
                CenterToRight();
                break;

            case TweanType.CenterToLeft:
                CenterToLeft();
                break;

            case TweanType.BottomToCenter:
                BottomToCenter();
                break;

            case TweanType.CenterToBottom:
                CenterToBottom();
                break;

            default:
                break;
        }
    }


    public void RightToCenter()
    {
        rectTransform.localPosition = new Vector3(offSet, 0, 0);
        targetPos = new Vector3(0, 0, 0);
        onComplete = onCompleteCommon;
        MoveTransitionEffect();

    }
    public void CenterToRight()
    {
        onComplete = onCompleteRight;
        targetPos = new Vector3(offSet, 0, 0);
        MoveTransitionEffect();
    }

    public void CenterToLeft()
    {
        onComplete = onCompleteLeft;
        targetPos = new Vector3(offSet * -1, 0, 0);
        MoveTransitionEffect();
    }

    public void LeftToCenter()
    {
        rectTransform.localPosition = new Vector3(offSet * -1, 0, 0);
        targetPos = new Vector3(0, 0, 0);
        onComplete = onCompleteCommon;
        MoveTransitionEffect();
    }

    public void BottomToCenter()
    {
        rectTransform.localPosition = new Vector3(targetPos.x, offSet * -1, targetPos.z);
        targetPos = new Vector3(0, 0, 0);
        onComplete = onCompleteCommon;
        MoveTransitionEffect();
    }

    public void CenterToBottom()
    {
        onComplete = onCompleteBottom;
        targetPos = new Vector3(0, offSet* - 1, 0);
        MoveTransitionEffect();
    }


    private void MoveTransitionEffect()
    {
        rectTransform.DOLocalMove(targetPos, tweanTime).SetEase(ease).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }

    public void FadeIn()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        onComplete = onCompleteCommon;
        canvasGroup.DOFade(1f, tweanTime).SetEase(ease).OnComplete(() =>
        {
            StartCoroutine(WaitAndContinue(1f));
        });
    }

    IEnumerator WaitAndContinue(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        onComplete?.Invoke();
    }

}
