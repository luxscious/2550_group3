using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{

    public GameObject rat;

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<2; i++)
        {         
        Instantiate (rat, new Vector3(Random.Range(10.0f, 30.0f), 0f,-1.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




