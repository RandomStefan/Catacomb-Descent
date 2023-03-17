using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer sprite; // Sprite renderer of the object
    private PlayerMovementScript PlayerScript; // Movement script responsible for moving the player to the checkpoint when it needs
    public bool isActive = false; // Check for the status of the checkpoint 

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); // Initialize the sprite
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>(); // Initialize the Player movement script
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player") && (isActive  == false ))
        {
            isActive = true; // Activate the checkpoint
            sprite.color = new Color32(121, 255, 176, 255); // Change the color in order to be clear that the checkpoint has been activated
            PlayerScript.recieveCoords(transform.position); // Send the coordinates of the checkpoint to the movement script

        }
    }

    public void setCheckpoint(Vector3 coords) // Method to set the checkpoint coords to given coords
    {
        coords = transform.position;
    }
}
