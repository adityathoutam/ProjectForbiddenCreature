using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollider : MonoBehaviour
{
    public GameObject branch;
    public int count = 3;

    void Start()
    {
        
    }

   
    void Update()
    {
        if(count<=0)
        {
            branch.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack - Basic"))
            {
                Debug.Log("dsada");
                count--;
            }
        }
    }
}
