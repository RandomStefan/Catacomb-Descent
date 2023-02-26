using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public float delay=2;
    private float timer;
    public float range = 7;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
       // Debug.Log(distance);

        if(distance< range)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                timer = 0;
                shoot();
            }
        }
  
    }



    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}

