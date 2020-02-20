using DG.Tweening;
using TMPro;
using UnityEngine;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCounter;

    private int _count = 116;

    private void Awake()
    {
        ChangeValue(_count);
    }

    public void AddCoins(int value, float speed)
    {
        var counterValue = _count;
        var to = _count + value;
        DOTween
            .To(() => counterValue, v => counterValue = v, to, speed)
            .SetEase(Ease.InOutSine)
            .OnUpdate(() => { ChangeValue(counterValue); });
    }

    private void ChangeValue(int value)
    {
        textCounter.text = value.ToString();
    }
}
