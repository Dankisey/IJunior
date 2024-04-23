using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ExplodingCube : MonoBehaviour
{
    [SerializeField] private ExplodingCube _prefab;
    [SerializeField] private Material _materialBase;
    [SerializeField] private int _minChildren = 2;
    [SerializeField] private int _maxChildren = 4;
    [SerializeField] private float _maxExplosionForce = 100f;
    [SerializeField] private float _explosionRadius = 3f;
    [SerializeField] private float _shrinkFactor = 2f;

    private float _currentScale = 1f;
    private float _maxDivideChance = 100f;
    private float _divideChance = 100f;

    public void Explode()
    {
        float chance = Random.Range(0, _maxDivideChance);

        if (chance < _divideChance)
            CreateChildren();

        Destroy(gameObject);
    }

    public void Shrink(float parentScale)
    {
        _currentScale = parentScale / _shrinkFactor;
        transform.localScale = Vector3.one * _currentScale;
        _maxExplosionForce *= _currentScale;
        _divideChance *= _currentScale;
    }

    private void CreateChildren()
    {
        int childrenToSpawn = Random.Range(_minChildren, _maxChildren + 1);

        for (int i = 0; i < childrenToSpawn; i++)
        {
            ExplodingCube cube = Instantiate(_prefab, transform.position, Quaternion.identity);
            cube.Shrink(_currentScale);
        }
    }

    private void OnEnable()
    {
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Material material = new Material(_materialBase);
        material.color = color;
        GetComponent<MeshRenderer>().material = material;
    }

    private void OnDestroy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                float distance = Vector3.Distance(rigidbody.position, transform.position);
                float explosionForce = _maxExplosionForce * (distance / _explosionRadius);
                rigidbody.AddExplosionForce(explosionForce, transform.position, _explosionRadius);
            }
        }
    }
}