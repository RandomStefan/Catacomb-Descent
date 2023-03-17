using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour
{
    public GameObject player; // Player game object
    public float offset; // Offset on the X axis
    public float offsetY; // Offset on the Y axis
    public float offsetSmoothing; // Offset smoothing
    private Vector3 playerPosition; // Player position
    private bool direction = true; // Direction

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Initialize the player
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.GetComponent<PlayerMovementScript>().PlayerDirection(); // Get the player direction
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y+offsetY, transform.position.z); // Set the position of the camera to according to the offset values and player transform

        if (direction == true)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);  // Offset the camera on the x axis
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z); // Offset the camera on the Y axis
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime); // Smoothing the movement of the camera

     }

}
