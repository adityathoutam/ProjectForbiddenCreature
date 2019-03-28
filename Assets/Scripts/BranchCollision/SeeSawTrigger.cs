using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawTrigger : MonoBehaviour
{
    int count = 8;
  
    public Vector3[] trajectoryList;
    public GameObject go;
    public GameObject rope;
    public GameObject middlepoint;

    public GameObject seesawlog;
    public Vector3 startPos;
    public Vector3 endPos;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            count--;

        }
    }
    private void Update()
    {
        if (count <= 0)
        {
            Debug.Log(count);   

            count = 10;
            Debug.Log("af");
            StartCoroutine(RotateObject(seesawlog, startPos, endPos,0.1f));
            EnemyTrajectoryPath(go.transform.position, middlepoint.transform.position, rope.transform.position);

            Destroy(go, 3f); 
        }
    }
    void EnemyTrajectoryPath(Vector2 p1, Vector2 p2, Vector2 p3)
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
  
        StartCoroutine(rand());
    }



    IEnumerator rand()
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
    private IEnumerator RotateObject(GameObject Local, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;

            Local.transform.eulerAngles = Vector3.Lerp(startPos, endPos, i);

            yield return null;
        }
    }


}
