using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1, // The first enemy that has to be defeated for the key to spawn
                       enemy2, // The second enemy that has to be defeated for the key to spawn
                       wall, // The wall that deactivates when the key is picked up
                       keyObject; // The key that spawns after the enemies are defeated

    // Start is called before the first frame update
    void Start()
    {
        keyObject.SetActive(false); // Hide the key at start
    }

    // Update is called once per frame
    void Update()
    {
        if((enemy1.active==false)&&(enemy2.active==false)) // If the enemies are no longer active
        {
            keyObject.SetActive(true); // We spawn the key
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // On collision with player and key
    {
        if((collision.tag == "Player") && ((enemy1.active == false) && (enemy2.active == false))) // We double check to see if the enemies are still inactive
        {
            wall.SetActive(false); // We "open the door"
            keyObject.SetActive(false); // We deactivate the key object
            gameObject.SetActive(false); // We deactivate the wrapper for the key
        }
    }
}
