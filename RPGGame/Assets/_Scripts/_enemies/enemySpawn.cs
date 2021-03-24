using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{

    public GameObject rat;
    private float gameTime;
    private float spawnTime;

    
    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime < 10) {
            if(gameTime == 0) {
                gameTime = Time.time;
            }
        } 
        spawnTime = Time.time - gameTime;
        if(spawnTime > 3f) {
            gameTime = 0;
            spawnTime = 0;
            for (int i=0; i<3; i++)
            {         
                Instantiate (rat, new Vector3(Random.Range(10.0f, 40.0f), 1.6f,-1.0f), Quaternion.identity);
            }
        }
    }
}




