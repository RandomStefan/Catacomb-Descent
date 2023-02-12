using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float dirX;
    public float moveSpeed = 1f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wall>())
        {
            dirX *= -1f;
            StartCoroutine(Dash());
        }
    }

 

        void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (isDashing)
        {
            return;
        }
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
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
    private IEnumerator Dash()
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
