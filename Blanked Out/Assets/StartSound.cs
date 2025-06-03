using UnityEngine;
using UnityEngine.Audio;

public class StartSound : MonoBehaviour
{


    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip startSound;
    private static bool hasPlayed = false;



    private void Start()
    {
        if (!hasPlayed)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = startSound;

            audioSource.playOnAwake = false;

            audioSource.volume = 0.5f;

            audioSource.PlayOneShot(startSound);
            hasPlayed = true;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }




}