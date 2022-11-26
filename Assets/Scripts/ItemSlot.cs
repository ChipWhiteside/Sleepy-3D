using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Silence
{
    public class ItemSlot : MonoBehaviour
    {

        public int itemSlot;
        public Image icon;

        void Start()
        {
            //icon = GetComponentInChildren<Image>();
            icon.enabled = false;
            icon.sprite = null;
        }

        void Update()
        {
        
        }

        public void Add(Item item)
        {
            icon.enabled = true;
            icon.sprite = item.icon;
        }

        public void Remove()
        {
            icon.enabled = false;
            icon.sprite = null;
        }

        public void OnClick()
        {
            Debug.Log("Inv slot " + itemSlot + " selected");
            GameManager.instance.InvSelectionChanged(itemSlot);
        }
    }
}
