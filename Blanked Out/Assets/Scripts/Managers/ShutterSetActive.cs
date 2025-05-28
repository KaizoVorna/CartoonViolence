using NUnit.Framework.Constraints;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class ShutterSetActive : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip OpenDoorSound;
    public AudioClip CloseDoorSound;

    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();

            audioSource.Play();
        }

               
    }

    public bool isOpen = false;
    public void ToggleShutter() 
    {
        audioSource.PlayOneShot(OpenDoorSound);
        if (!isOpen)
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
        audioSource.PlayOneShot(CloseDoorSound);
        gameObject.SetActive(true);    
    }


}
