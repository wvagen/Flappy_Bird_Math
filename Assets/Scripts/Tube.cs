using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tube : MonoBehaviour
{
    Rigidbody2D myRig;

    public Text equationTxt;
    public Text sugg1, sugg2;

    public Collider2D upperCollider,downCollider;

    public int minRange, maxRange;


    // Use this for initialization
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        GenerateEquation();
    }

    void GenerateEquation()
    {
        int x = Random.Range(TubeSpawner.isLevel ? minRange : 0, TubeSpawner.isLevel ? maxRange : 10);
        int y = Random.Range(TubeSpawner.isLevel ? minRange : 0, TubeSpawner.isLevel ? maxRange : 10);

        int result = 0;

        if (Random.Range(0, 2) % 2 == 0)
        {
            result = x + y;
            equationTxt.text = x.ToString() + " + " + y.ToString();
        }
        else
        {
            result = x - y;
            equationTxt.text = x.ToString() + " - " + y.ToString();
        }

        
        int wrongRes = result;
        int wrongRate = Random.Range(-3, 3);


        while (((wrongRate + result) == result))
        {
            wrongRate = Random.Range(-3, 3);
        }


        if (Random.Range(0, 2) % 2 == 0)
        {
            sugg1.text = result.ToString();
            sugg2.text = (wrongRate+result).ToString();

            upperCollider.isTrigger = true;
            downCollider.isTrigger = false;
        }
        else
        {
            sugg2.text = result.ToString();
            sugg1.text = (wrongRate + result).ToString();

            upperCollider.isTrigger = false;
            downCollider.isTrigger = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        myRig.velocity = Vector2.left * 3;
    }
}
