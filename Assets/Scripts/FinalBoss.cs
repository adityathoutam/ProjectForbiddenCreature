using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject L2enemy;

    public GameObject player;
    public GameObject LvlPos;
    public GameObject Bullet;
    public GameObject BulletPos;

    public int count;

    void Start()
    {
        
    }


    void Update()
    {

        if (player.transform.position.x >= LvlPos.transform.position.x)
        {
            //cam.GetComponent<CameraFollow>().enabled = false;

            this.GetComponent<Animator>().SetBool("BossAttack", true);


        }


    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Bullet")
        //{
        //   // this.GetComponent<Animator>().SetBool("BossIdle", true);
        //    count--;
        //}
        if(count==0)
        {
            this.GetComponent<Animator>().SetBool("BossAttack", false);

            Destroy(this.gameObject, 3f);
        }
    }

    public void ThrowAcid()
    {
        Debug.Log("AAACCCIIIDDD");
        GameObject go = Instantiate(Bullet, BulletPos.transform.position, Bullet.transform.rotation);
    }

    //void L2Go()
    //{
    //    Debug.Log("BWAAAAHAHAHA");
    //    GameObject go2 = Instantiate(L2enemy, L2enemy.transform.position, L2enemy.transform.rotation);
    //}
}
