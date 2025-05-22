
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneIndex;

   public void PlayGame ()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

}
