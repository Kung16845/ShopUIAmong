using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Animation_ItemList : MonoBehaviour
{
    public float fadeTime = 1.0f;

    void Start()
    {
        this.transform.localScale = Vector3.zero;
        StartCoroutine("ListItemAnimation");
    }

    IEnumerator ListItemAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        this.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);    
    }
}
