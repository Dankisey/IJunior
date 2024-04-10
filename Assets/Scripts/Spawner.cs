using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private float _timeToSpawn;

    private float _elapsedTime = 0f;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _timeToSpawn)
        {
            _elapsedTime = 0;

            Spawn();
        }
    }

    private void Spawn()
    {
        int spawnPoint = Random.Range(0, _spawnPoints.Length);
        Instantiate(_prefab, _spawnPoints[spawnPoint].position, Quaternion.identity).SetTarget(_target);
    }
}
