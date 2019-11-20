using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour
{
    static int time = 0;
    static long startTime = 0;
    static Action back = null;
    static Text text = null;
    public static bool mShowText = true;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0 )
        {
            if(!mShowText)
            {
                text.text = "";
                return;
            }
            int loseTime = (int)(GetTimeStamp() - startTime);
            int reult = time - loseTime;
            text.text = reult + "";
            if (reult <= 0 )
            {
                time = -1;
                text.text = "";
                if(back != null)back();
            }
        }
        
    }
    public static long GetTimeStamp()
    {
        TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds);
    }
    public static void SetTimer(int time, Action timeoutBack = null)
    {
        mShowText = true;
        TimeManage.time = time;
        TimeManage.back = timeoutBack;
        TimeManage.startTime = GetTimeStamp();
        text.text = time + "";
    }
}
