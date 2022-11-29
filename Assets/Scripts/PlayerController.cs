using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Silence
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;

        public float moveSpeed;
        public int nightmareDefeated;

        private InputHandler inputHandler;
        private PlayerInputActions actions;
        private Rigidbody rb;

        private bool facingRight = true;  // For determining which way the player is currently facing.

        private List<GameObject> nightmaresClose = new List<GameObject>();

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("More than one player");
            }
            instance = this;

            actions = new PlayerInputActions();
        }

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            facingRight = !facingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        public void Move(Vector2 moveInput)
        {
            rb.velocity= new Vector3(moveInput.x * moveSpeed, moveInput.y * moveSpeed, 0.0f);

            // If we move left and are facing right OR move right and are facing left, flip
            if ((moveInput.x < 0 && facingRight) || (moveInput.x > 0 && !facingRight))
            {
                Flip();
            }
        }

        public void InventoryPressed()
        {
            Debug.Log("Inventory");
        }

        public void Use()
        {
            Debug.Log("Use");

            RaycastHit2D[] hits;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            hits = Physics2D.RaycastAll(mousePos, -transform.up, 100.0f);

            foreach (RaycastHit2D hit in hits)
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Nightmare")
                {
                    NightmareClicked(hit.collider.gameObject);
                }
            }
        }

        void OnEnable()
        {
            actions.Enable();
        }

        void OnDisable()
        {
            actions.Disable();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Nightmare in trigger");
            if (collision.tag == "Nightmare")
            {
                nightmaresClose.Add(collision.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Debug.Log("Nightmare out of trigger");
            if (collision.tag == "Nightmare")
            {
                nightmaresClose.Remove(collision.gameObject);
            }
        }

        void NightmareClicked(GameObject nightmare)
        {
            if (nightmaresClose.Contains(nightmare))
            {
                Debug.Log("Nightmare close clicked");
                Nightmare nightmareScript = nightmare.GetComponent<Nightmare>();
                if (((int)nightmareScript.nightmareClass).Equals((int)GameManager.instance.selectedItem.iclass))
                {
                    Debug.Log("Item matches nightmare type");
                    nightmareScript.Hit();
                    nightmareDefeated++;
                }
                else
                    Debug.Log("Item DOES NOT match nightmare type");
            }
        }
    }
}
