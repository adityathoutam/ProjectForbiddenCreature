using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject target;
    public float speed;

    private void Start()
    {
        
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if(target!=null)
            transform.position = Vector2.MoveTowards(transform.position,target.transform.position,step);
    }
}
