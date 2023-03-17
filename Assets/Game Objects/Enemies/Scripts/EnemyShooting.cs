using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet; // Bullet object 
    public Transform bulletPos; // Bullet spawn position
    public float delay=2; // Delay between attacks
    public float range = 7; // Range to start shooting at the player from


    private float timer; // Cooldown timer for shooting
    private GameObject player; // Player object

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Initialize the player
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position); // Find the distance to the player

        if(distance< range) // If in range
        {
            timer += Time.deltaTime; // Start cooldown count
            if (timer > delay) // If condition is met the enemy shoots and resets the counter
            {
                timer = 0;
                shoot();
            }
        }
  
    }



    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity); // Spawn a bullet at a given position
    }
}

