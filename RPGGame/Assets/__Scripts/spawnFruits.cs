using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFruits : MonoBehaviour
{
    public GameObject apple, strawberry, cherry;
    public float spawnRate = 20f;
    float randX;
    float randY;
    float nextSpawn = 0f;
    int itemToSpawn;
    private Vector2 screenBounds;
    Vector2 whereToSpawn;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            itemToSpawn = Random.Range(1, 4); //pick random number between 1-3
            
            whereToSpawn = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), (float)(screenBounds.y - 9.4));

            switch (itemToSpawn)
            {
                case 1:
                    Instantiate(apple, whereToSpawn, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(strawberry, whereToSpawn, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(cherry, whereToSpawn, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;

            }
        }
    }

