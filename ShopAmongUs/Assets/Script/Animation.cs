using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Animation_DOtween : MonoBehaviour
{
    public float fadeTime = 1.0f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    public RectTransform LoadingPoint;
  
    public void EnterTransition()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
    }

    // Update is called once per frame
    public void ExitTransition()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
    }

  //  public float fadeTime = 1.0f;
  /*
    void Start()
    {
        this.transform.localScale = Vector3.zero;
        StartCoroutine("ListItemAnimation");
    }

    IEnumerator ListItemAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        this.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
    }*/

}
