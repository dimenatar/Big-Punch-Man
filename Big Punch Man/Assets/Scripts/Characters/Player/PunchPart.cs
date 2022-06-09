using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchPart : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public void Enable(float delayToDisable)
    {
        _collider.enabled = true;
        Invoke(nameof(Disable), delayToDisable);
    }

    private void Disable() => _collider.enabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Ragdoll>().PunchRigidbody();
        }
    }
}
