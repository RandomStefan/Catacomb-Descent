using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{ 
    public float moveSpeed = 1f; // Move Speed of enemy

    private Rigidbody2D rb; // Rigibody

    private float dirX; // Direction on x axis
    private bool facingRight = false; // Direction check

    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale; // sprite direction
        rb = GetComponent<Rigidbody2D>(); // Initialize rigibody
        dirX = -1f; // Set default direction
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wall>()) // If the collision has a Wall script
        {
            dirX *= -1f; // Change the direction
        }

        if(collision.tag == "Player") // If collided with a player reset them to the last checkpoint
        {
            collision.GetComponent<PlayerMovementScript>().resetToCheckpoint();
        }
    }

 

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); // Set the velocity
    }

    void LateUpdate()
    {
        CheckWhereToFace(); // Set the facing direction with following method
    }

    void CheckWhereToFace() // Set the facing direciton
    {
        if (dirX > 0) // check where the enemy is heading
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1; // change the sprite direction

        transform.localScale = localScale; // reset
    }
}
