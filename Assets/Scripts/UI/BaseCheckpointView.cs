using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public abstract class BaseCheckpointView: MonoBehaviour
{
    [SerializeField] private bool isChecked;
    [SerializeField] private int points;
    [SerializeField] private TextMeshProUGUI textPoints;
    [SerializeField] private GameObject platformHighlight;
    [SerializeField] private GameObject checkIcon;

    private readonly Color _disabledColor = new Color(0.5f,0.5f,0.5f);
    private Animator _animator;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.enabled = false;
        ShowHighlight(isChecked);
        ShowCheck(isChecked);
        ShowPoints(points);
        if (isChecked) DisableIcon();
    }

    public void Activate()
    {
        isChecked = true;
        ShowCheck(isChecked);
        ShowHighlight();
        DisableIcon();
        _animator.enabled = true;
    }

    private void ShowHighlight(bool value = true)
    {
        platformHighlight.SetActive(value);
    }

    private void ShowCheck(bool value = true)
    {
        checkIcon.SetActive(value);
    }

    private void ShowPoints(int value = 0)
    {
        if (value == 0)
        {
            textPoints.gameObject.SetActive(false);
        }
        else
        {
            textPoints.text = value.ToString();
        }
    }

    protected void ChangeColorToDisabled(Image image)
    {
        image.color = _disabledColor;
    }

    protected abstract void DisableIcon();
}