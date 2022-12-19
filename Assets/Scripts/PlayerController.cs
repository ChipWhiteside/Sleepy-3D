using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Silence
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;
        
        public Transform ChildSprite;
        public float moveSpeed;
        public int nightmareDefeated;
        public float range = 3.0f;
        [Range(0, 1)]
        public float rangeIndicatorAlpha = 0.0f;

        private InputHandler inputHandler;
        private PlayerInputActions actions;
        private Rigidbody rb;
        private SphereCollider sc;

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
            sc = GetComponent<SphereCollider>();
            sc.radius = range;
        }

        void Update()
        {
            if (rangeIndicatorAlpha > 0)
            {
                rangeIndicatorAlpha -= .05f * Time.deltaTime;
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
            Debug.Log("USE");


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);
            foreach (RaycastHit hit in hits)
            {
                Debug.Log("Clicked object: " + hit.collider.gameObject.name);
                if (hit.collider.gameObject.tag == "Nightmare")
                {
                    NightmareClicked(hit.collider.gameObject);
                }
            }



            //RaycastHit[] hits;
            //        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            //        hits = Physics.RaycastAll(mousePos, -transform.up, 100.0f);


            //        Debug.Log("Hits: " + hits + " ("+hits.Length+")");
            //        //foreach (RaycastHit hit in hits)
            //        //{
            //        //    Debug.Log("Clicked object: " + hit.collider.gameObject.name);
            //        //    if (hit.collider.gameObject.tag == "Nightmare")
            //        //    {
            //        //        NightmareClicked(hit.collider.gameObject);
            //        //    }
            //        //}


            //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //        RaycastHit hit;
            //        if (Physics.Raycast(ray, out hit, 100))
            //        {
            //            Debug.Log(hit.transform.name);
            //            Debug.Log("hit");
            //        }
        }

        void OnEnable()
        {
            actions.Enable();
        }

        void OnDisable()
        {
            actions.Disable();
        }

        private void OnTriggerEnter(Collider collision)
        {
            //Debug.Log("Nightmare in trigger");
            if (collision.tag == "Nightmare")
            {
                nightmaresClose.Add(collision.gameObject);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            //Debug.Log("Nightmare out of trigger");
            if (collision.tag == "Nightmare")
            {
                nightmaresClose.Remove(collision.gameObject);
            }
        }

        void NightmareClicked(GameObject nightmare)
        {
            if (nightmaresClose.Contains(nightmare))
            {
                Nightmare nightmareScript = nightmare.GetComponent<Nightmare>();
                Debug.LogFormat("Nightmare of type ({0}) clicked with weapon type ({1})", nightmareScript.nightmareClass.ToString(), InventoryManager.instance.selectedItem.nightmareClass.ToString());

                if ((nightmareScript.nightmareClass).Equals(InventoryManager.instance.selectedItem.nightmareClass))
                {
                    Debug.Log("Item matches nightmare type");
                    nightmareScript.Hit();
                    nightmareDefeated++;
                }
                else
                    Debug.Log("Item DOES NOT match nightmare type");
            }
            else // nightmare not in range
            {
                Debug.Log("OUT OF RANGE");
                if (rangeIndicatorAlpha <= 0.9f)
                    rangeIndicatorAlpha += 0.1f;
            }
        }
    }
}
