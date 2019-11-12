using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour
{
    int time = 0;
    long startTime = 0;
    Action back = null;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
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
    public long GetTimeStamp()
    {
        TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds);
    }
    public void SetTimer(int time, Action timeoutBack = null)
    {
        this.time = time;
        this.back = timeoutBack;
        this.startTime = GetTimeStamp();
        text.text = time + "";
    }
}
