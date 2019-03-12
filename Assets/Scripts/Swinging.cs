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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                grab = true;
                anim.SetBool("Swing", true);
                collision.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
            if (grab)
            {
                collision.gameObject.GetComponent<Demo>().grounded = false;
                collision.transform.SetParent(this.transform);
            }
            else
            {
                collision.transform.SetParent(null);
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
            if(Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles += new Vector3(0, 0, 2f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles += new Vector3(0, 0, -2f);
            }
        }
    }
}
