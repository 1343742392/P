using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManage : MonoBehaviour
{
    // Start is called before the first frame update
    ArrayList buttons = new ArrayList();
    Action<string> back = null;
    [SerializeField] float interval = 50;
    public class ButtonNames { 
        public const  string ShowPoker = "showPoker";
        public const string BeLandlord = "beLandlord";
        public const string DoNot = "doNot";
        public const string OutPoker = "outPoker";
        public const string Next = "next";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetButtons(string []names, Action<string> back = null)
    {
        int length = buttons.Count;
        for (int f = 0; f < length; f ++ )
        {
            (buttons[0] as GameObject).transform.position = new Vector2(800, 800);
            buttons.Remove(buttons[0]);
        }
        if (names.Length == 0) return;
        this.back = back;
        Vector2 center = gameObject.transform.position;
        
        for (int f = 0; f < names.Length; f ++)
        {
            GameObject obj = GameObject.Find(names[f]);
            buttons.Add(obj);

        }
        float buttonWidth = (buttons[0]as GameObject).GetComponent<RectTransform>().rect.width;
        float first = center.x - ((buttons.Count - 1) * buttonWidth + (buttons.Count - 1) * interval) / 2;
        for (int f2 = 0; f2 < buttons.Count; f2++)
        {
            (buttons[f2] as GameObject).GetComponent<RectTransform>().position = new Vector2(first + f2 * interval + buttonWidth * f2, center.y);
        }
        
        
    }

    public void SetResult(String result)
    {

        back(result);
    }


}
