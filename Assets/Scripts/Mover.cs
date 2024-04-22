using DG.Tweening;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 _movement;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        transform.DOMove(_movement, _duration)
            .SetLoops(-1, _loopType)
            .SetEase(Ease.Linear)
            .SetRelative();
    }
}