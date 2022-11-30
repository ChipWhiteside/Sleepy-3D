using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Silence
{
    public class PlayerInventory : MonoBehaviour
    {
        public static PlayerInventory instance;

        public List<Item> allItems = new List<Item>();
        public Item[] inventory = new Item[3];
        public Item[][] inv = new Item[3][];

        public Button LeftArrow;
        public Button RightArrow;

        public ItemSlot GhostItem;
        public ItemSlot PhysicalItem;
        public ItemSlot DemonicItem;

        public ItemSlot selectedItemSlot;
        public Item selectedItem
        {
            get { return selectedItemSlot.item; }
        }

        public int selectedItemIndex;

        void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Multiple PlayerInventory instances");
            }
            instance = this;
        }

        public void ToggleLeft()
        {
            SelectItem(selectedItemSlot.left);
        }

        public void ToggleRight()
        {
            SelectItem(selectedItemSlot.right);
        }

        public void SelectItem(ItemSlot itemSlot)
        {
            Debug.LogFormat("Selected ({0}) slot with item type ({1})", itemSlot.name, itemSlot.item.nightmareClass);
            selectedItemSlot = itemSlot;
            selectedItemSlot.Select();
            //GameEvents.instance.UpdateInv();
        }

        public void InventorySlotClicked(int invIndex)
        {
            //if (invIndex < inventory.Length)
            //    SelectItem(inventory[invIndex]);
        }
    }
}