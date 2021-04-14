using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private Animator animator;
    private bool attacked;
    private bool axe; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attacked = playerAttack.attacked;
        axe = WeaponSwitch.weaponToggle;

        if(attacked) {
            animator.SetBool("Attack", true);
        } else {
            animator.SetBool("Attack", false);
        }

        if(axe) {
            animator.SetBool("Axe", true);
        }
    }
   
}
