using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public int seconds;
    public int min;
    public int hour;
    public int day;
    public int week;
    public int month;
    public float timeBtwIncrease;
    private float nextIncreaseTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBtwIncrease;
            Debug.Log(seconds + "seconds");
            // Debug.Log(seconds + " seconds");
            
            if (seconds <= 59)
            {
                seconds++;
            }
            
            else if (seconds >= 59)
            {
                seconds = 0;
                min = min+1;
                Debug.Log(min);
            }
        

    
  // if (min <= 60 && seconds >= 59)
  //   {
  //       min++;
  //   }

  //    if (min >= 60)
  //       {
  //         int min = 0;
  //         hour++;
  //         Debug.Log(hour);
  //       }

  //       }

  //         if (hour <= 24 && day <= 7)
  //   {
  //       day++;
  //   }

  //    if (day >= 7)
  //       {
  //         int day = 0;
  //         week++;
  //         Debug.Log(week);
  //       }

  //            if (week <= 4 && month >= 12)
  //   {
  //       week++;
        
  //   }

  //    if ( week>= 7)
  //       {
  //         int week = 0;
  //         month++;
  //         Debug.Log(month);
  //       }
    }
    }
}

