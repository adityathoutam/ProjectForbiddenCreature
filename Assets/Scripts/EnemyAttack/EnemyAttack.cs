using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    public GameObject enemyfightPos;

    public GameObject Bullet;

    private bool local = true;
    public bool attack;

    public int count = 3;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Bullet")
        {
            count--;

            this.GetComponent<Animator>().SetTrigger("EnemyHit");
            if (count==0)
            {
                this.GetComponent<Animator>().SetBool("EnemyDeath", true);
                Destroy(this.gameObject, 5f);
            }
        }
    }

    void Update()
    {
        
        if (player.transform.position.x >= enemyfightPos.transform.position.x && count==3)
        {
            //cam.GetComponent<CameraFollow>().enabled = false;

            this.GetComponent<Animator>().SetBool("EnemyAttack", true);


        }

        
    }

    void ThrowAcid()
    {
        GameObject go = Instantiate(Bullet, Bullet.transform.position, Bullet.transform.rotation);
    }

    

    

 
}
