using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool isOnMystery = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Player") && (isOnMystery == false))
        {
            collision.transform.position = new Vector3(6.0f, -3.04f, 0f);
        }
        else if ((collision.tag == "Player") && (isOnMystery == true))
        {
            collision.transform.position = new Vector3(24.91f, -65.39f, 0f);
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
