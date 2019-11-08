﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Poker : MonoBehaviour
{
    [SerializeField] GameObject imgObj;
    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Animator imgAnim = imgObj.GetComponent<Animator>();
        if (imgAnim.GetCurrentAnimatorStateInfo(0).IsName("pokerUp") && imgAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >=0.99f)
        {
            imgAnim.Play("pokerInter");
        }
        else
        {
            imgAnim.Play("pokerUp");
        }
        
    }

    public void SetImage(Sprite img)
    {
        if (imgObj != null)
        {
            imgObj.GetComponent<Image>().sprite = img;
        }
        else
        {
            Debug.Log("unset imgObj");
        }

    }

    public void DisabledBtn()
    {
        Object.Destroy(imgObj.GetComponent<Button>());
    }
}