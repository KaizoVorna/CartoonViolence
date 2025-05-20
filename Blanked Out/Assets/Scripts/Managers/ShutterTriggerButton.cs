using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.WSA;

public class ShutterTriggerButton : MonoBehaviour
{
    [SerializeField] private ShutterSetActive shutter;
    bool canTrigger = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canTrigger)
        {
            Debug.Log("Pushed");
            Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTrigger = false;
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        Debug.Log("Something detected");
        if (player.tag == "Player")
        {
            Debug.Log("Player Detected");
            canTrigger = true;

        }
    }

    public void Activate()
    {
        shutter.ToggleShutter();
    }    

}

