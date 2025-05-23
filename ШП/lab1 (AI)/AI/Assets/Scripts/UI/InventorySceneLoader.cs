using UnityEngine;

public sealed class InventorySceneLoader : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Transform content; // GridLayoutGroup

    [SerializeField]
    private InventorySlotUI slotPrefab;

    private void Start()
    {
        var weapons = Resources.LoadAll<WeaponFlyweight>("Weapons");
        foreach (var fw in weapons)
        {
            var slot = Instantiate(slotPrefab, content);
            slot.Bind(fw);
        }
    }
}
