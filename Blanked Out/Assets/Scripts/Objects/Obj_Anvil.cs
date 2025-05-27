using UnityEngine;

public class Obj_Anvil : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        DeathManager hit = target.transform.GetComponent<DeathManager>();
        if (hit != null)
        {
            hit.Crush();
        }
    }
}
