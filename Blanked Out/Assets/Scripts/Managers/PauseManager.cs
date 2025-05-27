using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject artMenuUI;
    public GameObject optionsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        isGamePaused = false;

        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        isGamePaused = true;

        Time.timeScale = 0f;
    }

    public void LoadCheckpoint()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1f;
    }

    public void CheckArt()
    {
        pauseMenuUI.SetActive(false);
        artMenuUI.SetActive(true);
    }

    public void Options()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }
     public void ReturnMenu()
    {
        artMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void ReturnTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
