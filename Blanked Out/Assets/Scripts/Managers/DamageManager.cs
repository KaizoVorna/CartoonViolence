using Unity.VisualScripting;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public DeathManager deathManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            deathManager.PlayerDamage();
        }
    }
}
