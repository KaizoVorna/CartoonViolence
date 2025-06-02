using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour

    

{

    [Header("Audio")]                   // Added a script for game start
    public AudioSource audioSource;
    public AudioClip StartSound;
    private static bool hasPlayed = false;


    void Start()
    {
        if (!hasPlayed)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = StartSound;

            audioSource.playOnAwake = false;

            audioSource.volume = 1.0f;


            audioSource.PlayOneShot(StartSound);
            hasPlayed = true;
        }
        
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



    //This is the manager for music, audio cues, etc.
    //To Do:
    //-Create a ground for music changes, situational music?


}
