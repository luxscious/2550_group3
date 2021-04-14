using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kingEnable : MonoBehaviour
{
    bool attacked;
    bool onGround;
    float speedy;
    bool king;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attacked = playerAttack.attacked;
        onGround = playerController.onGround;
        speedy = Mathf.Abs(playerController.horizontalInput);
        if(!varHandler.ratKing) {
            king = playerController.ratKing;
        } else {
            king = varHandler.ratKing;
        }
        

        
        animator.SetBool("Attack", attacked);
        animator.SetBool("OnGround", onGround);
        animator.SetFloat("Speed", speedy);
        animator.SetBool("King", king);
         
    }
}
