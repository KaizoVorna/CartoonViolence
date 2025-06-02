using NUnit.Framework.Constraints;
using UnityEditor.Experimental.GraphView;
using UnityEngine;





public class ShutterSetActive : MonoBehaviour
{


   

    public bool isOpen = false;
    public void ToggleShutter() 
    {

        if (gameObject.activeSelf)
        {
            
            isOpen = true;
            gameObject.SetActive(false);
            

        }
        else 
        {
            
            isOpen = false;
            gameObject.SetActive(true);
            
        }
    }

    public void CloseShutter() 
    {
       
        gameObject.SetActive(true);    
    }


}
