using UnityEngine;

public sealed class CollectCoinsQuest : MonoBehaviour
{
    [SerializeField] private int target = 5;
    private int _progress;

    private void OnEnable()  => EventBus.Subscribe<ItemCollected>(OnItem);
    private void OnDisable() => EventBus.Unsubscribe<ItemCollected>(OnItem);

    private void OnItem(ItemCollected evt)
    {
        if (evt.ItemId != "coin") return;

        _progress += evt.Amount;
        if (_progress < target) return;
        Debug.Log("Quest complete: Gather Coins!");
        OnDisable();
    }
}