using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    //This script manages how things die.
    //To Do:
    //-Customize each death function once more assets become available. Fall damage can reference PlayerDamage.

    public void PlayerFallDeath()
    {
        Reload();
    }

    public void PlayerDamage()
    {
        Reload();
    }

    void Reload() 
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
