using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFall : MonoBehaviour
{
    public GameObject player;
    public GameObject bridge;

    public GameObject enemy;

    void Start()
    {

    }


    void Update()
    {
        if (player.transform.position.x >= this.transform.position.x)
        {
            bridge.GetComponent<Rigidbody2D>().gravityScale = 1;

            enemy.GetComponent<EnemyFollow>().enabled = true;

            foreach (Transform child in enemy.transform)
            {
                child.GetComponent<Rigidbody2D>().gravityScale = 1;
                child.GetComponent<Animator>().enabled = true;
            }
        }
    }
}
