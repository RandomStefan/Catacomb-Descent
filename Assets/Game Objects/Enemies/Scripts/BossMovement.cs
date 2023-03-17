using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Script is a combination of enemy movement script and player movement script (just the dashing method)
    // Check those for a more detailed breakdown

    public float moveSpeed = 1f;

    private float dirX;
   
    private Rigidbody2D rb;
    private bool facingRight = false;

    private Vector3 localScale;


    [SerializeField] private TrailRenderer tr;
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 2f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 2f;



    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    private void OnTriggerEnter2D(Collider2D collision) // If hit a wall, start dashing in the opposite direction
    {
        if (collision.GetComponent<Wall>())
        {
            dirX *= -1f;
            StartCoroutine(Dash());
        }
    }

 

        void FixedUpdate() // Check if is dashing and set the velocity
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (isDashing)
        {
            return;
        }
    }

    void LateUpdate() // Check where to face
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace() // Check and set the player facing direction sprite included
    {
        if (dirX > 0)
        { facingRight = true; 
            
        }
        else if (dirX < 0)
        { facingRight = false; 
            
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
    private IEnumerator Dash() // Dashing coroutine
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = 100 * new Vector2(transform.localScale.x * dashingPower, 0f);
        float prevMoveSpeed = moveSpeed;
        moveSpeed *= dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        moveSpeed = prevMoveSpeed;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
