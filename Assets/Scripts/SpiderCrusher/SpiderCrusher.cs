using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }
        if (collision.gameObject.tag == "Fenemy")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
