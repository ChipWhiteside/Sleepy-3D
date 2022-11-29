using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace Silence {

    /*
    * Detects when using inputs
    */
    public class InputHandler : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;

        PlayerInputActions inputActions;
        PlayerController playerController;

        Vector2 movementInput;
        [SerializeField]
        private float use_Input;
        [SerializeField]
        private float inventory_Input;
        [SerializeField]
        private float numKey_Input;
        [SerializeField]
        private float q_Input;
        [SerializeField]
        private float e_Input;

        private void Start()
        {
            playerController = PlayerController.instance;
        }

        private void Update()
        {
            float delta = Time.deltaTime;
            TickInput(delta);
        }

        public void OnEnable() {
            if (inputActions ==  null)
            {
                inputActions = new PlayerInputActions();
                inputActions.Player.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.Player.Use.performed += i => use_Input = i.ReadValue<float>();
                inputActions.Player.Inventory.performed += i => inventory_Input = i.ReadValue<float>();
                inputActions.Player.NumKeys.performed += i => numKey_Input = i.ReadValue<float>();
                
                inputActions.Player.InventoryLeft.performed += i => q_Input = i.ReadValue<float>();
                inputActions.Player.InventoryRight.performed += i => e_Input = i.ReadValue<float>();
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            HandlePrimaryInput(delta);
            HandleInventoryInput(delta);
            HandleNumKeysInput(delta);

            Reset();
        }

        private void Reset()
        {
            use_Input = 0;
            inventory_Input = 0;
            numKey_Input = 0;
            q_Input = 0;
            e_Input = 0;
        }

        private void MoveInput(float delta)
        {
            playerController.Move(movementInput);
            horizontal = movementInput.x;
            vertical = movementInput.y;
            //moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        }

        private void HandlePrimaryInput(float delta)
        {
            //inputActions.Player.Use.performed += i => use_Input = i.ReadValue<float>();


            if (use_Input > 0)
            {
                playerController.Use();
            }
        }
        
        private void HandleInventoryInput(float delta)
        {
            //inputActions.Player.Inventory.performed += i => inventory_Input = i.ReadValue<float>();

            if (inventory_Input > 0)
            {
                playerController.InventoryPressed();
            }
            if (q_Input > 0)
            {
                PlayerInventory.instance.ToggleLeft();
            }
            if (e_Input > 0)
            {
                PlayerInventory.instance.ToggleRight();
            }
        }

        private void HandleNumKeysInput(float delta)
        {
            //inputActions.Player.NumKeys.performed += i => numKey_Input = i.ReadValue<float>();
            if (numKey_Input > 0)
            {
                Debug.Log("NumKeysInput Fired");
            }
        }
    }
}
