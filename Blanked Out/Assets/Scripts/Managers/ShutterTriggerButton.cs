using UnityEngine;

public class ShutterTriggerButton : MonoBehaviour
{
    [SerializeField] private ShutterSetActive shutter;

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                shutter.ToggleShutter();
            }
        }
    }


        

}

