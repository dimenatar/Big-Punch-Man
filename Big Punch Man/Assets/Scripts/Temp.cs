using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp : MonoBehaviour
{
    [SerializeField] private Transform _arc;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<GameObject> _enemies;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.name == "Enemy" || transform.GetChild(i).gameObject.name == "Enemy (Clone)")
            {
                var enemy = Instantiate(_prefab, transform.GetChild(i).transform.position, transform.GetChild(i).transform.rotation);
                enemy.transform.SetParent(transform);
                _enemies.Add(enemy);
                Destroy(transform.GetChild(i).gameObject);
            }
            if (transform.GetChild(i).gameObject.name == "Pivot")
            {
                var pivot = transform.GetChild(i);
                for (int j = 0; j < pivot.childCount; j++)
                {
                    if (pivot.GetChild(j).gameObject.name == "Enemy" || transform.GetChild(i).gameObject.name == "Enemy (Clone)")
                    {
                        var enemy = Instantiate(_prefab, pivot.GetChild(j).transform.position, pivot.GetChild(j).transform.rotation);
                        enemy.transform.SetParent(pivot);
                        _enemies.Add(enemy);
                        Destroy(pivot.GetChild(j).gameObject);
                    }
                }
            }
        }
    }
}
