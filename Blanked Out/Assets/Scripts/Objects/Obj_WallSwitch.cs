
using UnityEngine;
using UnityEngine.Events;

public class Obj_WallSwitch : MonoBehaviour
{
    //This is the behaviour script for the switches on the background walls.
    //To Do:
    //-Make it a background interactable which toggles the associated object's active and inactive states.

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    void Start()
    {
        
    }


    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            isInRange = true;
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player isn't in range");
        }
    }

}

