using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    private Animator anim;
    private float attackTime;
    private float initialAttackTime;
    public static float exp; 

    public Transform attackArea;
    public float attackRange;
    public LayerMask enemies;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        attackTime = 0;
        exp = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if( attackTime < 0.2)
        {
            
            if(Input.GetButton("Fire1"))
            {
                initialAttackTime = Time.time;
                anim.SetBool("Attack", true);
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemies);

                for (int i = 0; i < damage.Length; i++)
                {
                    Destroy( damage[i].gameObject );
                    if(damage[i].gameObject.name == "ratEnemyPH(Clone)") {
                        exp += 1;
                    }
                    
                }
            }

            attackTime = Time.time - initialAttackTime;
        }   else
        {
            attackTime = 0;
            anim.SetBool("Attack", false);
        }

        if(exp > 5) {
            anim.SetBool("Rat", true);
        }
    }
}

