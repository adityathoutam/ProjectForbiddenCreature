using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    public GameObject enemyfightPos;

    private bool local = true;
    public bool attack;

    public int count = 3;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        { 

            if(player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack - Basic"))
            {
                Debug.Log(count);
                this.GetComponent<Animator>().SetTrigger("EnemyHit");
                count--;
                
            }
            if(count==-1)
            {
                
                this.GetComponent<Animator>().SetBool("EnemyDeath", true);
                cam.GetComponent<CameraFollow>().enabled = true;
            }
        }
    }

    void Update()
    {
        
        if (player.transform.position.x >= enemyfightPos.transform.position.x && count==3)
        {
            cam.GetComponent<CameraFollow>().enabled = false;

            this.GetComponent<Animator>().SetBool("EnemyAttack", true);


        }
    }

    

    

 
}
