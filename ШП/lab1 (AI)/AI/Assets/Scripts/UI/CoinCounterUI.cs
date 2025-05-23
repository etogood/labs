using TMPro;
using UnityEngine;

public sealed class CoinCounterUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;
    private int _coins;

    private void OnEnable() => EventBus.Subscribe<ItemCollected>(OnItem);

    private void OnDisable() => EventBus.Unsubscribe<ItemCollected>(OnItem);

    private void OnItem(ItemCollected evt)
    {
        if (evt.ItemId != "coin")
            return;
        _coins += evt.Amount;
        label.text = _coins.ToString("N0");
    }
}
