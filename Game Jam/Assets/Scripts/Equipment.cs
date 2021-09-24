using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory")]
public class Equipment : Item
{
    public EquimpentSlot equipSlot;
    public int armorMod;
    public int dmgMod;

    public override void Use() {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquimpentSlot {Head, Chest, Legs, Weapon, Shield, Feet, Neck}
