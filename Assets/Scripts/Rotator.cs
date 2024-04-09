using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        Quaternion rotation = Quaternion.AngleAxis(_speed * Time.deltaTime, Vector3.up);
        _transform.rotation *= rotation;
    }
}