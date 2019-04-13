using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpiderCrusher : MonoBehaviour
{

    public GameObject blank;

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
            blank.SetActive(true);
            Scene scene = SceneManager.GetActiveScene();
            StartCoroutine(Fade());
        }
        if (collision.gameObject.tag == "Fenemy")
        {
            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator Fade()
    {
        blank.GetComponent<Animator>().SetBool("FadeIn", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
