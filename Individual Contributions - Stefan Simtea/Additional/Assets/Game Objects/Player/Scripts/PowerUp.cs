using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // When the player collides with the Power Up
    {
        if(collision.tag == "Player") // We check if the collision was with the player
        {
            collision.GetComponent<PlayerAttack>().PowerUp(); // If yes we call the method for applying the power up to the player
            gameObject.SetActive(false); // We deactivate the power up item
        }
    }

}
