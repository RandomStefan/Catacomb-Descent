using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text counterText; // The actual text
    private float counter=0; // The counter

    public void Update()
    {
        counter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().deathCounter; // We get the counter from the player movement script
        counterText.text = "Death counter: "+counter.ToString(); // We add it to the counter
    }
}
