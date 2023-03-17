using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed = 5.0f;

    [SerializeField]
    private Rigidbody2D rb;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool IsMoving()
    {
        bool notMovingHorizontal = Input.GetAxis("Horizontal") == 0.0f;
        bool notMovingVertical = Input.GetAxis("Vertical") == 0.0f;
        return notMovingHorizontal == false || notMovingVertical == false; //returns a true or false if player is moving or not
    }


    // Update is called once per frame

    private void FixedUpdate()
    {

        float xAxis = Input.GetAxisRaw("Horizontal");
        //rb.AddForce(new Vector2(xAxis, yAxis));
        Vector2 newVelocity = new Vector2(xAxis, 0);
        newVelocity.Normalize();
        rb.velocity = newVelocity * MovementSpeed;
        //rb.velocity = new Vector2(xAxis, yAxis);

    }


    private void HandleTransformMovement()
    {

        float currentX = transform.position.x;
        float newX = currentX + (Input.GetAxis("Horizontal") * Time.deltaTime) * MovementSpeed;
        Vector3 newPosition = new Vector3(newX, 0, -2.0f);
        // replacing the existing position vector with a whole new one
        transform.position = newPosition;
    }

    private void Update()
    {


        float horizontal = Input.GetAxisRaw("Horizontal") * MovementSpeed * Time.deltaTime;
        rb.AddForce(horizontal * Vector2.right);


    }


}



