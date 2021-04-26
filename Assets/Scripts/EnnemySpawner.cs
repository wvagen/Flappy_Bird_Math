using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public TubeSpawner tubeSpawner;
    public Transform playerTransform;

    short enemyCounter = 0;
    void Start()
    {
        InvokeRepeating("Spawn_Eemey", 0, tubeSpawner.enemySpawnerTimeRate);
    }

    void Spawn_Eemey()
    {
        if (!Player.myRig.isKinematic)
        {
            if (enemyCounter < tubeSpawner.enemySpawnerAmounts)
            {
                GameObject tempEnemy = Instantiate(enemy, new Vector2(transform.position.x, playerTransform.position.y), Quaternion.identity);
                tempEnemy.GetComponent<Rigidbody2D>().velocity = Vector2.left * 6;
                Destroy(tempEnemy, 10);
                enemyCounter++;
            }
        }
    }
}
