using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordManage : MonoBehaviour
{
    public Vector3 ShowPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SayNext(Action sayBack = null)
    {
        GameObject next = GameObject.Find("nextText");
        next.GetComponent<AnimaEvent>().mEndBack = sayBack;
        next.transform.parent.parent = GameObject.FindWithTag("canvas").transform;
        next.transform.parent.position = GameObject.FindWithTag("canvas").transform.position + ShowPos;
        next.GetComponent<Animator>().Play("WordShow");

    }
}
