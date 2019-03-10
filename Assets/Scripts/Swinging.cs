using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    Animator anim;

    void Start()
    {
        anim = player.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("Swing", true);
                player.GetComponent<Rigidbody2D>().simulated = false;
            }
            else
            {
                anim.SetBool("Swing", false);
                player.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }

    void Update()
    {
        
    }
}
