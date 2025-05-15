 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrawBadManager : MonoBehaviour
{

    public GameObject drawpbadMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("DrawBad"))
        {
            drawpbadMenuUI.SetActive(true);
        }
        else if (Input.GetButtonUp("DrawBad"))
        {
            drawpbadMenuUI.SetActive(false);
        }
        
    }
}
