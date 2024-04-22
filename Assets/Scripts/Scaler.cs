using DG.Tweening;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _scaleFactor;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        Vector3 targetScale = Vector3.one * _scaleFactor;

        transform.DOScale(targetScale, _duration)
            .SetLoops(-1, _loopType)
            .SetEase(Ease.Linear);
    }
}