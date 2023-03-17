using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Zotov, A., 2020. [online] Available at: https://www.youtube.com/watch?v=Mq2zYk5tW_E&t=437s 

    private Vector2 moveDirection;
    public float moveSpeed;
    public float damage;
    public string CollisionTag;

    // Destroy the bullet after 3 seconds as we dont need it for more at any time
    private void OnEnable()
    {
        Invoke("Destroy", 3.0f);
    }


    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = 5f;
    }

    // We update it's transform each frame
    void Update()
    {
        //Debug.Log("Bullet rotation: " + transform.rotation);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //transform.LookAt(moveDirection);
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
    // If it collides with a player or enemy it kills them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the incoming gameobject has a tag that matches "Enemy"
        if (collision.gameObject.CompareTag(CollisionTag))
        {
            if (CollisionTag == "Player")
            {
                collision.GetComponent<PlayerMovementScript>().resetToCheckpoint();
                gameObject.SetActive(false);
            }
            if (CollisionTag == "Enemy")
            {

                gameObject.SetActive(false);
            }
        }
    }
}
