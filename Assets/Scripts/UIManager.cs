using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeTime = 0.5f;
    public void ShowUI()
    {
        canvasGroup.DOFade(1, fadeTime);
    }

    public void HideUI()
    {
        canvasGroup.DOFade(0, fadeTime).onComplete = ()=>
        {
            gameObject.SetActive(false);
        };
    }
}
