using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float force; // Force of the bullet

    private GameObject player; // Player object
    private Rigidbody2D rb; // Self rigibody
   
    private float timer; // Timer betwen attacks

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigibody initialize
        player = GameObject.FindGameObjectWithTag("Player");// Player initialize

        Vector3 direction = player.transform.position - transform.position; // Direction the bullet will take according to player position
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; // Set velocity with variables

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg; // Rotate the bullet according to direction
        transform.rotation = Quaternion.Euler(0, 0, rot+90); // Sprite rotation
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Start counting
        if (timer > 10)
        {
            Destroy(gameObject); // Despawn the bullet after 10 sec
        }
    }

    // Collision check
    // If with player or enemy -> enemy or player dies (player goes to checkpoint)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovementScript>().resetToCheckpoint();
            Destroy(gameObject);
        }
        else if (!other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
