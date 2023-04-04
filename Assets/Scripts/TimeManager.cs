using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // 5 seconds per 10 minutes
    [SerializeField] private float secondsPerHour = 30;
    private float secondsPer10Minutes;

    // Time is between 0000 and 2400
    private int currentHour;
    private int current10Minute;
    private int currentDay;

    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI dayText;

    public Action<int> onHourChange = (hour) => { };

    // Start is called before the first frame update
    void Start()
    {
        secondsPer10Minutes = secondsPerHour / 6f;
        currentHour = 1;
        onHourChange.Invoke(currentHour);
    }

    private float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= secondsPer10Minutes)
        {
            timer = 0;
            current10Minute++;
            SetTimeText();
        }

        if (current10Minute >= 6)
        {
            current10Minute = 0;
            currentHour++;
            onHourChange.Invoke(currentHour);
            SetTimeText();
        }

        if (currentHour >= 24)
        {
            currentHour = 0;
            currentDay++;
            SetTimeText();
        }
    }

    public int GetHour()
    {
        return currentHour;
    }

    public int GetMinute()
    {
        return current10Minute * 10;
    }

    private void SetTimeText()
    {
        var isPm = false;
        var displayHour = currentHour;
        if (displayHour >= 12)
            isPm = true;

        if (displayHour > 12)
            displayHour -= 12;
        
        timeText.text = displayHour.ToString("00") + ":" + (current10Minute * 10).ToString("00") + (isPm ? " pm" : " am");
        dayText.text = "Day " + currentDay.ToString();
    }
}
