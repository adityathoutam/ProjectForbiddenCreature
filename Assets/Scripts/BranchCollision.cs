using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchCollision : MonoBehaviour
{
   
   public GameObject branchParent;

    public Vector3 start;
    public Vector3 end;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Weight")
        {
            StartCoroutine(Bridge(branchParent,start,end,2));
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
                obj.transform.position = Vector2.Lerp(start,end,i);
                Debug.Log("Afsa");
            }
        }

        yield return null;
    }
}
