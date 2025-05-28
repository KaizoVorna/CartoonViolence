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

        if (gameObject.activeSelf)
        {
            audioSource.PlayOneShot(OpenDoorSound);
            isOpen = true;
            gameObject.SetActive(false);

        }
        else 
        {
            
            isOpen = false;
            gameObject.SetActive(true);
            audioSource.PlayOneShot(CloseDoorSound);
        }
    }

    public void CloseShutter() 
    {
        audioSource.PlayOneShot(CloseDoorSound);
        gameObject.SetActive(true);    
    }


}
