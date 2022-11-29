using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Silence
{
    public class Sleepy : MonoBehaviour
    {
        public static Sleepy instance;

        public int fear;        // How many nightmares have entered Sleepy's dream
        public int maxFear = 10;

        [SerializeField]
        [Range(0f, 50f)] float moveSpeed = 0.25f;
        [SerializeField]
        [Range(0f, 50f)] public float spawnRadius = 15;
        [SerializeField]
        [Range(0f, 5f)] float amplitude = 0.25f;
        [SerializeField]
        [Range(0f, 5f)] float frequency = 0.75f;

        void Awake()
        {
            if (instance != null)
            {
                Debug.Log("More than one instance of sleepy");
            }
            instance = this;

            maxFear = 10;
        }

        void FixedUpdate()
        {
            float delta = Time.time;

            //moveSpeed += delta / 10000; // First pass at increasing sleepy's speed over time

            float changeInX = transform.position.x + (moveSpeed * Time.deltaTime);
            float changeInY = Mathf.Sin(delta * frequency) * amplitude;

            transform.position = new Vector3(changeInX, changeInY, 0);
        }

        public void Haunt(float damage)
        {
            fear += (int)damage;
            if (fear >= maxFear)
            {
                GameEvents.instance.GameOver();
            }
        }
    }
}
