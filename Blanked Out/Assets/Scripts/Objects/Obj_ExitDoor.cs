using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

public class Obj_ExitDoor : MonoBehaviour
{
    //This is the exit door signaling the end of a zone.
    //If Frank touches it, he will automatically open it, becoming invincible for the animation. 
    //After animation finishes, load the next scene.

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip OpenDoorSound;

    

    public GameObject loadingScreen; //This is in case it's needed, e.g. when changing areas (as opposed to zones within an area.)
    public int sceneIndex;
    public Player_Move movement;
    public DrawBadManager drawBad;
    public Animator thisAnimator;
    public Animator playerAnimator;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            movement.enabled = false;
            drawBad.enabled = false;
            thisAnimator.Play("Open");
            StartCoroutine(LoadSceneAsync(sceneIndex));
            audioSource.PlayOneShot(OpenDoorSound);
        }
    }

    IEnumerator LoadSceneAsync(int index)
    {
        //Activate LoadingScreen
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        //Start loading the next scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        operation.allowSceneActivation = false;

        //Activate the new scene
        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(2f);
                operation.allowSceneActivation = true;
                movement.enabled = true;
                drawBad.enabled = true;
            }

            yield return null;
        }
    }
}
