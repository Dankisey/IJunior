using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _timeToSpawn;

    private void Start()
    {
        StartCoroutine(StartSpawningCycle());
    }

    private void Spawn()
    {
        int spawnPoint = Random.Range(0, _spawnPoints.Length);
        Instantiate(_prefab, _spawnPoints[spawnPoint].position, Quaternion.identity).SetTarget(_target);
    }

    private IEnumerator StartSpawningCycle()
    {
        var wait = new WaitForSeconds(_timeToSpawn);

        while (true) 
        {
            yield return wait;

            Spawn();
        }
    }
}