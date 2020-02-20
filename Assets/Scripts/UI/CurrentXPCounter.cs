using TMPro;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CurrentXPCounter : MonoBehaviour
{
    public RectTransform RectTransform => _rectTransform == null?_rectTransform = GetComponent<RectTransform>():_rectTransform;

    [SerializeField] private TextMeshProUGUI textCounter;
    private RectTransform _rectTransform;

    public void NewValue(int value)
    {
        textCounter.text = value.ToString();
    }
}
