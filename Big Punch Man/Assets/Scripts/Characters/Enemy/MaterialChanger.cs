using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Material _deadMaterial;
    [SerializeField] private SkinnedMeshRenderer _renderer;

    public void ChangeMaterialToDead()
    {
        _renderer.material = _deadMaterial;
    }
}
