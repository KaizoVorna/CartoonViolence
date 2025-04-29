using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

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
    public bool isMoving = false;       //Check if the player is already moving.

    [Header("Calculations")]
    public float gridSizeX = 128;
    public float gridSizeY = 128;
    public float horizontalMove = 0;
    public float sneakSpeed = 0.5f;
    public float runSpeed = 2f;
    public float jumpDistance = 2f;
    public float jumpHeight = 1f;

    void Update()
    {
        DistanceCalc();
        BoolChecker();
    }

    void FixedUpdate()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (isJumping || isMoving) return; //Make sure player input is ignored while moving or jumping.
        //This is where the player input is taken care of.
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0f)
        {
            isMoving = true;
            controller.Move(horizontalMove * gridSizeX * Time.fixedDeltaTime, isCrouching, isJumping);
            isMoving = false;
        }

    }

    public void DistanceCalc()
    {

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
        if (controller.IsGrounded)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }
    }
}
