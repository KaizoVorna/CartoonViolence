using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem.EnhancedTouch;

public class Player_Movement : MonoBehaviour
    //This manages Frank's basic movement when unhindered and while carrying something.
    //To Do:
    //-Create a jump script which jumps farther if player is in running state.
    //-Create a mechanic for grabbing ledges incl. pulling up, letting go, descending from standing on a ledge.
    //-Create a carrying state for when Frank is holding a bomb or a key.
    //-Create a climbing state for getting up ropes.
    //-Create a hiding state for the closets, where enemies won't see you but you can't move until you exit.
    //-Should drawing be here too? Or should it be its own script because of the charge mechanic?

{
    // Public variables that can be adjusted in the Unity Inspector
    public float moveSpeed = 5f;         // Movement speed of the player
    public float runSpeed = 10f;        //Speed when running
    public float sneakSpeed = 3f;       //Speed when sneaking
    public Vector2 gridSize = new Vector2(1f, 1f);  // Grid size in world units (controls how far the player moves per step)
    public float jumpForce = 10f;        // Jump force for the player
    public LayerMask groundLayer;        // Layer mask to check for the ground, ensuring the player only jumps when grounded
    public LayerMask ledgeLayer;
    public bool isSneaking = false;     //Check if player is sneaking.
    public bool isCrouching = false;    // Check if the player is crouching. (Count as sneaking?)
    public bool isRunning = false;      //Check if player is running.
    public BoxCollider2D crouchCollider; //Collider that gets disabled when crouching.
    public Player_LedgeMov ledgeMov;     //Reference the LedgeMov-script to turn it on or off.
    public PlayerController controller;  //Reference the PlayerController-script.

    // Private variables for internal calculations
    private Rigidbody2D rb;              // Rigidbody component to handle physics
    private bool isJumping = false;     // Boolean to check if the player is grounded
    private Vector2 targetPosition;      // The position where the player is trying to move to (based on grid)
    private bool isMoving = false;       // Boolean to check if the player is currently moving
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component attached to the player
        targetPosition = transform.position;  // Set the initial target position to the current position
    }

    void Update()
    {
        // Handle player movement input (horizontal movement)
        HandleMovementInput();

        // Handle player jumping input (spacebar)
        HandleJumpInput();

        // Check if the player is grounded (so they can jump)
        CheckIfGrounded();

        //Check if the player touched a ledge
        LedgeDetect();
    }

    private void FixedUpdate()
    {
        // If the player is moving, move them towards the target position
        if (isMoving)
        {
            if (isSneaking || isCrouching)
            {
                // Smoothly move the player towards the target position (on the grid)
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, sneakSpeed * Time.fixedDeltaTime);
            }
            else if (isRunning)
            {
                // Smoothly move the player towards the target position (on the grid)
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, runSpeed * Time.fixedDeltaTime);
            }
            else
            {
                // Smoothly move the player towards the target position (on the grid)
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            }

            // Stop moving if the player reaches the target position
            if ((Vector2)transform.position == targetPosition)
            {
                isMoving = false; // Player has reached the target position
            }


        }

        if (isJumping)
        {
            if (Input.GetKeyDown(KeyCode.D) && isRunning)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX * 2, jumpForce);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);  
            }
            else
            {
                rb.linearVelocity = new Vector2(0, jumpForce);  
            }
                isJumping = false;

        }
    }

    private void HandleMovementInput()
    {
        // If the player is already moving to a grid point, don't process new movement input
        if (isMoving) return;

        // Initialize movement directions
        float moveX = 0f;
        float moveY = 0f;

        // Check for movement input
        if (Input.GetKey(KeyCode.A))

            moveX = -1f; // Move left on the grid

        if (Input.GetKey(KeyCode.D)) 

            moveX = 1f;  // Move right on the grid

        // If there is any movement input, calculate the new target position
        if (moveX != 0f || moveY != 0f)
        {
            Vector2 currentPosition = transform.position;

            // Round the current position to the nearest grid step
            // For example, move to 2.0f instead of 2.5f if gridSize is 1 unit
            targetPosition = new Vector2(
                Mathf.RoundToInt(currentPosition.x + moveX * gridSize.x),  // Calculate the target X position
                Mathf.RoundToInt(currentPosition.y + rb.linearVelocityY)  // Calculate the target Y position
            );
            isMoving = true; // Set moving flag to true, player will start moving to the new target
        }
    }

    private void HandleJumpInput()
    {
        // Only allow jumping if the player is grounded (i.e., standing on the floor)
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void LedgeDetect()
    {
        //Activate if player detects that he has connected to a ledge while jumping.
        if (isJumping)
        {
            ledgeMov.enabled = false;

        }
    }

    private void CheckIfGrounded()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            crouchCollider.enabled = false;
            isCrouching = true;
            isSneaking = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouchCollider.enabled = true;
            isCrouching = false;
            isSneaking = false;
        }

        if (Input.GetButtonDown("Sneak"))
        {
            isSneaking = true;
        }
        else if (Input.GetButtonUp("Sneak"))
        {
            isSneaking = false;
        }

        if (Input.GetButtonDown("Run"))
        {
            isRunning = true;
        }
        else if (Input.GetButtonUp("Run"))
        {
            isRunning = false;
        }
    }
    public void OnLanding()
    {
        ledgeMov.enabled = false;
    }
}
