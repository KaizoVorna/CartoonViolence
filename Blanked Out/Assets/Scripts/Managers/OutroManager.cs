using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroManager : MonoBehaviour
{
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;
    public GameObject Screen4;

    public void Step1()
    {
        Screen1.SetActive(false);
        Screen2.SetActive(true);
    }

    public void Step2() 
    {
        Screen2.SetActive(false);
        Screen3.SetActive(true);
    }

    public void Step3()
    {
        Screen3.SetActive(false);
        Screen4.SetActive(true);
    }

    public void Step4()
    {
        Screen4.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
