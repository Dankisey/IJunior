using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawners;
    [SerializeField] private float _timeToSpawn;

    private void Start()
    {
        StartCoroutine(StartSpawningCycle());
    }

    private IEnumerator StartSpawningCycle()
    {
        var wait = new WaitForSeconds(_timeToSpawn);

        while (true)
        {
            yield return wait;

            _spawners[Random.Range(0,_spawners.Length)].Spawn();
        }
    }
}
