using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public enum TimerType
    {
        TIMER_NULL = -1,
        TIMER_DECREASE,
        TIMER_INCREASE,
        TIMER_INCREASE_FOREVER
    }

    public float TimerTime
    {
        get;
        set;
    }

    public TimerType Type;


    //Could be efficient and use regex, but no, forget that
    public Text _text_min;
    public Text _text_sec;
    public float TimerDuration;

    private float updateTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Type = TimerType.TIMER_INCREASE;
        TimerDuration = 70;
        TimerTime = 0;
        TimerUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerTime > 0 && Type == TimerType.TIMER_DECREASE || Type == TimerType.TIMER_INCREASE && TimerTime < TimerDuration || Type == TimerType.TIMER_INCREASE_FOREVER)
        {
            updateTimer += Time.deltaTime;

            if (updateTimer > 1.0f)
            {
                TimerUpdate();
                updateTimer = updateTimer - 1.0f;
            }
        } else
        {
            Type = TimerType.TIMER_NULL;
        }
    }

    void TimerUpdate()
    {
        //Just to prove I'm not Yanderedev
        switch (Type)
        {
            case TimerType.TIMER_DECREASE:
                TimerTime--;
                break;
            case TimerType.TIMER_INCREASE_FOREVER:
                TimerTime++;
                break;
            case TimerType.TIMER_INCREASE:
                TimerTime++;
                break;
            default:
                break;
        }

        _text_min.text = Mathf.Floor(TimerTime / 60).ToString();
        _text_sec.text = (TimerTime % 60 < 10) ? "0" + (TimerTime % 60).ToString() : (TimerTime % 60).ToString();

    }

}
