using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Finish _finish;
    [SerializeField] private List<GameObject> _objects;

    private void Awake()
    {
        _player.OnDied += Disable;
        _finish.OnFinish += Disable;
    }

    public void Disable()
    {
        _objects.ForEach(o => o.SetActive(false));
    }
}
