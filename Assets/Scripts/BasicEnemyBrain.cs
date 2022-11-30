using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silence {
    
    [CreateAssetMenu(fileName = "New Basic Enemy Brain", menuName = "Basic Enemy Brain")]
    public class BasicEnemyBrain : EnemyBrain
    {
        //new EnemyBrainStates currentState = EnemyBrainStates.ChaseSleepy;

        public override void Think(Nightmare nightmare)
        {
            GameManager.instance.gameObject.GetComponent<EnemyActions>().TrackSleepy(nightmare, false);
        }

        //private void TrackSleepy(Nightmare nightmare)
        //{
        //    Vector3 targetPosition = Vector3.MoveTowards(transform.position, nightmare.Sleepy.position, nightmare.nightmareObj.speed * Time.deltaTime);
        //    Vector3 direction = nightmare.Sleepy.position - transform.position;

        //    transform.position = targetPosition;
        //    nightmare.UpdateAnimatorValues(direction.y, direction.x);

        //    // If nightmare moves left and is facing right OR moves right and is facing left, flip
        //    if ((direction.x < 0 && nightmare.facingRight) || (direction.x > 0 && !nightmare.facingRight))
        //    {
        //        nightmare.Flip();
        //    }
        //}

        //If player is atacking knee
        //Do ground slam
        // Then tarck sleepy
    }
}