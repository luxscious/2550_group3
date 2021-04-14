using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSS : MonoBehaviour
{
    public float jumpForce = 400f;
    private Rigidbody2D rigidBody;
    private float flipCheck = 0.1f;
    public int maxBossHealth = 50;
    private int currentBossHealth;
    public healthBar HealthBarBoss;

    // Start is called before the first frame update
    void Start()
    {
        currentBossHealth = maxBossHealth;
        HealthBarBoss.SetMaxHealth(maxBossHealth);
        flipCheck = 12f;
        rigidBody = GetComponent<Rigidbody2D>();
        InvokeRepeating("Move", 1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBossHealth <= 0) {
            SceneManager.LoadScene(3);
        }
    }


    void Move()
    {
        rigidBody.AddForce(new Vector2(0f, jumpForce));
        flipCheck = -flipCheck;   
        rigidBody.velocity = new Vector2(flipCheck, rigidBody.velocity.y);
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void TakeDamage(int damage)
    {
        currentBossHealth -= damage;
        HealthBarBoss.SetHealth(currentBossHealth);
    }
}


