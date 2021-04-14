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
    private Vector2 screenPosition;
    public Camera main;

    private void Start()
    {
       // screenPosition = main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), 0));

    }
    // Update is called once per frame
    void Update()
    {
       screenPosition = main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), transform.position.y));
        if (Time.time > nextSpawn)
        {
            itemToSpawn = Random.Range(1, 4); //pick random number between 1-3
            
           

            switch (itemToSpawn)
            {
                case 1:
                    screenPosition = main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width),50));
                    Instantiate(apple, screenPosition, Quaternion.identity);
                    break;
                case 2:
                    screenPosition = main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), 50));
                    Instantiate(strawberry, screenPosition, Quaternion.identity);
                    break;
                case 3:
                    screenPosition = main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), 50));
                    Instantiate(cherry, screenPosition, Quaternion.identity);
                    break;
            }
            nextSpawn = Time.time + spawnRate;

            }
        }
    }



