 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrawBadManager : MonoBehaviour
    
{

    public GameObject drawpbadMenuUI;
    public float followSpeed = 15f;
    public Transform player;
    public Vector2 startPos;

    void Start()
    {
        startPos = drawpbadMenuUI.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("DrawBad"))
        {

            drawpbadMenuUI.SetActive(true);
            drawpbadMenuUI.transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
            player.GetComponent<Player_Move>().enabled = false;
        }
        else if (Input.GetButtonUp("DrawBad"))
        {
            
            drawpbadMenuUI.transform.position = startPos;
            drawpbadMenuUI.SetActive(false);
            player.GetComponent<Player_Move>().enabled = true;

        }
      
        
    }
}
