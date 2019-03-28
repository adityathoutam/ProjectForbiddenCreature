using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScene : MonoBehaviour
{
    public GameObject go;
    //public GameObject Portal;
    public GameObject Target;
    public GameObject portalCollider;
    public Vector3[] trajectoryList;
    public Transform furmiddle;
    public Transform furend;
    public Transform bossmiddle;
    public Transform bossend;
    public float speed;


    Animator anim;

    void Start()
    {
        portalCollider.GetComponent<ParticleSystem>().Stop();

        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (Target != null)
            transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, step);

        if(go.transform.position==Vector3.zero)
        {
            StartCoroutine(DoSome());

        }

        
    }
    IEnumerator DoSome()
    {
       
        EnemyTrajectoryPath(this.transform.position, bossmiddle.transform.position, bossend.transform.position, this.gameObject);
        yield return new WaitForSecondsRealtime(2f);
        portalCollider.GetComponent<ParticleSystem>().Stop();
        Destroy(this.gameObject);
        Destroy(go);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Portal")
        {
            go.GetComponent<SpriteRenderer>().flipX=false;
            anim.SetBool("SPAttack", true);
           
        }
    }
    public void OpenPortal()
    {
        Debug.Log("aga");
        portalCollider.GetComponent<ParticleSystem>().Play();
        
        EnemyTrajectoryPath(go.transform.position, furmiddle.transform.position, furend.transform.position,go);
      

    }
    void EnemyTrajectoryPath(Vector2 p1, Vector2 p2, Vector2 p3,GameObject go)
    {

        for (int i = 0; i < 5; i++)
        {
            float t = i / (float)5;
            t = Mathf.Clamp01(t);
            Vector2 part1 = Mathf.Pow(1 - t, 2) * p1;
            Vector2 part2 = 2 * (1 - t) * t * p2;
            Vector2 part3 = Mathf.Pow(t, 2) * p3;



            Vector2 pos = part1 + part2 + part3;
            trajectoryList[i] = pos;

        }

        StartCoroutine(rand(go));
    }
    IEnumerator rand(GameObject go)
    {
        go.transform.parent = null;
        for (int i = 0; i < trajectoryList.Length - 1; i++)
        {

            yield return MoveObject(go, trajectoryList[i], trajectoryList[i + 1], 0.5f);
        }

    }
    private IEnumerator MoveObject(GameObject Local, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;

            Local.transform.position = Vector3.Lerp(startPos, endPos, i);

            yield return null;
        }
    }
}
