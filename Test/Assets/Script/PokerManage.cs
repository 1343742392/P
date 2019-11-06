using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Threading;
using UnityEngine.EventSystems;
public class PokerManage : MonoBehaviour
{
    Action back1;

    [SerializeField]  float interval = 30;
    ArrayList pokers = new ArrayList();
    ArrayList bufferPokers = new ArrayList();
    Vector2 center;
    GameObject canvas;
    Animator animatior;
    int starPokerNum = 17;
    int addNum = 0;
    int index = 0;

    float pokerWidth = 0;
    void Start()
    {


        GameObject back = GameObject.Find("back");
        pokerWidth = back.GetComponent<RectTransform>().rect.width;
        canvas = GameObject.Find("Canvas");
        center = new Vector2(Screen.width / 2, Screen.height / 5);
        animatior = back.GetComponent<Animator>();
        
        //GameObject obj = Instantiate(GameObject.Find("bh3")) as GameObject;
        //obj.GetComponent<RectTransform>().position = new Vector2(1000, 1000);
        //obj.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>());
        //addPoker(obj, back, starPokerNum);
    }
    void back()
    {
        Debug.Log("添加一张牌完毕");

    }

    void Update ()
    {
        if(this.addNum > 0)
        {
            float nt = animatior.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (nt - index > 1 && animatior.GetCurrentAnimatorStateInfo(0).IsName("addPoker"))
            {
                //添加进pokers
                pokers.Add(bufferPokers[0]);
                bufferPokers.RemoveAt(0);
                pokers.Sort(new PokerSort());
                index++;

                float length = bufferPokers.Count;
                float first = center.x - ( Math.Max(0, pokers.Count - 1) * interval) / 2;
                Debug.Log(first);

               
             
                //定位手上的牌 
                for (int f = 0; f < pokers.Count; f++)
                {
                    RectTransform rt = (pokers[f] as GameObject).GetComponent<RectTransform>();
                    rt.position = new Vector2(first + f * interval, center.y);
                }

               
                if (addNum == index)
                {
                    animatior.Play("null");
                    if(back1!=null) back1();
                }
            }
        }

    }

   
 
    
    public void addPoker(GameObject p, Action callback = null)
    {
        back1 = callback;
        this.addNum = 1;
        animatior.Play("addPoker");
        Debug.Log("____"  + "    isAdd:" + animatior.GetCurrentAnimatorStateInfo(0).IsName("addPoker"));
        pokers.Add(p);
        
    }

    public void addPokers(GameObject []p, Action callback = null)
    {
        back1 = callback;
        this.addNum = p.Length;
        animatior.Play("addPoker");
        Debug.Log("____" + "    isAdd:" + animatior.GetCurrentAnimatorStateInfo(0).IsName("addPoker"));
        foreach(GameObject g in p)
            bufferPokers.Add(g);
    }

}
