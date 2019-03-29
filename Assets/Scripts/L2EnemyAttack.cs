using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2EnemyAttack : MonoBehaviour
{
    public bool reverse;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            if (collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack - Basic"))
            {

                reverse = true;
            }
            else
            {
                collision.GetComponent<Animator>().SetBool("Dead", true);
            }
        }
    }

    private void Update()
    {
        if (!reverse)
        {
            this.GetComponent<Animator>().SetBool("L2Walk", true);
            this.transform.Translate(-Vector2.right * 5 * Time.deltaTime);
        }
        if (reverse)
        {
            this.GetComponent<Animator>().SetBool("L2Walk", false);
            this.GetComponent<Animator>().SetBool("L2Death", true);

        }
        Destroy(this.gameObject, 5f);

    }
}
