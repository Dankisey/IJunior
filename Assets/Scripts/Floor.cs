using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out FallingCube fallingCube))
            fallingCube.DoCollisionLogic();
    }
}