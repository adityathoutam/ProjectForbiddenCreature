using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFall : MonoBehaviour
{
    public GameObject player;
    public GameObject bridge;

    public GameObject[] enemy;

    void Start()
    {

    }


    void Update()
    {
        if (player.transform.position.x >= this.transform.position.x)
        {
            bridge.GetComponent<Rigidbody2D>().gravityScale = 1;

            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].GetComponent<EnemyFollow>().enabled = true;


                    enemy[i].GetComponent<Rigidbody2D>().gravityScale = 1;
                    enemy[i].GetComponent<Animator>().enabled = true;
            }
        }
    }
}
