using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerInventory : MonoBehaviour
{
    private readonly Dictionary<string, int> _items = new();

    private void OnEnable() => EventBus.Subscribe<ItemCollected>(OnItem);

    private void OnDisable() => EventBus.Unsubscribe<ItemCollected>(OnItem);

    private void OnItem(ItemCollected evt)
    {
        _items.TryGetValue(evt.ItemId, out var cur);
        _items[evt.ItemId] = cur + evt.Amount;
        Debug.Log($"Picked up {evt.Amount}×{evt.ItemId}. Now: {_items[evt.ItemId]}");
    }
}
