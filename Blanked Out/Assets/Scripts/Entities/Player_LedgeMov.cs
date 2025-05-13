using System.Collections;
using UnityEngine;

public class Player_LedgeMov : MonoBehaviour
{
    public Player_Move movement; //Reference player movement to turn it on and off.
    public bool isHanging = false;
    private bool redBox, greenBox;
    public float redXOffset, redYOffset, redXSize, redYSize, greenXOffset, greenYOffset, greenXSize, greenYSize;
    private Rigidbody2D rb;
    private float startingGrav;
    public LayerMask Ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingGrav = rb.gravityScale; 
    }

    private void Update()
    {
        greenBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (greenXOffset * transform.localScale.x), transform.position.y + greenYOffset), new Vector2(greenXSize, greenYSize), 0f, Ground);
        redBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (redXOffset * transform.localScale.x), transform.position.y + redYOffset), new Vector2(redXSize, redYSize), 0f, Ground);
    }

    //This is the movement script related to Ledge Grabbing, where you can only pull yourself up or drop down.
    void FixedUpdate()
    {
        if (isHanging)
        {
            if (Input.GetKey(KeyCode.S))
            {
                //Drop down
                movement.enabled = true;
                this.enabled = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                //Climb up
                movement.enabled = true;
                this.enabled = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + (redXOffset * transform.localScale.x), transform.position.y + redYOffset), new Vector2(redXSize, redYSize));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + (greenXOffset * transform.localScale.x), transform.position.y + greenYOffset), new Vector2(greenXSize, greenYSize));
    }

}

