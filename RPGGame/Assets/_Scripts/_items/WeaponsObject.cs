using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Weapon", menuName = "Inventory System/Items/Weapon")]
public class WeaponsObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Weapon;
    }
}
