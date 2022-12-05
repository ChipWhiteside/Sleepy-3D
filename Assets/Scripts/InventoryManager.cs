using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Silence
{
    public class InventoryManager : MonoBehaviour
    {
        public static InventoryManager instance;

        public List<Item> allItems = new List<Item>();
        public Item[] inventory = new Item[3];
        public Item[][] inv = new Item[3][];

        public Button LeftArrow;
        public Button RightArrow;

        public ItemSlot GhostSlot;
        public ItemSlot PhysicalSlot;
        public ItemSlot DemonicSlot;

        public UIArrow left;
        public UIArrow right;

        [Range(0, 10f)]
        public float timeToReachTarget = 0.05f;

        public ItemSlot selectedItemSlot;
        [HideInInspector]
        public Item selectedItem
        {
            get { return selectedItemSlot.item; }
        }

        [HideInInspector] public Vector3 leftSlotAnchor = new Vector3(0, 0.5f, 0);
        [HideInInspector] public Vector3 centerSlotAnchor = new Vector3(0.5f, 0.5f, 0);
        [HideInInspector] public Vector3 rightSlotAnchor = new Vector3(1, 0.5f, 0);

        [HideInInspector] public Vector3 smallSlotSize = new Vector3(75, 75, 0);
        [HideInInspector] public Vector3 largeSlotSize = new Vector3(100, 100, 0);

        [HideInInspector] public Vector3 smallIconSize = new Vector3(45, 45, 0);
        [HideInInspector] public Vector3 largeIconSize = new Vector3(65, 65, 0);

        void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Multiple PlayerInventory instances");
            }
            instance = this;
        }

        private void Start()
        {
            PhysicalSlot.Select();
        }

        public void ToggleLeft()
        {
            SelectItem(selectedItemSlot.left);
            left.Shrink();
        }

        public void ToggleRight()
        {
            SelectItem(selectedItemSlot.right);
            right.Shrink();
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