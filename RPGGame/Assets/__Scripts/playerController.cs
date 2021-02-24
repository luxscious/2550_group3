using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed = 10f;
    public float jumpForce = 400f;
    public int maxHealth = 100;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public int currentHealth;

    public Animator animator; 
    private Rigidbody2D rigidBody;
    public healthBar HealthBar;

    private float horizontalInput = 0f;
    private bool jump = false;
    private bool onGround;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();

        //start with full health
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update() {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        horizontalInput = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        animator.SetFloat("JumpSpeed", rigidBody.velocity.y);
        animator.SetBool("OnGround", onGround);

        if(Input.GetButtonDown("Jump") && onGround) {
            jump = true;
        }

        //subtract health when player is hit
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    void FixedUpdate() {
        Move(horizontalInput, jump);
        jump = false;
    }

    void Move(float move, bool jump) {
        if(onGround) {
                rigidBody.velocity = new Vector2(move, rigidBody.velocity.y);

                if(move > 0 && !facingRight) {
                    Flip();
                } else if(move < 0 && facingRight) {
                    Flip();
                }
        }
        if(jump) {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void Flip() {
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
    }
}
