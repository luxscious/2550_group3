using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSpells : MonoBehaviour
{
    public GameObject potion;
    public float spawnRate = 20f;
    float nextSpawn = 0f;
    private Vector2 screenPosition;
    public Camera main;

    public playerController playerM;
    public playerController playerF;

    public void Update()
    {
        screenPosition = main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), transform.position.y));

        if (playerM.currentHealth < 15 || playerF.currentHealth < 15)
        {
            if (Time.time > nextSpawn)
            {
                screenPosition = main.ScreenToWorldPoint(new Vector2(Random.Range(0, Screen.width), 50));
                Instantiate(potion, screenPosition, Quaternion.identity);

            }
            nextSpawn = Time.time + spawnRate;
        }

    }
}

