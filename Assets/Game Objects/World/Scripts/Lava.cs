using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private PlayerMovementScript player; // We get the player's movement script

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>(); // Initialize the player movement script that moves the player to the checkpoint
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            player.resetToCheckpoint(); // We call the method that resets the player position to the last checkpoint activated after collision
        }
    }
}
