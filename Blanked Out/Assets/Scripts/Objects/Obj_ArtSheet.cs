using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Obj_ArtSheet : MonoBehaviour
{
    //This is the behaviour for the collectible art sheets.
    //To Do:
    //-Create a method to collect it. Walk over it? Turn to the background and press interact?

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You found an artsheet!");
            Destroy(this.gameObject);
        }
    }

}
