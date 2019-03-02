using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Vector3 offset;
    public GameObject Player;
    
    void Start()
    {
        offset = this.transform.position-Player.transform.position;       
         
    }

    
    void FixedUpdate()
    {
        this.transform.position = Player.transform.position+offset;
        
    }
}
