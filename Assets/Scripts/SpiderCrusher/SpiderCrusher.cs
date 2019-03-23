using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCrusher : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Dead", true);
        }
        if (collision.gameObject.tag == "Fenemy")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
