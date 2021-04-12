using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_move : MonoBehaviour
{

    Vector2 pointA;
    Vector2 pointB;
    

    
    // Start is called before the first frame update
    void Start()
    {
        pointA = new Vector2(transform.position.x,1);
        pointB = new Vector2(transform.position.x+3,1);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        move();
    }




    void move()
    {
        transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time*1f, 1));
    }
}
