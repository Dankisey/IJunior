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
    [SerializeField] private float _scaleReducing = 2f;
    [SerializeField] private float _divideChanceReducing = 2f;

    private float _maxDivideChance = 100f;
    private float _divideChance = 100f;

    public void Explode()
    {
        float chance = Random.Range(0, _maxDivideChance);

        if (chance < _divideChance)
            CreateChildren();

        Destroy(gameObject);
    }

    public void SetDivideChance(float value)
    {
        _divideChance = Mathf.Clamp(value, 0, _maxDivideChance);
    }

    private void CreateChildren()
    {
        int childrenToSpawn = Random.Range(_minChildren, _maxChildren + 1);

        for (int i = 0; i < childrenToSpawn; i++)
        {
            ExplodingCube cube = Instantiate(_prefab, transform.position, Quaternion.identity);
            cube.transform.localScale = transform.localScale / _scaleReducing;
            cube.SetDivideChance(_divideChance / _divideChanceReducing);
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
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

            if (rigidbody == null)
                continue;

            rigidbody.AddExplosionForce(Random.Range(0f, _maxExplosionForce), transform.position, _explosionRadius);
        }
    }
}