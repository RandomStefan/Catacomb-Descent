using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool isOnMystery = false; // Boolean that checks if the teleporter is on the mystery level or not
    private void OnTriggerEnter2D(Collider2D collision) // After collision with player 
    {
        if((collision.tag == "Player") && (isOnMystery == false)) // If not on mystery level we reset the player position to a location outside teh mystery level
        {
            collision.transform.position = new Vector3(6.0f, -3.04f, 0f);
        }
        else if ((collision.tag == "Player") && (isOnMystery == true)) // Otherwise we set it to a location inisde the mystery level
        {
            collision.transform.position = new Vector3(24.91f, -65.39f, 0f);
        }
    }

}
