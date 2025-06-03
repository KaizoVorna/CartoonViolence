using UnityEngine;
using UnityEngine.Audio;

public class MetalDoorClosed : MonoBehaviour
{


    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip MDOORC;
    private static bool hasPlayed = false;



    private void Start()
    {
        if (!hasPlayed)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = MDOORC;

            audioSource.playOnAwake = false;

            audioSource.volume = 0.5f;

            audioSource.PlayOneShot(MDOORC);
            hasPlayed = true;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }




}
