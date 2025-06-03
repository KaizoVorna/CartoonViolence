using UnityEngine;
using UnityEngine.SceneManagement;

public class Obj_FuntPit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D entity)
    {
        if (entity.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
        else if (entity.tag == "Enemy") // Can be turned around in that it calls each enemy's individual death scream?
        {
            Destroy(entity);
        }
        else // This is for inanimate objects that fall in.
        {
            Destroy(entity);
        }
    }
}
