using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{

    public GameObject tube;
    void Start()
    {
        InvokeRepeating("GenerateTube", 0, 3);
    }


    void GenerateTube()
    {
        if (Player.myRig.isKinematic) return;

        GameObject tempTube = Instantiate(tube, this.transform.position,Quaternion.identity) as GameObject;
        Destroy(tempTube, 8);
    }

}
