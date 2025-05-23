using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class InventorySlotUI : MonoBehaviour
{
    [SerializeField]
    private RawImage preview;

    [SerializeField]
    private TMP_Text label;

    public void Bind(WeaponFlyweight fw)
    {
        preview.texture = WeaponPreviewPool.Instance.GetPreview(fw);
        label.text = fw.name;
    }
}
