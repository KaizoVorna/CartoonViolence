using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.WSA;
using UnityEngine.Audio;

public class ShutterTriggerButton : MonoBehaviour
{

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip OpenDoorSound;

    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();

            audioSource.Play();
        }


    }

    [SerializeField] private ShutterSetActive shutter1;
    [SerializeField] private ShutterSetActive shutter2;
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
            if (audioSource != null)
            {
                audioSource.PlayOneShot(OpenDoorSound);
            }
            coolOff = 3f;
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

