using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public bool countDown;

    public TextMeshProUGUI TimerText;

    public bool hasLimit;
    public float timerLimit;
    private string minutes;
    private string seconds;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        minutes = Mathf.Floor(currentTime / 60).ToString("00");
        seconds = (currentTime % 60).ToString("00");


        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            setTimerText();
            TimerText.color = Color.red;
            enabled = false;
        }



        setTimerText();

    }

    public void setTimerText()
    {
        TimerText.text = string.Format("{0}:{1}", minutes, seconds);
    }
}
