using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hit;

    private void Awake()
    {
        GetComponent<EnemyFight>().OnHit += () => _hit.Play();
    }
}
