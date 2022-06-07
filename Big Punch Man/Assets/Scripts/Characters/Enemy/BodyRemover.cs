using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BodyRemover : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Remove());
    }

    private IEnumerator Remove()
    {
        yield return new WaitForSeconds(6);
        gameObject.transform.DOScale(0, 1).OnComplete(() => Destroy(gameObject));
    }
}
