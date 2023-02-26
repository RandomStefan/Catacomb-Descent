using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector2 moveDirection;
    public float moveSpeed;
    public float damage;
    public string CollisionTag;

    private void OnEnable()
    {
        Invoke("Destroy", 3.0f);
    }


    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Bullet rotation: " + transform.rotation);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //transform.LookAt(moveDirection);
    }

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if the incoming gameobject has a tag that matches "Enemy"
        if (collision.gameObject.CompareTag(CollisionTag))
        {
            if (CollisionTag == "Player")
            {
                collision.GetComponent<test>().resetToCheckpoint();
                gameObject.SetActive(false);
            }
            if (CollisionTag == "Enemy")
            {

                gameObject.SetActive(false);
            }
        }
    }
}
