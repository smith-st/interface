using UnityEngine;
using UnityEngine.UI;

public class SimpleIconBaseCheckpointView: BaseCheckpointView
{
    [Space]
    [SerializeField] private Image iconImage;

    protected override void DisableIcon()
    {
        ChangeColorToDisabled(iconImage);
    }
}