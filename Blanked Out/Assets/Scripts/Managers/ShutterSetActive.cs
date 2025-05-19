using UnityEngine;

public class ShutterSetActive : MonoBehaviour
{
    public void OpenShutter() 
    {
        gameObject.SetActive(false);
    }

    public void CloseShutter() 
    {
        gameObject.SetActive(true);    
    }


}
