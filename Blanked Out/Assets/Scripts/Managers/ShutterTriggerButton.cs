using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.WSA;

public class ShutterTriggerButton : MonoBehaviour
{
    [SerializeField] private ShutterSetActive shutter;
    bool canTrigger = false;

    float coolOff = 0f;

    void Update()
    {
        if (coolOff > 0f)
        {
            coolOff -= Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Vertical") == 1 && canTrigger)
        { 
            Debug.Log("Pushed");
            Activate();

            coolOff = 1f;
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

