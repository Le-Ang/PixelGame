using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBtnDoT : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float endValueX;
    public float endValueY;

    private void Start()
    {
        Menu();
    }
    private void Menu()
    {
        canvasGroup.DOFade(1f, 0.5f);
        canvasGroup.GetComponent<RectTransform>().DOAnchorPos(new Vector2(endValueX, endValueY), 0.75f);
    }
}
