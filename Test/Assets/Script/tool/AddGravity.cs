﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, -35, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
