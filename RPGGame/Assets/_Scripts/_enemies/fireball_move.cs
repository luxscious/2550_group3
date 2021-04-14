using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_move : MonoBehaviour
{

    private Rigidbody2D rigidBody;





    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("Move", 0.1f, 2.0f);
          rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void Move()
    {

        rigidBody.velocity = new Vector2(-4f, rigidBody.velocity.y);
    }



}
