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
        private Vector3 targetSizeDelta;
        private Vector3 targetAnchorMinMax;
        private Vector3 targetIconSizeDelta;
        private RectTransform startRectTransform;
        private RectTransform startIconRectTransform;
        private float t = 0;
        
        [SerializeField]
        [Range(0, 10f)]
        private float timeToReachTarget = 0.5f;

        void Start()
        {
            rectTransform = startRectTransform = GetComponent<RectTransform>();
            iconRectTransform = startIconRectTransform = icon.GetComponent<RectTransform>();
            targetSizeDelta = rectTransform.sizeDelta;
            targetAnchorMinMax = rectTransform.anchorMax;
            targetIconSizeDelta = icon.rectTransform.sizeDelta;
        }

        void Update()
        {
            t += Time.deltaTime / timeToReachTarget;
            rectTransform.sizeDelta = Vector3.Lerp(startRectTransform.sizeDelta, targetSizeDelta, t);
            rectTransform.anchorMax = Vector3.Lerp(startRectTransform.anchorMax, targetAnchorMinMax, t);
            rectTransform.anchorMin = Vector3.Lerp(startRectTransform.anchorMax, targetAnchorMinMax, t);
            iconRectTransform.sizeDelta = Vector3.Lerp(startIconRectTransform.sizeDelta, targetIconSizeDelta, t);
        }

        public void Select()
        {
            startRectTransform = transform.GetComponent<RectTransform>();
            startIconRectTransform = icon.GetComponent<RectTransform>();
            t = 0;

            isLeftmost = false;

            // make it big
            //rectTransform.sizeDelta = new Vector2(150, 150);
            targetSizeDelta = new Vector3(150, 150, 0);

            // make it go to center
            //rectTransform.anchorMax = new Vector3(0.5f, 0.5f);
            //rectTransform.anchorMin = new Vector3(0.5f, 0.5f); 
            targetAnchorMinMax = new Vector3(0.5f, 0.5f, 0);

            // make image bigger
            //iconRectTransform.sizeDelta = new Vector2(100, 100);
            targetIconSizeDelta = new Vector3(100, 100, 0);


            // make left go left
            left.GoLeft();
            // make right go right
            right.GoRight();
        }

        public void GoLeft()
        {
            startRectTransform = transform.GetComponent<RectTransform>();
            startIconRectTransform = icon.GetComponent<RectTransform>();
            t = 0;

            if (isLeftmost)
            {
                GoRight();
            }
            else
            {
                isLeftmost = true;

                //rectTransform.sizeDelta = new Vector2(100, 100);
                targetSizeDelta = new Vector3(100, 100, 0);

                //rectTransform.anchorMax = new Vector3(0, 0.5f);
                //rectTransform.anchorMin = new Vector3(0, 0.5f);
                targetAnchorMinMax = new Vector3(0, 0.5f, 0);


                //iconRectTransform.sizeDelta = new Vector2(60, 60);
                targetIconSizeDelta = new Vector3(60, 60, 0);
            }
        }

        public void GoRight()
        {
            startRectTransform = transform.GetComponent<RectTransform>();
            startIconRectTransform = icon.GetComponent<RectTransform>();
            t = 0;

            isLeftmost = false;

            //rectTransform.sizeDelta = new Vector2(100, 100);
            targetSizeDelta = new Vector3(100, 100, 0);

            //rectTransform.anchorMax = new Vector3(1, 0.5f);
            //rectTransform.anchorMin = new Vector3(1, 0.5f);
            targetAnchorMinMax = new Vector3(1, 0.5f, 0);

            //iconRectTransform.sizeDelta = new Vector2(60, 60);
            targetIconSizeDelta = new Vector3(60, 60, 0);
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
