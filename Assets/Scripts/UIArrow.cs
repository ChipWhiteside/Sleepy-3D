using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silence
{
    public class UIArrow : MonoBehaviour
    {

        private float t = 0;
        private RectTransform rectTransform;
        private Vector3 originalSizeDelta;
        private Vector3 shrinkSizeDelta;

        private Vector3 startSizeDelta;
        private Vector3 targetSizeDelta;

        [SerializeField]
        [Range(0, 10f)]
        private float timeToReachTarget = 0.05f;
        private float percentageShrink = 0.5f;

        private void Start()
        {
            rectTransform = transform.GetComponent<RectTransform>();
            originalSizeDelta = startSizeDelta = targetSizeDelta = rectTransform.sizeDelta;
            shrinkSizeDelta = new Vector3(originalSizeDelta.x * percentageShrink, originalSizeDelta.y * percentageShrink, 0.0f);
        }

        void Update()
        {
            t += Time.deltaTime / timeToReachTarget;
            rectTransform.sizeDelta = Vector3.Lerp(startSizeDelta, targetSizeDelta, t);

            // if we reached shrink size, grow again
            if (Vector3.Distance((Vector3)rectTransform.sizeDelta, shrinkSizeDelta) < 0.1f)
            {
                Grow();
            }
        }

        public void Shrink()
        {
            t = 0;
            startSizeDelta = originalSizeDelta;
            targetSizeDelta = shrinkSizeDelta;
        }

        public void Grow()
        {
            t = 0;
            startSizeDelta = rectTransform.sizeDelta;
            targetSizeDelta = originalSizeDelta;
        }
    }
}