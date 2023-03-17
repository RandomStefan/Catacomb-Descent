using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
 // Script quits to main menu

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            SceneManager.LoadScene("MainMenu"); // Loads the main menu scene after player collision
        }
    }
}
