using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWord
{
    static Action sayBack;
    static GameObject word = null;
    public static  void Say(Vector3 pos, Sprite s ,Action sayBack = null)
    {
        if(word == null) word = GameObject.Find("word");
        word.AddComponent<Image>();
        word.GetComponent<Image>().preserveAspect = true;
        word.GetComponent<Image>().sprite = s;
        ShowWord.sayBack = sayBack;
        word.GetComponent<AnimaEvent>().mEndBack = AnimaBack;
        word.transform.parent.parent = GameObject.FindWithTag("canvas").transform;
        word.transform.parent.GetComponent<RectTransform>().localPosition =  new Vector2(pos.x, pos.y);
        word.GetComponent<Animator>().Play("WordShow");

    }

    static void  AnimaBack()
    {
        word.transform.parent.position = new Vector3(1000, 1000);
        sayBack();
    }
}
