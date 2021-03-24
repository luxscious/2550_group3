using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rat_movement : MonoBehaviour
{

    Vector2 pointA;
    Vector2 pointB;
    

    
    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector2(transform.position.x,0);
        pointB = new Vector2(transform.position.x+10,0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        move();
    }




    void move()
    {
        transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time*0.1f, 1));
    }
}
