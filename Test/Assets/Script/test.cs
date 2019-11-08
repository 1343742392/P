using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Threading;
using UnityEngine.EventSystems;
public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject b = GameObject.Find("Image");
        Sprite s = Resources.Load<Sprite>("bh05");
        b.GetComponent<Image>().sprite = s;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
