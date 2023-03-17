using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision) // Check collision with surrounding entitites 
    {
        if(collision.tag=="Enemy") // If collision happened with enemy
        {
            collision.gameObject.SetActive(false); // We deactivate them
        }

        if(collision.tag=="Destructible") // If collision happened with a destructible object
        {
            collision.gameObject.SetActive(false); // We deactivate them
        }
    }

}
