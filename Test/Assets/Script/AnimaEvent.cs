using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaEvent : MonoBehaviour
{
    public Action mEndBack = null;

    void End()
    {
        if(mEndBack != null)
        {
            mEndBack();
        }
    }


}
