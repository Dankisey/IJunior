using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private float _duration;

    private void Start()
    {
        float delay = 1f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(_text.DOText("замена текста", _duration).SetEase(Ease.Linear));
        sequence.Append(_text.DOText(" добавление к тексту", _duration).SetRelative().SetEase(Ease.Linear).SetDelay(delay));
        sequence.Append(_text.DOText("взлом перебором", _duration, true, ScrambleMode.Lowercase).SetEase(Ease.Linear));
        sequence.SetLoops(-1, LoopType.Restart);
    }
}