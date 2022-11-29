using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

namespace Silence
{
    public enum NightmareClass { Physical, Demonic, Pyro }


    public class Nightmare : MonoBehaviour
    {
        public Transform Sleepy;
        public NightmareClass nightmareClass = NightmareClass.Physical;
        public Transform ChildSprite;

        // Eventually change this to a queue or stack of nightmareClasses so Json can be wearing a ghost sheet (thus is a ghost class THEN a physical class)

        [SerializeField]
        private float health = 1.0f; // Health starts at a base and increases based on time
        [SerializeField]
        private float speed = 1.0f; // Speed starts at a base and increases based on time
        [SerializeField]
        private float damage = 1.0f; // Damage starts at a base and increases based on time

        private Animator childAnimator;
        private bool facingRight = true;  // For determining which way the player is currently facing.

        private int vertical;
        private int horizontal;

        public void Instantiate(Transform sleepy, AnimatorController aController, NightmareClass nClass, float gameTime)
        {
            // gameTime increases the health and speed of nightmares. Potentially even the damage.
            Sleepy = sleepy;
            childAnimator = GetComponentInChildren<Animator>();
            childAnimator.runtimeAnimatorController = aController;
            nightmareClass = nClass;
            health = 1.0f;
            speed = 1.0f;
            damage = 1.0f;
        }

        private void Awake()
        {
            childAnimator = GetComponentInChildren<Animator>();
            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement)
        {
            #region Vertical
            float v = 0;

            if (verticalMovement > 0)
            {
                v = 1.0f;
            }
            else if (verticalMovement < 0)
            {
                v = -1.0f;
            }
            #endregion

            #region Horizontal
            float h = 0;

            if (horizontalMovement > 0)
            {
                h = 1.0f;
            }
            else if (horizontalMovement < 0)
            {
                h = -1.0f;
            }
            #endregion

            childAnimator.SetFloat(vertical, v, 0.1f, Time.deltaTime);
            childAnimator.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
        }

        private void FixedUpdate()
        {
            float delta = Time.fixedDeltaTime;
            TrackSleepy(delta);
        }

        private void TrackSleepy(float delta)
        {
            Vector3 targetPosition = Vector3.MoveTowards(transform.position, Sleepy.position, speed * delta);
            Vector3 direction = Sleepy.position - transform.position;

            transform.position = targetPosition;
            UpdateAnimatorValues(direction.y, direction.x);

            // If nightmare moves left and is facing right OR moves right and is facing left, flip
            if ((direction.x < 0 && facingRight) || (direction.x > 0 && !facingRight))
            {
                Flip();
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log("Hit collider:" + collision.name + " (Tag: "+ collision.tag+")");

            if (collision.tag == "Sleepy")
            {
                Debug.Log(name + " hit Sleepy");
                HauntSleepy();

                GameObject.Destroy(gameObject);
            }
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = ChildSprite.localScale;
            theScale.x *= -1;
            ChildSprite.localScale = theScale;
        }

        public void HauntSleepy()
        {
            Sleepy sleepyScript = Sleepy.GetComponent<Sleepy>();
            sleepyScript.Haunt(damage);
        }

        public void Hit()
        {
            GameObject.Destroy(gameObject);
        }

        public void AttackPlayer()
        {

        }

        public void AttackSleepy()
        {
            // Player sucking in animation
        }

    }
}