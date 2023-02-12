using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting1 : MonoBehaviour
{
    float timer;

    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 90f;

    private Vector2 bulletMoveDirection;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Fire", 0f, 2f);
        timer = 1.0f;
    }


    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount; i++)
        {

            Vector3 bulMoveVector = new Vector3(0f, -1f, 0f);
            Vector2 bulDir = bulMoveVector;

            GameObject bul = EnemyBulletPool.bulletPoolInstanse.GetEnemyBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }

    private void Update()
    {
        if (timer <= 0)
        {
            Fire();
            timer = 1.0f;
        }
        timer -= Time.deltaTime;
    }
}
