using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpScript : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 0.7f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    [Range(1, 10)]
    public float jumpVelocity;
    public bool isGrounded;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        float xAxis = Input.GetAxisRaw("Horizontal");
        Vector2 newVelocity = new Vector2(xAxis, 0);
        newVelocity.Normalize();
        rb.velocity += newVelocity * MovementSpeed;

    }

    private void HandleTransformMovement()
    {

        float currentX = transform.position.x;
        float newX = currentX + (Input.GetAxis("Horizontal") * Time.deltaTime) * MovementSpeed;
        Vector3 newPosition = new Vector3(newX, 0, -2.0f);
        // replacing the existing position vector with a whole new one
        transform.position = newPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == 8 //check the int value in layer manager(User Defined starts at 8) 
            && !isGrounded)
        {

            isGrounded = true;
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && isGrounded)

        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }
    
        if (rb.velocity.y<0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                 rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        Debug.Log(isGrounded);
        

    }
}
