using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace Silence
{
    public class EnemyActions : MonoBehaviour
    {


        public void TrackSleepy(Nightmare nightmare, bool avoidPlayer)
        {
            Vector3 targetPosition = Vector3.MoveTowards(nightmare.transform.position, nightmare.Sleepy.position, nightmare.nightmareObj.speed * Time.deltaTime);
            Vector3 direction = nightmare.Sleepy.position - nightmare.transform.position;

            // If nightmare tries to avoid player AND the next step in their path is within the 5 units of the player, path around
            if (avoidPlayer && Vector3.Distance(targetPosition, nightmare.Sleepy.transform.position) < 5)
            {
                PathAroundPlayer(nightmare);
            }
            else
            {
                nightmare.transform.position = targetPosition;
                nightmare.UpdateAnimatorValues(direction.y, direction.x);
            }

            // If nightmare moves left and is facing right OR moves right and is facing left, flip
            if ((direction.x < 0 && nightmare.facingRight) || (direction.x > 0 && !nightmare.facingRight))
            {
                nightmare.Flip();
            }
        }

        public void PathAroundPlayer(Nightmare nightmare)
        {
            Vector3 targetPosition = Vector3.RotateTowards(nightmare.transform.position, nightmare.Sleepy.transform.position, nightmare._Speed, nightmare._Speed);
            Vector3 direction = targetPosition - nightmare.transform.position;
            nightmare.transform.position = targetPosition;
            nightmare.UpdateAnimatorValues(direction.y, direction.x);
        }

        public void DefendWeakspot(Nightmare nightmare /*, Transform weakSpotBeingAttacked*/)
        {
            Debug.Log(nightmare.name + " is defending weakspot");
        }
    }
}