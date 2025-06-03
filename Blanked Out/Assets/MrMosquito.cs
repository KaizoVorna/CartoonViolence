using UnityEngine;
using UnityEngine.Audio;

public class MrMosquito : MonoBehaviour
{
    public AudioSource soundEffect;

  

    private bool hasPlayed = false;

    private void OnEnable()
    {
        if (!hasPlayed && soundEffect != null)
        {
            soundEffect.Play();
            hasPlayed = true;
        }
    }

    void OnDisable()
    {
        hasPlayed = false;
    }
}
