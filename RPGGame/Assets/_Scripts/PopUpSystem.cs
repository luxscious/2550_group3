using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUp(string text)
    {
        popUpText.SetText(text);
        popUpBox.SetActive(true);
        animator.SetTrigger("pop");

    }

     void close()
    {
        popUpBox.SetActive(false);
        animator.SetTrigger("close");
    }

  
}
