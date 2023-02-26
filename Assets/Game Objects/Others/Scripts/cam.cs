using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetY;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    private bool direction = true;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.GetComponent<test>().PlayerDirection();
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y+offsetY, transform.position.z);


        if (direction == true)
        {
            //Debug.Log("isYES");
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);  
        }
        else
        {
            //Debug.Log("isNOt");
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);

        //Debug.Log(direction);

     }

}
