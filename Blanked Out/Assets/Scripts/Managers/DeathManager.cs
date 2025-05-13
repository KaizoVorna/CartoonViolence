using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    //This script manages how things die.
    //To Do:
    //-Customize each death function once more assets become available. Fall damage can reference PlayerDamage.

    public void PlayerFallDeath() // This function handles when player falls into pits.
    {
        Reload();
    }

    public void PlayerDamage() // This function handles when player takes damage from attacks, falling from too high, etc.
    {
        Reload();
    }

    void Reload() 
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
