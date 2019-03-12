using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    public bool grab;

    Animator anim;

    void Start()
    {
        anim = player.GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                grab = true;
                anim.SetBool("Swing", true);
                player.GetComponent<Rigidbody2D>().simulated = false;
            }
           
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            grab = false;
            anim.SetBool("Swing", false);
            player.GetComponent<Rigidbody2D>().simulated = true;
        }

        if(grab)
        {
            player.GetComponent<Demo>().grounded = false;
            player.transform.parent = transform;
        }
        else
        {
            player.transform.parent = null;
        }
    }
}
