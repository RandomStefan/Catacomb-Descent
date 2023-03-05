using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{

    [SerializeField]
    GameObject EnemyToSpawn1;
    [SerializeField]
    GameObject EnemyToSpawn2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            EnemyToSpawn1.SetActive(true);
            EnemyToSpawn2.SetActive(true);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
