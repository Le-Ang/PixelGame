using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DOTweenTest : MonoBehaviour

{
    public CanvasGroup canvasGroup;
    public float animationDuraction = 1;
    public float animationEndValue = 0;
    public Ease ease = Ease.InBounce;
    public void close()
    {
        transform.DOScale(animationEndValue, animationDuraction).SetEase(ease);
        canvasGroup.DOFade(animationEndValue, 1);
    }

}
