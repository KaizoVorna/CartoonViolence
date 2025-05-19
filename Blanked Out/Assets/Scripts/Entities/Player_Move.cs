
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class Player_Move : MonoBehaviour
{
    [Header("References")]
    public PlayerController controller;
    public Rigidbody2D rb;
    public LayerMask ledgeLayer;        // Layer mask to check for ledges, so that player will latch on.)

    [Header("Booleans")]
    public bool isSneaking = false;     //Check if player is sneaking.
    public bool isCrouching = false;    // Check if the player is crouching. (Count as sneaking?)
    public bool isRunning = false;      //Check if player is running.
    public bool isJumping = false;      //Check if the player's feet are in the air.

    [Header("Calculations")]
    public float horizontalMove = 0;
    public float sneakSpeed = 0.5f;
    public float moveSpeed = 1f;
    public float runSpeed = 2f;

    void Update()
    {
        //This is where the player input is taken care of.
        if (Input.GetButtonDown("Jump") && controller.IsGrounded)
        {
            isJumping = true;
        }

        if (Input.GetButton("Sneak"))
        {
            isSneaking = true;
        }
        else
        {
            isSneaking = false;
        }

        if (Input.GetButton("Run"))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (Input.GetButton("Crouch"))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
    }

    void FixedUpdate()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (isSneaking)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime * sneakSpeed, isCrouching, isJumping);
            isJumping = false;
        }
        else if (isRunning)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime * runSpeed, isCrouching, isJumping);
            isJumping = false;
        }
        else
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);
            isJumping = false;
        }
    }
}
