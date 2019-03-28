using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCollision : MonoBehaviour
{
   
   public GameObject branch;

    
    void Start()
    {
        branch.GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Weight")
        {
            branch.GetComponent<PolygonCollider2D>().isTrigger = false;
            branch.GetComponent<Rigidbody2D>().gravityScale = 1;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator Bridge(GameObject obj,Vector3 start, Vector3 end, float time)
    {
        var i = 0.0f;
        var rate = 1.0f/time;
        while(i<1)
        {
            i += Time.deltaTime*rate;
            if(obj!=null)
            {
                obj.transform.position = Vector3.Lerp(start,end,i);
                Debug.Log("Afsa");
            }
        }

        yield return null;
    }
}
