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

    public float TimerDuration
    {
        get;
        set;
    }

    public TimerType Type
    {
        get;
        set;
    }

    public Text _text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
