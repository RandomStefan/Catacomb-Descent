using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class test : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 4f;
    private float direction = 0f;
    private Rigidbody2D player;

    [SerializeField] private TrailRenderer tr;
    public Transform groundCheck;
    public float groundCheckRadius=0.2f;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 2f;
    public float dashingTime = 0.2f;
    public float dashingCooldown = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
    }
        // Update is called once per frame
        void Update()
    {
        if (isDashing)
        {
            return;
        }

 
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        Debug.Log(isTouchingGround);

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction*speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);

        }

        if(Input.GetButtonDown("Jump")&&isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && direction != 0f)
        {
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = player.gravityScale;
        player.gravityScale = 0f;
        player.velocity = player.velocity* new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        player.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}