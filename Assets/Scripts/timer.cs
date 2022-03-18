using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    private int seconds;
    private int min;
    private int hour;
    private int day;
    private int week;
    private int month;
    public float timeBtwIncrease;
    private float nextIncreaseTime;

    public Text TimeDisplay;
    public Text SecDisplay;

    private void Update()
    {
        TimeDisplay.text = min.ToString() + " : " + hour.ToString() + " : " + day.ToString();
        SecDisplay.text = seconds.ToString();

        if (Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBtwIncrease;
            
            if (seconds <= 59)
            {
                seconds++;
            }
            
            else if (seconds >= 59)
            {
                seconds = 0;
                min += 1;
            }
        
            if (min <= 60 && seconds >= 59)
            {
                seconds = 0;
                min++;
            }
            
            if (min >= 60)
            {
                min = 0;
                hour++;
            }
        }
        
        if (hour >= 24)
        {
            hour = 0;
            day++;
        }

        /*
        if (day >= 7)
        {
          day = 0;
          week++;
        }
        
        if (week <= 4 && month >= 12)
        {
            week++;
        }
        
        if ( week>= 7)
        {
            week = 0;
            month++;
        }
        */
    }
}

