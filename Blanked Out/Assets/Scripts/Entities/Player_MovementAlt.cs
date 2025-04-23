using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public variables (adjustable in Unity Inspector)
    public float walkSpeed = 3f;       // Walking speed
    public float runSpeed = 6f;        // Running speed
    public float jumpForce = 12f;      // Jump force
    public float sneakSpeed = 1.5f;    // Sneak speed
    public float acceleration = 5f;    // Acceleration when walking or running
    public float deceleration = 5f;    // Deceleration when stopping
    public float gravityScale = 2f;    // Custom gravity scale for smooth jumps

    // Private variables
    private Rigidbody2D rb;
    private bool isGrounded = false;   // Check if the player is on the ground
    private bool isRunning = false;    // Check if the player is running
    private bool isSneaking = false;   // Check if the player is sneaking
    private bool isJumping = false;    // Check if the player is in the air
    private Vector2 velocity;          // Player's current velocity
    private float currentSpeed = 0f;   // The current movement speed (smooth transition between walking, running, sneaking)

    private const string groundCheckLayer = "Ground";  // Layer name to check for ground

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
        rb.gravityScale = gravityScale;    // Apply custom gravity
    }

    void Update()
    {
        // Handle movement input
        HandleMovementInput();

        // Handle jumping input
        HandleJumpInput();

        // Handle sneaking input
        HandleSneakInput();

        // Update player grounded status
        CheckIfGrounded();
    }

    void FixedUpdate()
    {
        // Move the player based on the current speed and smooth acceleration
        MovePlayer();
    }

    private void HandleMovementInput()
    {
        // Get horizontal movement input (A/D keys or left/right arrows)
        float moveX = Input.GetAxisRaw("Horizontal");

        // Smooth transition between walking, running, and idle
        if (moveX != 0 && !isSneaking)
        {
            if (Input.GetKey(KeyCode.LeftShift))  // If the player holds shift, run
            {
                isRunning = true;
                isSneaking = false;
            }
            else if (Input.GetKey(KeyCode.LeftControl))  // If control is held, sneak
            {
                isSneaking = true;
                isRunning = false;
            }
            else  // Normal walking state
            {
                isRunning = false;
                isSneaking = false;
            }
        }
        else
        {
            isRunning = false;
            isSneaking = false;
        }

        // Set target speed based on current state
        if (isRunning) currentSpeed = runSpeed;
        else if (isSneaking) currentSpeed = sneakSpeed;
        else currentSpeed = walkSpeed;

        // Apply horizontal movement input with smooth acceleration and deceleration
        velocity.x = Mathf.MoveTowards(velocity.x, moveX * currentSpeed, acceleration * Time.deltaTime);
    }

    private void HandleJumpInput()
    {
        // Jump only if grounded
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);  // Apply jump force
        }
    }

    private void HandleSneakInput()
    {
        // Sneak input (if not holding shift, player can sneak by pressing control)
        if (Input.GetKey(KeyCode.LeftControl) && !isRunning)
        {
            isSneaking = true;
        }
        else
        {
            isSneaking = false;
        }
    }

    private void MovePlayer()
    {
        // Apply smooth movement based on velocity
        if (Mathf.Abs(velocity.x) > 0.1f)
        {
            // Apply the velocity to move the player
            rb.linearVelocity = new Vector2(velocity.x, rb.linearVelocity.y);
        }
        else
        {
            // Decelerate player if there's no input (or input stops)
            velocity.x = Mathf.MoveTowards(velocity.x, 0f, deceleration * Time.deltaTime);
        }
    }

    private void CheckIfGrounded()
    {
        // Use a small raycast below the player to check for ground (or use collider if preferred)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask(groundCheckLayer));
        if (hit.collider != null)
        {
            isGrounded = true;
            isJumping = false;  // Player is grounded, not jumping anymore
        }
        else
        {
            isGrounded = false;
        }
    }
}

