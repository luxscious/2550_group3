using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    private Animator anim;
    public static bool attacked;
    public static float exp; 

    public Transform attackArea;
    public float attackRange;
    public LayerMask enemies;
    public BOSS bossHealthBar; 
    public static int points;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        exp = 0;
        attacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetButton("Fire1") )
        {
            
            if(attacked == false && Input.GetAxisRaw("Horizontal") == 0f)
            {
                anim.SetBool("Attack", true);
                attacked = true;
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemies);

                for (int i = 0; i < damage.Length; i++)
                {
                    if(damage[i].gameObject.name == "Bringer-of-Death_Idle_1") {
                        if(WeaponSwitch.weaponToggle) {
                            bossHealthBar.TakeDamage(3);
                        } else {
                            bossHealthBar.TakeDamage(1); 
                        }
                    } else {
                        Destroy( damage[i].gameObject );
                        points += 2;
                    }
                    if(damage[i].gameObject.name == "ratEnemyPH(Clone)") {
                        exp += 1;
                    }
                    
                }
            }
        }   else if(Input.GetButton("Fire1") == false)
        {
            anim.SetBool("Attack", false);
            attacked = false;
        }

        if(exp > 5) {
            anim.SetBool("Rat", true);
        }
    }
}

