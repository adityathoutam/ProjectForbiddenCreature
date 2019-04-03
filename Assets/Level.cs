using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    Animator anim;

    public Image blank;

    private void Start()
    {
        anim = blank.GetComponent<Animator>();
    }

    public void LoadLevel()
    {
        StartCoroutine(Fade());
        //SceneManager.LoadScene(1);
    }

    IEnumerator Fade()
    {
        anim.SetBool("FadeIn", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
