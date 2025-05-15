using System.Collections;
using UnityEngine;

public class Player_LedgeMov : MonoBehaviour
{
    public Player_Move movement; //Reference player movement to turn it on and off.
    public bool isHanging = false;
    public bool redBox, greenBox, blueBox;
    private Rigidbody2D rb;
    private float startingGrav;
    public LayerMask Ledge;
    public LayerMask Ground;
    public Transform ledgeGrabber;
    public Transform directBoxUp;
    public Transform directBoxBehind;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingGrav = rb.gravityScale; 
    }

    private void Update()
    {
        greenBox = Physics2D.OverlapBox(new Vector2(ledgeGrabber.position.x, ledgeGrabber.position.y), new Vector2(ledgeGrabber.localScale.x, ledgeGrabber.localScale.y), 0f, Ledge);
        redBox = Physics2D.OverlapBox(new Vector2(directBoxUp.position.x, directBoxUp.position.y), new Vector2(directBoxUp.localScale.x, directBoxUp.localScale.y), 0f, Ledge);
        blueBox = Physics2D.OverlapBox(new Vector2(directBoxBehind.position.x, directBoxBehind.position.y), new Vector2(directBoxBehind.localScale.x, directBoxBehind.localScale.y), 0f, Ground);

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
                transform.position = new Vector2(transform.position.x + (0.5f * transform.localScale.x), transform.position.y + 2.4f);
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = startingGrav;
                isHanging = false;
                movement.enabled = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (ledgeGrabber != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(ledgeGrabber.position, ledgeGrabber.localScale);
        }

        if (directBoxUp != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(directBoxUp.position, directBoxUp.localScale);
        }

        if (directBoxBehind != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(directBoxBehind.position, directBoxBehind.localScale);
        }

    }

}

