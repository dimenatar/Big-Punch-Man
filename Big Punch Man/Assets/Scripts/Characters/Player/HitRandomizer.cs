using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRandomizer : MonoBehaviour
{
    public event Action<Hits> OnHitChosen;

    public Hits GetHit()
    {
        Hits hit = (Hits)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Hits)).Length);
        OnHitChosen?.Invoke(hit);
        return hit;
    }
}
