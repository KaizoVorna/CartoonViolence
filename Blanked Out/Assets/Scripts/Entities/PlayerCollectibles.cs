using UnityEngine;

public class PlayerCollectibles : MonoBehaviour
{
    public CollectibleManager manager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            manager.count++;
        }
    }
}
