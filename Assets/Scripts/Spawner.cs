using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private FallingCube _prefab;
    [SerializeField] private Vector3 _firstCorner;
    [SerializeField] private Vector3 _secondCorner;
    [SerializeField] private float _instantiateInterval;
    [SerializeField] private int _startInstantiateAmout;

    private ObjectPool<FallingCube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<FallingCube>(_prefab);
        StartCoroutine(SpawningCycle());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(_firstCorner, Vector3.up);
        Gizmos.DrawRay(_secondCorner, Vector3.up);
    }

    private Vector3 GetRandomPosition() 
    {
        float x = Random.Range(_firstCorner.x, _secondCorner.x);
        float y = Random.Range(_firstCorner.y, _secondCorner.y);
        float z = Random.Range(_firstCorner.z, _secondCorner.z);

        return new Vector3(x, y, z);
    }

    private IEnumerator SpawningCycle()
    {
        var wait = new WaitForSeconds(_instantiateInterval);

        while (true)
        {
            FallingCube cube = _pool.Pull();
            _pool.SubscribeReturnEvent(cube);
            cube.transform.position = GetRandomPosition();

            yield return wait;
        }
    }
}