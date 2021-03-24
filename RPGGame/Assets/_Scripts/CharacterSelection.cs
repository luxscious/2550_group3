using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;
    private int index = 0;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelection");
        characterList = new GameObject[transform.childCount];
       for(int i =0; i < transform.childCount; i++) //fill array with child objects of characters
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

       foreach(GameObject x in characterList) //set objects to false (cant see them)
        {
            x.SetActive(false);
        }

        if (characterList[index]) //toggle first index
        {
            characterList[index].SetActive(true);
        }
    }

    public void ToggleLeft()
    {
        //toggle off current model
        characterList[index].SetActive(false);

        index--;
        if(index < 0) //index out of bounds, set to max index of array
        {
            index = characterList.Length - 1;
        }

        //toggle on current model
        characterList[index].SetActive(true);
    }
    public void ToggleRight()
    {
        //toggle off current model
        characterList[index].SetActive(false);

        index++;
        if (index > characterList.Length-1) //index out of bounds, set to min index of array
        {
            index = 0;
        }

        //toggle on current model
        characterList[index].SetActive(true);
    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelection", index);
        SceneManager.LoadScene("Tutorial");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Tutorial"));
        
    }

}
