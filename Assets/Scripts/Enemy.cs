using UnityEngine;

internal class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;
    private Transform _target;

    private void OnEnable()
    {
        _transform = transform;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
            return;

        Vector3 direction = _target.position - _transform.position;

        _transform.Translate(direction.normalized * _speed * Time.deltaTime);
    }
}