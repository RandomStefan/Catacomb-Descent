using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject wall;
    public GameObject keyObject;
    // Start is called before the first frame update
    void Start()
    {
        keyObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if((enemy1.active==false)&&(enemy2.active==false))
        {
            keyObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Player") && ((enemy1.active == false) && (enemy2.active == false)))
        {
            wall.SetActive(false);
            keyObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
