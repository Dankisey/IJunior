using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Quaternion rotation = Quaternion.AngleAxis(_speed * Time.deltaTime, Vector3.up);
        transform.rotation *= rotation;
    }
}