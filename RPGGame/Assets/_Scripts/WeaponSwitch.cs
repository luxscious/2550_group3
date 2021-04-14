using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{

    public static bool weaponToggle;

    // Start is called before the first frame update
    void Start()
    {
        weaponToggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWeapon() {
        weaponToggle = true;
    }
}
