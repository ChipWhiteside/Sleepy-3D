using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Silence
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(CircleCollider2D))]

    public class ItemPickup : MonoBehaviour
    {
        public Item item;

        private SpriteRenderer sr;
        private CircleCollider2D cc;

        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            cc = GetComponent<CircleCollider2D>();

            sr.sprite = item.icon;
            sr.sortingLayerName = "Player";

            cc.radius = .7f;
        }

        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.name == "Player")
        //    {
        //        GameManager.instance.inventory.Add(item);
        //        GameEvents.instance.UpdateInv();
        //        Destroy(this.gameObject);
        //    }
        //}
    }
}
