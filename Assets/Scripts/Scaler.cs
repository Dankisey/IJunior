using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _growthSpeed;

    private float _scale = 1f;

    private void Update()
    {
        _scale += _growthSpeed * Time.deltaTime;
        transform.localScale = new Vector3(_scale, _scale, _scale);
    }
}