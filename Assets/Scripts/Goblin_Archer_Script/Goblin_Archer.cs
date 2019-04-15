using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin_Archer : MonoBehaviour
{
    public GameObject cam;
    public GameObject player;

    public GameObject enemyfightPos;

    public GameObject Arrow;

    private bool local = true;
    public bool attack;

    public int count = 3;

    public bool follow;
    public float speed;


    public GameObject bigbranch;
    public GameObject smallbranch1;
    public GameObject smallbranch2;

    public bool breakdown;    

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bigbranch")
        {
            StartCoroutine(Fall());
        }
    }

    void Update()
    {

        if (player.transform.position.x >= enemyfightPos.transform.position.x && count == 3)
        {
            this.GetComponent<Animator>().SetBool("Attack", true);
            StartCoroutine(FollowPlayer());
        }

        if(follow)
        {
            this.GetComponent<Animator>().SetBool("Attack", false);
            this.GetComponent<Animator>().SetBool("Walk", true);

            float step = speed * Time.deltaTime;

            if (player != null)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }

        if(breakdown)
        {
            bigbranch.SetActive(false);
            smallbranch1.SetActive(true);
            smallbranch2.SetActive(true);
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(1f);
        breakdown = true;
    }

    IEnumerator FollowPlayer()
    {
        yield return new WaitForSeconds(10f);
        follow = true;
    }

    void Shoot()
    {
        GameObject go = Instantiate(Arrow, Arrow.transform.position, Arrow.transform.rotation);
    }
}
