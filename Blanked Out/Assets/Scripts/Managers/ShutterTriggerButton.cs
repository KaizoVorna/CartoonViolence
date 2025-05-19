using UnityEngine;

public class ShutterTriggerButton : MonoBehaviour
{
    [SerializeField] private ShutterSetActive shutter;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            shutter.ToggleShutter();
        }
    }


        

}

