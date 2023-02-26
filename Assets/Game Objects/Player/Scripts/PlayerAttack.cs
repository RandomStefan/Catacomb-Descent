using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRangeX;
    public float attackRangeY;
    //public Animator camAnim;
    //public Animator playerAnim;
    public float damage;

    
    public float delay = 2;
    private float timer;
    private float explosionTimer;
    public float explosionTimerDelay=3;


   // [SerializeField]
   // private int bulletsAmount = 10;

   // [SerializeField]
   // private float startAngle = 90f, endAngle = 90f;

    //private Vector2 bulletMoveDirection;

    //public Transform FirePosition;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    private GameObject player;
    private test script;
    private bool dir;

    private GameObject ExplosionCircle;
    private float timeUntillast;
    public float explosionCircleLast = 2;
    //private void Fire()
    //{
    //    float angleStep = (endAngle - startAngle) / bulletsAmount;
    //    float angle = startAngle;

    //    for (int i = 0; i < bulletsAmount; i++)
    //    {
    //        float bulDirX = Mathf.Sin((angle * Mathf.PI) / 180f);
    //        float bulDirY = Mathf.Cos((angle * Mathf.PI) / 180f);

    //        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
    //        Vector2 bulDir = bulMoveVector;

    //        GameObject bul = PlayerBulletPool.PlayerbulletPoolInstanse.GetBullet();
    //        bul.transform.position = FirePosition.position;
    //        bul.transform.rotation = FirePosition.rotation;
    //        bul.SetActive(true);
    //        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

    //        //Debug.Log("Bullet spawned at :" + bul.transform.position + " with rotation " + bul.transform.rotation + " .");

    //        angle += angleStep;
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        ExplosionCircle = GameObject.FindGameObjectWithTag("ExplosionCircle");
        ExplosionCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.GetComponent<test>().PlayerDirection();
        //Debug.Log(dir);
        timeUntillast += Time.deltaTime;
        timer += Time.deltaTime;
        explosionTimer += Time.deltaTime;




        if (Input.GetKey(KeyCode.Q))
        {
            if (timer > delay)
            {
                Debug.Log("SHOOT");
                timer = 0;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                
                if (dir == true)
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
                else
                    bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint.right * bulletSpeed;

            }
        }
        
        if(Input.GetKey(KeyCode.F))
            if(explosionTimer > explosionTimerDelay)
        {
                timeUntillast = 0;
                explosionTimer = 0;
                ExplosionCircle.SetActive(true);
                

        }
       

        if (Input.GetKey(KeyCode.R))
            player.GetComponent<test>().resetToCheckpoint();

        if (timeUntillast>= explosionCircleLast)
        {
            ExplosionCircle.SetActive(false);
        }

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("ATTACK");
                //camAnim.SetTrigger("shake");
                //playerAnim.SetTrigger("attack");

               
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY),0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                    //Debug.Log("HIT");
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }


}