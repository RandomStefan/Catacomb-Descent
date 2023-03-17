using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    // Script that spawns 2 enemies on player collision

    [SerializeField]
    private GameObject EnemyToSpawn1;
    [SerializeField]
    private GameObject EnemyToSpawn2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            EnemyToSpawn1.SetActive(true);
            EnemyToSpawn2.SetActive(true);

        }
    }

}
