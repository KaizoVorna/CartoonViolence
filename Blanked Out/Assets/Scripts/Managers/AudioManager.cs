using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour

    

{

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip StartSound;


    void Start()
    {
        audioSource.clip = StartSound;

        audioSource.playOnAwake = false;
        audioSource.volume = 1.0f;

        audioSource.PlayOneShot(StartSound);
    }

  

    //This is the manager for music, audio cues, etc.
    //To Do:
    //-Create a ground for music changes, situational music?

    
}
