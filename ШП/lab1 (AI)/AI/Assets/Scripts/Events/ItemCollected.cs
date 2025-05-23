public readonly struct ItemCollected
{
    public readonly string ItemId;
    public readonly int Amount;

    public ItemCollected(string itemId, int amount = 1)
    {
        ItemId = itemId;
        Amount = amount;
    }
}
