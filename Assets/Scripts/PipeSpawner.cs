using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour {

	public GameObject pipe;


	void Start () {
		InvokeRepeating( "GeneratePipes", 1,2);

		
	}
	
	void GeneratePipes () {
        if (Player.myRig.isKinematic) return;
        float randy = Random.Range(-1.8f, 1.8f);
        Instantiate(pipe, new Vector2(16.02f, randy), Quaternion.identity);
		
	}
}
