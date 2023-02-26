using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    SpriteRenderer sprite;
    test PlayerScript;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<test>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Player") && (isActive  == false ))
        {
            isActive = true;
           sprite.color = Color.yellow;
            PlayerScript.recieveCoords(transform.position);

        }
    }


    public void setCheckpoint(Vector3 coords)
    {
        coords = transform.position;
    }
}
