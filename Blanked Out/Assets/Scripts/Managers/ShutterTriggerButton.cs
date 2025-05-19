using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.WSA;

public class ShutterTriggerButton : MonoBehaviour
{
    [SerializeField] private ShutterSetActive shutter;

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Pushed");
                Activate();
            }

        }
    }

    public void Activate()
    {
        shutter.ToggleShutter();
    }    

}

