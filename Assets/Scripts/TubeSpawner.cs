using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour {

    public GameObject tube;
	void Start () {
        InvokeRepeating("GenerateTube", 0, 2);
	}


    void GenerateTube()
    {
        if (player.myRig.isKinematic) return;
        Vector2 myPos = this.transform.position;
        myPos.y = Random.Range(-1.5f, 1.5f);
        GameObject tempTube = Instantiate(tube, myPos,
            Quaternion.identity) as GameObject;
        Destroy(tempTube,8);
    }

}
