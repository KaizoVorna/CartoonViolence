using System.Collections;
using UnityEngine;

public class Player_LedgeMov : MonoBehaviour
{
    public Player_Move movement; //Reference player movement to turn it on and off.
    public bool isHanging = false;
    private bool redBox, greenBox, blueBox;
    public float redXOffset, redYOffset, redXSize, redYSize, greenXOffset, greenYOffset, greenXSize, greenYSize, blueXOffset, blueYOffset, blueXSize, blueYSize;
    private Rigidbody2D rb;
    private float startingGrav;
    public LayerMask Ledge;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingGrav = rb.gravityScale; 
    }

    private void Update()
    {
        greenBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (greenXOffset * transform.localScale.x), transform.position.y + greenYOffset), new Vector2(greenXSize, greenYSize), 0f, Ledge);
        redBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (redXOffset * transform.localScale.x), transform.position.y + redYOffset), new Vector2(redXSize, redYSize), 0f, Ledge);
        blueBox = Physics2D.OverlapBox(new Vector2(transform.position.x + (blueXOffset * transform.localScale.x), transform.position.y + blueYOffset), new Vector2(blueXSize, blueYSize), 0f, Ledge);

        if (greenBox && !redBox && !blueBox && !isHanging)
        {
            rb.linearVelocity = new Vector2(0f, 0f);
            rb.gravityScale = 0f;
            isHanging = true;
            movement.enabled = false;
        }
    }

    //This is the movement script related to Ledge Grabbing, where you can only pull yourself up or drop down.
    void FixedUpdate()
    {
        if (isHanging)
        {
            if (Input.GetKey(KeyCode.S))
            {
                //Drop down
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.4f);
                rb.gravityScale = startingGrav;
                isHanging = false;
                movement.enabled = true;
            }

            if (Input.GetKey(KeyCode.W))
            {
                //Climb up
                rb.bodyType = RigidbodyType2D.Kinematic;
                transform.position = new Vector2(transform.position.x + (0.5f * transform.localScale.x), transform.position.y + 0.4f);
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = startingGrav;
                isHanging = false;
                movement.enabled = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + (redXOffset * transform.localScale.x), transform.position.y + redYOffset), new Vector2(redXSize, redYSize));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + (greenXOffset * transform.localScale.x), transform.position.y + greenYOffset), new Vector2(greenXSize, greenYSize));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + (blueXOffset * transform.localScale.x), transform.position.y + blueYOffset), new Vector2(blueXSize, blueYSize));
    }

}

