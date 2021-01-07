using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    public GameObject tube;
    public float tubeMarginHeight;

    void Start()
    {
        InvokeRepeating("GenerateTube", 0, 4);
    }


    void GenerateTube()
    {
        if (Player.myRig.isKinematic) return;

        GameObject tempTube = Instantiate(tube, new Vector2(transform.position.x,transform.position.y + Random.Range(-tubeMarginHeight,tubeMarginHeight)),Quaternion.identity) as GameObject;
        Destroy(tempTube, 8);
    }

}
