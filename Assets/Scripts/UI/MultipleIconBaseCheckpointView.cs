using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MultipleIconBaseCheckpointView: BaseCheckpointView
{
    [Space]
    [SerializeField] private CheckpointType iconType;
    [SerializeField] private IconAsset[] icons;

    [Serializable]
    private struct IconAsset
    {
        public CheckpointType type;
        [FormerlySerializedAs("Image")] public Image image;
    }

    protected override void Awake()
    {
        base.Awake();
        ShowIcon();
    }

    protected override void DisableIcon()
    {
        foreach (var icon in icons)
        {
            if (icon.image.gameObject.activeSelf)
            {
                ChangeColorToDisabled(icon.image);
            }
        }
    }

    private void ShowIcon()
    {
        foreach (var icon in icons)
        {
            icon.image.gameObject.SetActive(icon.type == iconType);
        }
    }
}