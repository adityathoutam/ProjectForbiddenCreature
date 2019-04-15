using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowScript : MonoBehaviour
{
    

    void Start()
    {
        
    }

    
    void Update()
    {
        this.transform.Translate(Vector2.up * 5 * Time.deltaTime);

        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            if (collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack - Basic"))
            {
                Destroy(this.gameObject);
            }
            else
            {
                collision.GetComponent<Animator>().SetBool("Dead", true);
                collision.GetComponent<Demo>().blank.SetActive(true);
                collision.GetComponent<Demo>().blank.GetComponent<Animator>().SetBool("FadeIn", true);
                StartCoroutine(Fade());
                // SceneManager.LoadScene(0);
            }
        }
    }

    IEnumerator Fade()
    {
        // imganim.SetBool("FadeIn", true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }

}
