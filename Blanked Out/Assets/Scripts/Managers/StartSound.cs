using UnityEngine;
using UnityEngine.Audio;

public class startSound : MonoBehaviour

    

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





}
