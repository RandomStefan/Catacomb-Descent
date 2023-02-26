using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDscript : MonoBehaviour
{
    [SerializeField]
    public TMP_Text counterText;
    private float counter=0;

    public void Update()
    {
        counter = GameObject.FindGameObjectWithTag("Player").GetComponent<test>().deathCounter;
        counterText.text = "Death counter: "+counter.ToString();
    }
}
