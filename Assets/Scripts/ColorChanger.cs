using DG.Tweening;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        _material.DOColor(_targetColor, _duration)
            .SetLoops(-1, _loopType)
            .SetEase(Ease.Linear);  
    }
}