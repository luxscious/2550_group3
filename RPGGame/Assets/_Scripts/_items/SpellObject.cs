using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell Object", menuName = "Inventory System/Items/Spell")]
public class SpellObject : ItemObject
{
    public int gainPoints;
    public void Awake()
    {
        type = ItemType.Spell;

    }
}
