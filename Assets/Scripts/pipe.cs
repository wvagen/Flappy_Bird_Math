﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour {

	// Use this for initialization
	Rigidbody2D pipeRig ;	

	void Start () {
		pipeRig = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
			if (!Player.myRig.isKinematic) pipeRig.velocity = Vector2.left * 4;

		
	}
}
