using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeathManager : MonoBehaviour
{
    //This script manages how things die.
    //To Do:
    //-Customize each death function once more assets become available. Fall damage can reference PlayerDamage.

    public GameObject deathScreen;
    public Player_Move movement;
    public DrawBadManager drawBad;
    public Animator animator;

    public void PlayerFallDeath() // This function handles when player falls into pits.
    {
        Reload();
    }

    public void PlayerDamage() // This function handles when player takes damage from attacks, falling from too high, etc.
    {
        animator.Play("FrankDeath");
        Reload();
    }

    public void Crush()
    {
        if (this.tag == "Player")
        {
            Reload();
        }
        else
        {
            Destroy(this.gameObject);   
        }
    }

    void Reload() 
    {
        Time.timeScale = 0f;
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadSceneAsync(currentScene));
        Time.timeScale = 1f;
    }

    IEnumerator LoadSceneAsync(int index)
    {
        //Activate LoadingScreen
        if (deathScreen != null)
            deathScreen.SetActive(true);

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
