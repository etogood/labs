using UnityEngine;

[RequireComponent(typeof(Collider))]
public sealed class PickupItem : MonoBehaviour
{
    [SerializeField]
    private string itemId = "coin";

    [Min(1)]
    [SerializeField]
    private int amount = 1;

    [SerializeField]
    private AudioClip sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        EventBus.Publish(new ItemCollected(itemId, amount));

        if (sfx)
            AudioSource.PlayClipAtPoint(sfx, transform.position);

        Destroy(gameObject);
    }
}
