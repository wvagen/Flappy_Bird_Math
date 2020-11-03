using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour {
Rigidbody2D myRig;

	// Use this for initialization
	void Start () {
		myRig = GetComponent<Rigidbody2D >();
	}
	
	// Update is called once per frame
	void Update () {
	myRig.velocity = Vector2.left * 3;	
	}
}
