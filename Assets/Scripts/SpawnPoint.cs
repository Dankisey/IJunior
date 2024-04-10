using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _prefab;

    private Transform _spawnPoint;

    private void Start()
    {
        _spawnPoint = transform;
    }

    public void Spawn()
    {
        Enemy enemy = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        enemy.SetTarget(_target);
    }
}