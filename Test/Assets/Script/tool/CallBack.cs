using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CallBack: MonoBehaviour
{
    static Action mBack;
    static int mTime;
    static long startTime;
    void Update()
    {
        if(mTime > 0)
        {
            if (TimeManage.GetTimeStamp() >= startTime + mTime)
            {
                mTime = 0;
                mBack();
            }
        }
    }

    public static void Set(int time, Action back)
    {
        mTime = time;
        mBack = back;
        startTime = TimeManage.GetTimeStamp();
    }

    
}
