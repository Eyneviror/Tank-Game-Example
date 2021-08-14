using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerAction 
{

    public int Progress { get; private set; }
    public bool Looping { get; private set; }


    private Action callBack;
    private float currentTime;
    private float trigerTime;
    private bool isRun = false;


    public TimerAction(float time, Action action,bool loop)
    {
        trigerTime = time;
        callBack = action;
        Looping = loop;
    }
    public TimerAction(float time, Action action)
    {
        trigerTime = time;
        callBack = action;
        Looping = false;
    }

    public void Tick()
    {
        if (isRun)
        {
            currentTime += Time.deltaTime;
            if (currentTime > trigerTime)
            {
                currentTime = 0;
                callBack.Invoke();
                if (!Looping)
                {
                    isRun = false;
                }

            }
            Progress = (int)Math.Round((currentTime / trigerTime) * 100);
        }

    }
    public void Start()
    {
        isRun = true;
        currentTime = 0;
    }

}
