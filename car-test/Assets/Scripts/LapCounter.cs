using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LapCounter : MonoBehaviour
{
    // Start is called before the first frame update
    int laps = -1;
    float startLapTime;
    [SerializeField] TextMeshProUGUI lapText;
    [SerializeField] TextMeshProUGUI lapTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (laps < 0)
        {
            lapText.text = "Laps: 0";
            lapTime.text = "Lamp time: 0";
        }
        else
        {
            lapText.text = "Laps: " + laps.ToString();
            lapTime.text = "Lap time: " + Math.Round(Time.time - startLapTime, 2).ToString();
        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        laps++;
        startLapTime = Time.time;
    }
}
