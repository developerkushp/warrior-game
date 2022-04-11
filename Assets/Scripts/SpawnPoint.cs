using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private float _repeatInterval;
    [SerializeField] private float _maxNumberOfEnemy = 5;
    public float _countEnemy = 0;

    public void Start()
    {
        if (_repeatInterval > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, _repeatInterval);
        }
    }

    public GameObject SpawnObject()
    {
        if (_prefabToSpawn != null)
        {
            while (_countEnemy < _maxNumberOfEnemy)
            {
                _countEnemy++;
                return Instantiate(_prefabToSpawn, transform.position, Quaternion.identity);
            }
        }
        return null;
    }
}
