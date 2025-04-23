using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Obj_ArtSheet : MonoBehaviour
{
    //This is the behaviour for the collectible art sheets.
    //To Do:
    //-Create a method to collect it. Walk over it? Turn to the background and press interact?

    public delegate void OnCollect(int value);
    public static event OnCollect onCollect;

    [SerializeField]
    private int amount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onCollect.Invoke(amount);
            Destroy(gameObject);
        }
    }
   
}
