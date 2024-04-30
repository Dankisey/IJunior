using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FallingCube : MonoBehaviour, IPoolableObject
{
    [SerializeField] private Color _startColor = Color.white;

    private MeshRenderer _meshRenderer;
    private float _minLifetime = 2f;
    private float _maxLifetime = 5f;
    private bool _changed = false;

    public event Action<IPoolableObject> ReturnConditionReached;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void DoCollisionLogic()
    {
        if (_changed)
            return;

        _changed = true;
        ChangeColor(GetRandomColor());
        StartCoroutine(Lifetime());
    }

    public void Disable()
    {
        _changed = false;
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        ChangeColor(_startColor);
    }

    public IPoolableObject Instantiate()
    {
        return Instantiate(this);
    }

    private Color GetRandomColor()
    {
        float red = UnityEngine.Random.Range(0f, 1f);
        float green = UnityEngine.Random.Range(0f, 1f);
        float blue = UnityEngine.Random.Range(0f, 1f);

        return new Color(red, green, blue);
    }

    private void ChangeColor(Color color)
    {
        Material material = new(_meshRenderer.sharedMaterial);
        material.color = color;
        _meshRenderer.material = material;
    }

    private IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(_minLifetime, _maxLifetime));

        ReturnConditionReached?.Invoke(this);
    }
}