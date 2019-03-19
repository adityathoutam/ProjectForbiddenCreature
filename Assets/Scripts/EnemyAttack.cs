using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    public GameObject enemy;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Vector2.Distance(enemy.transform.position,player.transform.position)<=2)
        {
            cam.GetComponent<CameraFollow>().enabled = false;
        }
    }
}
