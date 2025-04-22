using Unity.VisualScripting;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    }

    public void CheckArt()
    {

    }

    public void Options()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
