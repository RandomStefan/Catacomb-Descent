using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //private GameObject enemy;
    //private Rigidbody2D rb;
    //public float force;
    //private float timer;
    //// Start is called before the first frame update

    //private void Fire()
    //{
    //    float angleStep = (endAngle - startAngle) / bulletsAmount;
    //    float angle = startAngle;

    //    for (int i = 0; i < bulletsAmount; i++)
    //    {
    //        float bulDirX = Mathf.Sin((0 * Mathf.PI) / 180f);
    //        float bulDirY = Mathf.Cos((0 * Mathf.PI) / 180f);

    //        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
    //        Vector2 bulDir = bulMoveVector;

    //        GameObject bul = BulletPool.PlayerbulletPoolInstanse.GetBullet();
    //        bul.transform.position = FirePosition.position;
    //        bul.transform.rotation = FirePosition.rotation;
    //        bul.SetActive(true);
    //        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

    //        //Debug.Log("Bullet spawned at :" + bul.transform.position + " with rotation " + bul.transform.rotation + " .");

    //        angle += angleStep;
    //    }
    //}

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    enemy = GameObject.FindGameObjectWithTag("Enemy");

    //    Vector3 direction = enemy.transform.position - transform.position;
    //    rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    //    float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0, 0, rot + 90); //sterge 90 daca e vreo problema la sprite uri
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (timer > 10)
    //    {
    //        Destroy(gameObject);
    //    }
    //}


    //void OnTriggerEnter2D(Collider2D other)
    //{
    //}


    private Vector2 moveDirection;
    public float moveSpeed;
    public float damage;
    public string CollisionTag;

    public Transform partSpawnSpace;
    public GameObject bulletHitParticle;
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

        if(collision.tag == "Enemy")
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }


    }
}


