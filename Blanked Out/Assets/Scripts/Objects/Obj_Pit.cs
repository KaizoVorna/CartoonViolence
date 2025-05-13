using UnityEngine;

public class Obj_Pit : MonoBehaviour
{
    //This is the behaviour script for Annow Pits.
    //To Do:
    //-Make it a trigger collider that triggers the pit death script for any entity that falls in.
    //-Customize each death appropriately once there's more assets, falling screams, animations, etc.

    public DeathManager deathManager;

    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            deathManager.PlayerFallDeath();
        }
        else if (entity.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
