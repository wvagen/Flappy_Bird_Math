using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    public GameObject tube;
    public float tubeMarginHeight;

    public int Level_Generate_Amount = 0;

    public int minRange, maxRange;

    public static bool isLevel = true;
    public static int tubeGenerateAmount;
    public static int levelIndex = 0;
    public static int levelsAmount = 9;

    bool isGenerated = false;

    int generatedTubesCounter = 0;

    void Start()
    {
        tubeGenerateAmount = Level_Generate_Amount;
    }

    void Update()
    {
        if (!isGenerated)
        {
            StartCoroutine(Generate_Tube());
        }
    }

    IEnumerator Generate_Tube()
    {
        isGenerated = true;
        if (!isLevel || generatedTubesCounter < Level_Generate_Amount)
        {
            yield return new WaitForSeconds(4);
            GenerateTube();
            generatedTubesCounter++;
        }
        isGenerated = false;
    }

    void GenerateTube()
    {
        if (Player.myRig.isKinematic) return;

        GameObject tempTube = Instantiate(tube, new Vector2(transform.position.x,transform.position.y + Random.Range(-tubeMarginHeight,tubeMarginHeight)),Quaternion.identity) as GameObject;
        tempTube.GetComponent<Tube>().minRange = minRange;
        tempTube.GetComponent<Tube>().maxRange = maxRange;
        Destroy(tempTube, 8);
    }

}
