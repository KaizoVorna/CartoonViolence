using UnityEngine;

public class Player_Move : MonoBehaviour
{
    [Header("References")]
    public PlayerController controller;
    public Rigidbody2D rb;
    public BoxCollider2D crouchCollider;  //The collider that's turned off when the player crouches.
    public LayerMask groundLayer;        // Layer mask to check for the ground, ensuring the player only jumps when grounded
    public LayerMask ledgeLayer;        // Layer mask to check for ledges, so that player will latch on.)

    [Header("Booleans")]
    public bool isSneaking = false;     //Check if player is sneaking.
    public bool isCrouching = false;    // Check if the player is crouching. (Count as sneaking?)
    public bool isRunning = false;      //Check if player is running.
    public bool isJumping = false;      //Check if the player's feet are in the air.

    [Header("Calculations")]
    public Vector2 gridSize = new Vector2(1f, 1f);  // Grid size in world units (controls how far the player moves per step)

    void Update()
    {
        BoolChecker();
    }

    void FixedUpdate()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        //This is where the player input is taken care of.
    }

    private void BoolChecker()
    {
        //This is where all the booleans are checked and updated.
        if (Input.GetButtonDown("Sneak"))
        {
            isSneaking = true;
        }
        else
        {
            isSneaking = false;
        }
        if (Input.GetButtonDown("Run"))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
        if (!controller.IsGrounded)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }
}
