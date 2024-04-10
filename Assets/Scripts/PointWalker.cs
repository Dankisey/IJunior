using UnityEngine;

public class PointWalker : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed = 5f;
    [SerializeField]
    [Range(0f, 1f)] private float _newTargetDistance = 0.3f;

    private Transform _currentTarget;
    private Transform _transform;
    private int _currentPoint = 0;

    private void Awake()
    {
        _transform = transform;
        SetNewTarget();
    }

    private void Update()
    {
        Vector3 direction = _currentTarget.position - _transform.position;
        _transform.Translate(direction.normalized * _speed * Time.deltaTime);

        if ((_currentTarget.position - _transform.position).magnitude <= _newTargetDistance)
            SetNewTarget();
    }

    private void SetNewTarget()
    {
        _currentTarget = _points[_currentPoint];
        _currentPoint++;

        if (_currentPoint >= _points.Length)
            _currentPoint = 0;
    }
}