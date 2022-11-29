using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silence
{
    public class InventoryUI : MonoBehaviour
    {
        public Transform PhysicalSlot;
        public Transform GhostSlot;
        public Transform DemonicSlot;


        private ItemSlot[] slots;

        void Start()
        {
            //slots = transform.GetComponentsInChildren<ItemSlot>();
            //GameEvents.instance.onUpdateInv += UpdateUI;
        }

        void Update()
        {

        }

        //void UpdateUI()
        //{
        //    Debug.Log("Slots: " + slots);
        //    Debug.Log("Inv: " + PlayerInventory.instance.inventory);

        //    for (int i = 0; i < slots.Length; i++)
        //    {
        //        if (i < PlayerInventory.instance.inventory.Length)
        //        {
        //            slots[i].Add(PlayerInventory.instance.inventory[i]);
        //        }
        //        else
        //        {
        //            slots[i].Remove();
        //        }
        //    }

        //    //for (int i = 0; i < slots.Length; i++)
        //    //{
        //    //    if (i < Inventory.instance.items.Count)
        //    //    {
        //    //        //slots[i].AddItem(inventory.items[i]);
        //    //        GameEvents.instance.AddInvSlot(i, Inventory.instance.items[i]);
        //    //        //GameEvents.instance.PickupItem(inventory.items[i]);
        //    //    }
        //    //    else
        //    //    {
        //    //        //slots[i].ClearSlot();
        //    //        GameEvents.instance.ClearInvSlot(i);
        //    //    }
        //    //}
        //}
    }
}