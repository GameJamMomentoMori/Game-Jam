using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    
    public static EquipmentManager instance;

    void Awake() {
        instance = this;
    }

    #endregion

    Equipment[] currEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start() {
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquimpentSlot)).Length;
        currEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem) {
        int slotIdx = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if(currEquipment[slotIdx] != null) {
            oldItem = currEquipment[slotIdx];
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        currEquipment[slotIdx] = newItem;
    }

    public void Unequip(int slotIdx) {
        if(currEquipment[slotIdx] != null) {
            Equipment oldItem = currEquipment[slotIdx];
            inventory.Add(oldItem);

            currEquipment[slotIdx] = null;

            if(onEquipmentChanged != null) {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll () {
        for(int i = 0; i < currEquipment.Length; i++) {
            Unequip(i);
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.U)) {
            UnequipAll();
        }
    }
}
