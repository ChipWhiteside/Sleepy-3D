using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

namespace Silence
{
    public class ItemSlot : MonoBehaviour
    {
        public Item item;
        //public int itemSlot;
        public Image icon;

        public ItemSlot left;
        public ItemSlot right;

        public bool isLeftmost = false;

        private RectTransform rectTransform;
        private RectTransform iconRectTransform;

        private Vector3 startSizeDelta;
        private Vector3 startAnchor;
        private Vector3 startIconSizeDelta;

        private Vector3 targetSizeDelta;
        private Vector3 targetAnchor;
        private Vector3 targetIconSizeDelta;
       
        private float t = 0;
        
        

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            startSizeDelta = targetSizeDelta = rectTransform.sizeDelta;
            startAnchor = rectTransform.anchorMax;
            iconRectTransform = icon.GetComponent<RectTransform>();
            startIconSizeDelta = targetIconSizeDelta = iconRectTransform.sizeDelta;
            targetAnchor = iconRectTransform.anchorMax;
        }

        void Update()
        {
            t += Time.deltaTime / InventoryManager.instance.timeToReachTarget;
            rectTransform.sizeDelta = Vector3.Lerp(startSizeDelta, targetSizeDelta, t);
            rectTransform.anchorMax = rectTransform.anchorMin = Vector3.Lerp(startAnchor, targetAnchor, t);
            iconRectTransform.sizeDelta = Vector3.Lerp(startIconSizeDelta, targetIconSizeDelta, t);
        }

        public void Select()
        {
            startSizeDelta = transform.GetComponent<RectTransform>().sizeDelta;
            startAnchor = transform.GetComponent<RectTransform>().anchorMax;
            startIconSizeDelta = icon.GetComponent<RectTransform>().sizeDelta;

            t = 0;

            isLeftmost = false;

            targetSizeDelta = InventoryManager.instance.largeSlotSize;
            targetAnchor = InventoryManager.instance.centerSlotAnchor;
            targetIconSizeDelta = InventoryManager.instance.largeIconSize; 

            // make left go left
            left.GoLeft();
            // make right go right
            right.GoRight();
        }

        public void GoLeft()
        {
            startSizeDelta = transform.GetComponent<RectTransform>().sizeDelta;
            startAnchor = transform.GetComponent<RectTransform>().anchorMax;
            startIconSizeDelta = icon.GetComponent<RectTransform>().sizeDelta;

            t = 0;

            if (isLeftmost)
            {
                GoRight();
            }
            else
            {
                isLeftmost = true;

                targetSizeDelta = InventoryManager.instance.smallSlotSize;
                targetAnchor = InventoryManager.instance.leftSlotAnchor;
                targetIconSizeDelta = InventoryManager.instance.smallIconSize;
            }
        }

        public void GoRight()
        {
            startSizeDelta = transform.GetComponent<RectTransform>().sizeDelta;
            startAnchor = transform.GetComponent<RectTransform>().anchorMax;
            startIconSizeDelta = icon.GetComponent<RectTransform>().sizeDelta;

            t = 0;

            isLeftmost = false;

            targetSizeDelta = InventoryManager.instance.smallSlotSize;
            targetAnchor = InventoryManager.instance.rightSlotAnchor;
            targetIconSizeDelta = InventoryManager.instance.smallIconSize;
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
            //Debug.Log("Inv slot " + itemSlot + " selected");
            //GameManager.instance.InvSelectionChanged(itemSlot);
        }
    }
}
