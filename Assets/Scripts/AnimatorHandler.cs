using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Silence {

    /*
    * Handles performing animations
    */
    public class AnimatorHandler : MonoBehaviour
    {
        InputHandler inputHandler;
        Animator anim;
        
        int vertical;
        int horizontal;

        private void Awake()
        {
            inputHandler = GetComponentInParent<InputHandler>();
            anim = GetComponentInChildren<Animator>();

            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
        }

        private void Start()
        {
            UnityEngine.Debug.Log("V: " + vertical + ", H: " + horizontal);
        }

        private void Update()
        {
            UpdateAnimatorValues(inputHandler.vertical, inputHandler.horizontal);
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

            anim.SetFloat(vertical, v, 0.1f, Time.deltaTime);
            anim.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
        }

        //public void PlayTargetAnimation(string targetAnim, bool isInteracting)
        //{
        //    anim.applyRootMotion = isInteracting;
        //    anim.SetBool("isInteracting", isInteracting);
        //    anim.CrossFade(targetAnim, 0.2f);
        //}

        //public void CanRotate()
        //{
        //    canRotate = true;
        //}

        //public void StopRotation()
        //{
        //    canRotate = false;
        //}

        //private void OnAnimatorMove()
        //{
        //    //if (!playerManager.isInteracting)
        //    //{
        //    //    return;
        //    //}

        //    float delta = Time.deltaTime;
        //    playerLocomotion.rigidbody.drag = 0;
        //    Vector3 deltaPosition = anim.deltaPosition;
        //    deltaPosition.y = 0;
        //    Vector3 velocity = deltaPosition / delta;
        //    playerLocomotion.rigidbody.velocity = velocity;
        //}
    }
}
