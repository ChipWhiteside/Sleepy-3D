using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

namespace Silence
{
    public class EnemyActions : MonoBehaviour
    {
        public Transform Sleepy;
        public Transform Player;

        public void TrackSleepy(Nightmare nightmare, bool avoidPlayer)
        {
            Vector3 targetPosition = Vector3.MoveTowards(nightmare.transform.position, Sleepy.position, nightmare.nightmareObj.speed * Time.deltaTime);
            Vector3 direction = (Sleepy.position - nightmare.transform.position).normalized;
            Debug.DrawLine(nightmare.transform.position, nightmare.transform.position + direction, Color.white);

            nightmare.UpdateAnimatorValues(direction.y, direction.x);

            // If nightmare tries to avoid player AND the next step in their path is within the 3 units of the player, path around
            if (avoidPlayer && Vector3.Distance(targetPosition, Player.transform.position) < 3)
            {

                Vector3 oppositeDirection = -1 * (Player.position - nightmare.transform.position).normalized; //Vector3.MoveTowards(nightmare.transform.position, Player.position, nightmare.nightmareObj.speed * Time.deltaTime);

                // Constrain to max of 90 degrees either direction
                Vector3 clockwiseNintyDegrees = new Vector3(direction.y, -direction.x, 0.0f);
                Vector3 counterClockwiseNintyDegrees = -1 * clockwiseNintyDegrees;
                Debug.DrawLine(nightmare.transform.position, nightmare.transform.position + clockwiseNintyDegrees, Color.cyan);
                Debug.DrawLine(nightmare.transform.position, nightmare.transform.position + counterClockwiseNintyDegrees, Color.green);

                //Find closest between projected and both 90d vectors
                float d1 = Vector3.Distance(clockwiseNintyDegrees, oppositeDirection);
                float d2 = Vector3.Distance(counterClockwiseNintyDegrees, oppositeDirection);
                Vector3 chosen90DVector = d1 < d2 ? clockwiseNintyDegrees : counterClockwiseNintyDegrees;

                // Find whether closer 90d or projected V is closer to target and take that one
                float d3 = Vector3.Distance(chosen90DVector, Sleepy.position);
                float d4 = Vector3.Distance(oppositeDirection, Sleepy.position);
                Vector3 chosenOppositeVector = d3 < d4 ? chosen90DVector : oppositeDirection;

                //Vector3.Angle(direction, oppositeDirection);
                Debug.DrawLine(nightmare.transform.position, nightmare.transform.position + chosenOppositeVector, Color.red);

                // Check which 
                // If avg vector is closer to 0, take more of the opposite direction

                float avgX = (direction.x + oppositeDirection.x) / 2;
                float avgY = (direction.y + oppositeDirection.y) / 2;
                float percentage = Mathf.Abs(1 - (Mathf.Abs(avgX) + Mathf.Abs(avgY)));
                Debug.LogFormat("avgX: {0}, avgY: {1}, %: {2}", avgX, avgY, percentage);
                //Vector3.MoveTowards(nightmare.transform.position, Player.position, nightmare.nightmareObj.speed * Time.deltaTime);

                float adjustedAvgX = ((direction.x * (1 - percentage)) + (chosenOppositeVector.x * percentage)); // /2;
                float adjustedAvgY = ((direction.y * (1 - percentage)) + (chosenOppositeVector.y * percentage)); // /2;
                Debug.LogFormat("adjAvgX: {0}, adjAvgY: {1}, p: {2}", adjustedAvgX, adjustedAvgY, percentage);

                Vector3 newAdjustedAvgDirection = new Vector3(adjustedAvgX, adjustedAvgY, 0.0f).normalized;

                Vector3 newAvgPosition = Vector3.MoveTowards(nightmare.transform.position, nightmare.transform.position + newAdjustedAvgDirection, nightmare.nightmareObj.speed * Time.deltaTime);
                Debug.DrawLine(nightmare.transform.position, newAdjustedAvgDirection, Color.yellow);

                nightmare.transform.position = newAvgPosition;
            }
            else
            {
                nightmare.transform.position = targetPosition;
            }



            /**
             * 
             * The maximum an enemy can path away from sleepy is 90 degrees (perpendicular) to the line directly from enemy to Sleepy
             * The closer the average between the x (or y) values between the direction to Sleepy and the direction away from player is to 0, 
             *  the higher the percentage we use the away from player direction.
             * 0 average meaning 100% away from player and 1 average being 100% towards Sleepy
             * 0 avg means that to move away from the Player, the enemy would have to move directly away from Sleepy
             *  (x = -1 to move away from player and x = 1 to move towards Sleepy)
             *  
             * Need to account for if the player just stands on Sleepy and the enemy could never path to Sleepy
             * 
             * Rotate 2D vector 90 degrees clockwise: (x, y) -> (y, -x)
             *  (Counter clockwise negate X again)
             * 
             */

            // If nightmare moves left and is facing right OR moves right and is facing left, flip
            if ((direction.x < 0 && nightmare.facingRight) || (direction.x > 0 && !nightmare.facingRight))
            {
                nightmare.Flip();
            }
        }

        public void PathAroundPlayer(Nightmare nightmare)
        {
            //Debug.Log("Pathings around player");
            //Vector3 targetPosition = Vector3.RotateTowards(nightmare.transform.position, Sleepy.transform.position, nightmare._Speed, nightmare._Speed);
            //Vector3 direction = targetPosition - nightmare.transform.position;
            //nightmare.transform.position = targetPosition;
            
            //nightmare.GetComponent<Rigidbody>().freezeRotation = false;
            nightmare.transform.RotateAround(Player.transform.position, -Vector3.forward, nightmare._Speed * 10 * Time.deltaTime);

            //nightmare.GetComponent<Rigidbody>().freezeRotation = false;

        }

        public void DefendWeakspot(Nightmare nightmare /*, Transform weakSpotBeingAttacked*/)
        {
            Debug.Log(nightmare.name + " is defending weakspot");
        }
    }
}