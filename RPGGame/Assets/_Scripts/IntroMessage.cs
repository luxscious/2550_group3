using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMessage : MonoBehaviour
{
    public string popUp;
    // Start is called before the first frame update
    void Start()
    {
        PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
        pop.PopUp(popUp);
        
    }

    
}
