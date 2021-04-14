using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playerController : MonoBehaviour
{

    public float speed = 10f;
    public float jumpForce = 400f;
    public float hitForce = -1f;
    public int maxHealth = 100;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public int currentHealth;
    public static bool ratKing;
    private float exp;
    public static int points;

    public Animator animator;
    public Animator transition;
    private Rigidbody2D rigidBody;
    public healthBar HealthBar;
    public Interactable focus;
    public InventoryObject inventory;
    

    
    public static float horizontalInput = 0f;
    private bool jump = false;
    public static bool onGround;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        ratKing = false;

        //Start with full health
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
        //inventoryUI.SetInventory(inventory);
    }

    private void Awake()
    {
        //inventory = new Inventory();

    }

    // Update is called once per frame
    void Update()
    {

        exp = playerAttack.exp;

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        horizontalInput = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        //animator.SetFloat("JumpSpeed", rigidBody.velocity.y);
        animator.SetBool("OnGround", onGround);

        if (Input.GetButtonDown("Jump") && onGround )
        {
            jump = true;
        }

        if (currentHealth < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }

        if (exp > 9)
        {
            ratKing = true;
        }

        
    }

    void FixedUpdate()
    {
        if(Input.GetButton("Fire1") == false) {
            Move(horizontalInput, jump);
        }
        jump = false;
    }

    void Move(float move, bool jump)
    {
        if (onGround)
        {
            rigidBody.velocity = new Vector2(move, rigidBody.velocity.y);

            if (move > 0 && !facingRight)
            {
                Flip();
                hitForce = -1f;
            }
            else if (move < 0 && facingRight)
            {
                Flip();
                hitForce = 1f;
            }
        }
        if (jump)
        {
            rigidBody.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void Flip()
    {
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
        points --;
        HealthBar.SetHealth(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.name == "ratEnemyPH(Clone)" && ratKing)
        {

        } else if (col.name == "Bringer-of-Death_Idle_1") {
            TakeDamage(20);
        }
        else
        {
            TakeDamage(10);
            rigidBody.AddForce(new Vector2(0f, 200f));
        }

        if (col.CompareTag("Apple"))
        {
            Destroy(col.gameObject);
            points ++;
            if (currentHealth < maxHealth)
            {
                currentHealth = currentHealth + 20;
                HealthBar.SetHealth(currentHealth);
            }
            

        }
        else if (col.gameObject.CompareTag("Berry"))
        {
            Destroy(col.gameObject);
            points ++;
            if (currentHealth < maxHealth)
            {
                currentHealth = currentHealth + 15;
                HealthBar.SetHealth(currentHealth);
            }

        } else
        {
            HealthBar.SetHealth(currentHealth);
        }

        if (col.gameObject.CompareTag("potion"))
        {
            Destroy(col.gameObject);
            points ++;
            if (currentHealth < maxHealth)
            {
                currentHealth = maxHealth;
                HealthBar.SetHealth(currentHealth);
            }

        }

  

        var item = col.GetComponent<Items>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("LevelChanger"))
        {
            StartCoroutine(LevelLoad(SceneManager.GetActiveScene().buildIndex + 1));
        }


    }

    IEnumerator LevelLoad(int level)
    {
        transition.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level);
    }

    //Reset inventory when quit controll
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
