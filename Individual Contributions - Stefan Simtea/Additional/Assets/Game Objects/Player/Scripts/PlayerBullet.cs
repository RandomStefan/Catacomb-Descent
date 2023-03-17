using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Zotov, A., 2020. [online] Available at: https://www.youtube.com/watch?v=Mq2zYk5tW_E&t=437s 

    private Vector2 moveDirection;
    public float moveSpeed;
    public float damage;
    public string CollisionTag;

    public Transform partSpawnSpace;
    // Destroy the bullet after 3 seconds as we dont need it for more at any time
    private void OnEnable()
    {
        Invoke("Destroy", 3.0f);
    }


    // We update it's transform each frame
    void Update()
    {

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

    }

    // We set the bullet's direction
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    // Function checks for collision with various objects 
    // If it collides with an enemy it kills the enemy
    // If it collides with a game object with these tags: Destructible, WallCollider it just despawns

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Enemy")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Destructible")
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            
        }

        if (collision.tag == "WallCollider")
        {
            gameObject.SetActive(false);
        }


    }
}


