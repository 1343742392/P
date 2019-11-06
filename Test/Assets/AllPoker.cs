using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPoker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject []gameObject = GameObject.FindGameObjectsWithTag("poker");
        Debug.Log(" " + gameObject.Length);

        GameObject.Find("Player1").GetComponent<PokerManage>().addPokers(gameObject, null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
