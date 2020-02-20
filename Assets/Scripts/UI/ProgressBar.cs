using DG.Tweening;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private RectTransform progressBar;
    [SerializeField] private RectTransform progressBarTarget;
    [SerializeField] private CurrentXPCounter xpCounter;

    public void SetTarget(int value)
    {
        var size = progressBarTarget.sizeDelta;
        size.x = value;
        progressBarTarget.sizeDelta = size;
    }

    public int MoveTo(int position, int xpTo, int xpFrom, float speed)
    {
        progressBar.DOSizeDelta(new Vector2(position, progressBar.sizeDelta.y), speed).SetEase(Ease.InOutSine);
        var counterPos = new Vector2(position - 89, xpCounter.RectTransform.anchoredPosition.y);
        xpCounter.RectTransform.DOAnchorPos(counterPos, speed).SetEase(Ease.InOutSine);

        DOTween
            .To(() => xpFrom, v => xpFrom = v, xpTo, speed)
            .SetEase(Ease.InOutSine)
            .OnUpdate(() => { xpCounter.NewValue(xpFrom); });
        return xpTo;
    }
}
