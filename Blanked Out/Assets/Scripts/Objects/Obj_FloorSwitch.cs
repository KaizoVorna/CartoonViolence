using UnityEngine;
using UnityEngine.Audio;

public class Obj_FloorSwitch : MonoBehaviour
{
    //This is the behaviour script for Pressure Plates.
    //To Do:
    //-Create a pressed state, which toggles the script of the associated object for as long as an object is on the switch.

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip PushButtonSound;
   

    [SerializeField] private ShutterSetActive shutter1;
    [SerializeField] private ShutterSetActive shutter2;
    bool isPressed;

    private void OnTriggerStay2D(Collider2D collision)
    {   
        if (!isPressed)
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(PushButtonSound);
            }
            Activate();
        }
        isPressed = true;
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        Activate();
        isPressed = false;
    }
    
    public void Activate()
    {
        if (shutter1 != null)
        {
            shutter1.ToggleShutter();
        }

        if (shutter2 != null)
        {
            shutter2.ToggleShutter();
        }
        
    }
    
}
