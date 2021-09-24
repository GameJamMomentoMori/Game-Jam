using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharStat
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {
        if(newItem != null) {
            armor.AddMod(newItem.armorMod);
            dmg.AddMod(newItem.armorMod);
        }

        if(oldItem != null) {
            armor.RemoveMod(newItem.armorMod);
            dmg.RemoveMod(newItem.armorMod);
        }
    }

    public override void Die() {
        base.Die();
        PlayerManager.instance.KillPlayer();
    }
}
