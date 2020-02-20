using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Button))]
public class ButtonPlay : MonoBehaviour
{
    public UnityEvent onClick;
    private bool _isClickable = true;
    private Button _button;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickOnButton);
    }

    private void ClickOnButton()
    {
        if (!_isClickable) return;
        _isClickable = false;
        AnimateClick();
        onClick?.Invoke();
    }

    private void AnimateClick()
    {
        _rectTransform.DOScale(0.9f, 0.15f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
    }
}
