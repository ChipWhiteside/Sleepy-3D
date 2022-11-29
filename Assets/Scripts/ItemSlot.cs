using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Silence
{
    public class ItemSlot : MonoBehaviour
    {
        public Item item;
        public int itemSlot;
        public Image icon;

        public ItemSlot left;
        public ItemSlot right;

        void Start()
        {
            //if (icon != null)
            //{

            //}
            //icon = GetComponentInChildren<Image>();
            //icon.enabled = false;
            //icon.sprite = null;
        }

        void Update()
        {
        
        }

        public void Select()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            
            // make it big
            rectTransform.sizeDelta = new Vector2(150, 150);

            // make it go to center
            rectTransform.anchorMax = new Vector3(0.5f, 0.5f);
            rectTransform.anchorMin = new Vector3(0.5f, 0.5f);

            // make image bigger
            icon.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);

            // make left go left
            left.GoLeft();
            // make right go right
            right.GoRight();
        }

        public void GoLeft()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(100, 100);

            rectTransform.anchorMax = new Vector3(0, 0.5f);
            rectTransform.anchorMin = new Vector3(0, 0.5f);

            icon.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
        }

        public void GoRight()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(100, 100);

            rectTransform.anchorMax = new Vector3(1, 0.5f);
            rectTransform.anchorMin = new Vector3(1, 0.5f);

            icon.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 60);
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
            //GameManager.instance.InvSelectionChanged(itemSlot);
        }
    }
}
