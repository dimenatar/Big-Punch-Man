using DG.Tweening;
using System.Collections;
using UnityEngine;

public class BodyRemover : MonoBehaviour
{
    [SerializeField] private Transform _armature;

    public void Initialise()
    {
        _armature.parent = null;
        StartCoroutine(Remove());
    }

    private IEnumerator Remove()
    {
        yield return new WaitForSeconds(6);
        _armature.parent = null;
        _armature.DOScale(0, 1).OnComplete(() => Destroy(_armature.gameObject));
        Destroy(gameObject, 1);
    }
}
