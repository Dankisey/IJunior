using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _growthSpeed;

    private Transform _transform;
    private float _scale = 1f;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _scale += _growthSpeed * Time.deltaTime;
        _transform.localScale = new Vector3(_scale, _scale, _scale);
    }
}