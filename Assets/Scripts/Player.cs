using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Silence
{
    public class Player : MonoBehaviour
    {
        public static Player instance;

        public float speed;
        public int nightmareDefeated;

        private PlayerInputActions actions;

        private Rigidbody rb;
        private Vector2 dirFacing;
        private Vector2 dirMoving;

        private List<GameObject> nightmaresClose = new List<GameObject>();

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("More than one player");
            }
            instance = this;

            actions = new PlayerInputActions();

            actions.Playing.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
            actions.Playing.Movement.canceled += _ => MoveStopped();

            actions.Playing.Inventory.performed += _ => InventoryPressed();
            actions.Playing.Use.performed += _ => Use();
        }

        void Start()
        {
            //actions.Playing.Movement.performed += ctx => dirMoving = ctx.ReadValue<Vector2>();
            //actions.Playing.Movement.performed += ctx => dirFacing = ctx.ReadValue<Vector2>();
            //actions.Playing.Movement.canceled += ctx => dirMoving = ctx.ReadValue<Vector2>();



            rb = GetComponent<Rigidbody>();

            dirFacing = Vector2.zero;
            dirMoving = Vector2.zero;
        }

        void Update()
        {
            //Debug.Log("dirMoving: " + dirMoving);
            //Debug.Log("dirFacing: " + dirFacing);

            rb.velocity = dirMoving * speed;
        }

        void Move(Vector2 moveInput)
        {
            //Debug.Log("Move");
            dirMoving = moveInput;
            dirFacing = moveInput;
        }

        void MoveStopped()
        {
            //Debug.Log("Move stopped");
            dirMoving = Vector2.zero;
        }

        void InventoryPressed()
        {
            Debug.Log("Inventory");
        }

        void Use()
        {
            Debug.Log("Use");

            //Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    transform.position = hit.point;
            //}

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
                if (((int)nightmare.GetComponent<Nightmare>().nightmareObj.nclass).Equals((int)GameManager.instance.selectedItem.iclass))
                {
                    Debug.Log("Item matches nightmare type");
                    GameObject.Destroy(nightmare);
                    nightmareDefeated++;
                }
                else
                    Debug.Log("Item DOES NOT match nightmare type");
            }
        }
    }
}
