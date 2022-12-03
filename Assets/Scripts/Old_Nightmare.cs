using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silence
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class Old_Nightmare : MonoBehaviour
    {
        public NightmareVariant nightmareObj;
        public Transform sleepy;
        public float speed;

        private SpriteRenderer sr;
        private Animator anim;

        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();

            //sr.sprite = nightmareObj.icon;
            //anim.animation = nightmareObj.anim;
        }

        void Update()
        {
            if (Vector2.Distance(transform.position, sleepy.transform.position) > 7.5)
                transform.position = Vector3.MoveTowards(transform.position, sleepy.position, (speed * 2.5f) * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, sleepy.position, speed * Time.deltaTime);
        }

        void SpeedIncrease()
        {
            speed += .1f;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //if (collision.tag == "Sleepy")
            //{
            //    Debug.Log("Nightmare in sleepy's dream");
            //    nightmareObj.HauntSleepy();
            //    Sleepy.instance.fear++;
            //    GameObject.Destroy(gameObject);
            //}
        }
    }
}
