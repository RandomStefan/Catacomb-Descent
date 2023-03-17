using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public float speed = 5f; // Player movement speed
    public float jumpSpeed = 4f; // Player jump speed
    public float dashingPower = 2f; // With how much power will the dash propulsate the player
    public float dashingTime = 0.2f; // How much the dash will last
    public float dashingCooldown = 2f; // Dashing cooldown
    public int deathCounter = 0; // Death counter to show in the HUD


    [SerializeField] // Player sprites
    private Sprite playerFront, 
                   playerRight, 
                   playerLeft;

    [SerializeField] // Trail renderer
    private TrailRenderer tr;

    [SerializeField] //Ground check logic
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;


    [SerializeField] // Checkpoint logic
    private Vector3 checkpointPos; // Position of checkpoint
    [SerializeField]
    private Vector3 startPos; // Starting position of the player


    private float direction = 0f; // Direction the player is moving twoards; (>0 is facing right; <0 is facing left)
    private bool isFacingRight = true; // Simpler check of the direction to be exported

    private Rigidbody2D player; // Get the rigibody of the player
    private SpriteRenderer SpriteRenderer; // Get the sprite renderer of the player

    private bool isTouchingGround; // Check if the player is touching the ground (for jump to reset)
    private bool canDash = true; // Check if the player can dash
    private bool isDashing; // Check if the player is currently dashing


    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>(); // Initialization of the component
        SpriteRenderer.sprite = playerFront; // Set the default sprite to the front sprite
        checkpointPos = startPos; // Sets the default checkpoint to the starting position
        player = GetComponent<Rigidbody2D>(); // Initialize the rigibody
        startPos =  new Vector3(-42f, -59.24f, 0.0f); 
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }
        // Update is called once per frame
        void Update()
    {
        
        if (isDashing)
        {
            return;
        }

 
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Calculate if the player is touching ground
        direction = Input.GetAxis("Horizontal"); // Get the direction value from the keyboard. Basically moving the player


        if (direction > 0f) // Set the direciton value accordingly
        {
            player.velocity = new Vector2(direction*speed, player.velocity.y); // Move the player twoards the specified direction
            isFacingRight = true; // Set the player direction
            SpriteRenderer.sprite = playerRight; // Set the sprite to the according direction
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y); // Move the player twoards the specified direction
            isFacingRight =false; // Set the player direction
            SpriteRenderer.sprite = playerLeft; // Set the sprite to the according direction
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y); // Dont move the player
            SpriteRenderer.sprite = playerFront; // // Set the sprite to the default front sprite when not moving
        }

        if(Input.GetButtonDown("Jump")&&isTouchingGround) // If the player is on the ground and the jumping button is pressed
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed); // We make the player jump
            AudioManager.playJump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && direction != 0f) // If the dash button is pressed 
        {
            StartCoroutine(Dash()); // We start dashing
        }
 
    }
    private IEnumerator Dash() // Dashing coroutine
    {
        canDash = false;  // Player can not dash anymore as dashing just started
        isDashing = true; // Player is currently dashing
        AudioManager.playDash();
        float originalGravity = player.gravityScale; // Store the original gravity scale
        player.gravityScale = 0f; // Sets the gravity scale to 0 while dashing for player to not fall and keep floating
        player.velocity = player.velocity* new Vector2(transform.localScale.x * dashingPower, 0f); // We push the player accordingly
        tr.emitting = true; // We tell the trail to start emitting
        yield return new WaitForSeconds(dashingTime); // We dash for the specified time
        tr.emitting = false; // Trail stops emitting as the player begins to stop dashing
        player.gravityScale = originalGravity; // We reset the gravity scale
        isDashing = false; // Player is not dashing anymore 
        yield return new WaitForSeconds(dashingCooldown); // We start the dashing cooldown
        canDash = true; // Player is not able to dash again
    }

    public bool PlayerDirection() // Export the player direction
    {
        return isFacingRight;
    }

    public void recieveCoords(Vector3 coords) // Recieve the checkpoint coords
    {
        checkpointPos = coords;
    }

    public void resetToCheckpoint() // Resets the player to the checkpoint after being hit or falling into lava
    {
        deathCounter++;
        transform.position = checkpointPos;
    }

    public void resetToCheckpointNoCount() // Resets the player to the checkpoint after pressing "R"
    {
        transform.position = checkpointPos;
    }
}
