using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateTimer : MonoBehaviour
{
    private float timer = 300; //This is based on seconds so the initial time is about 5 minutes
    [SerializeField] private Text timerText;
    // Update is called once per frame
    void Update()
    {
        float minutes = timer / 60;
        float seconds = (minutes - Mathf.Floor(minutes)) * 60;
        minutes = Mathf.Floor(minutes);
        seconds = Mathf.Floor(seconds);
        timer -= 1 * Time.deltaTime;
        if (seconds < 10)
        {
            timerText.text = minutes + ":" + "0" + seconds;
        }
        else if(timer >= 0)
        {
            timerText.text = minutes + ":" + seconds;
        }
    }
}
