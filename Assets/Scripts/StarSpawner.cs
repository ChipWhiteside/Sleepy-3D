using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace Silence
{
    public class StarSpawner : MonoBehaviour
    {
        public GameObject StarOriginal;
        public Transform StarParent;

        private Camera MainCamera;

        [SerializeField]
        [Range(0, 50)]
        private int distanceBetweenStars = 15;
        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float offsetBack = 25.0f;
        [SerializeField]
        [Range(0, 50)] 
        private int zIterationsBack = 15;
        [SerializeField]
        [Range(0, 50)]
        private int xIterationsRight = 25;
        [SerializeField]
        [Range(0, 50)]
        private int yIterationsUp = 25;
        [SerializeField]
        private Vector3 startVector = Vector3.zero;

        private void Start()
        {
            MainCamera = Camera.main;
            GameManager.instance.zIterationsBack = zIterationsBack;
            LoadStars();
        }

        public void UpdateStars()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject); 
            }
            
            LoadStars();
        }

        public void LoadStars()
        {
            Debug.Log("xIR: " + xIterationsRight);

            //Vector3 leftP = MainCamera.ScreenToWorldPoint(new Vector3(0, MainCamera.pixelHeight, 10));
            //Vector3 rightP = MainCamera.ScreenToWorldPoint(new Vector3(MainCamera.pixelWidth, MainCamera.pixelHeight, 10));
            //Debug.Log("LeftP: " + leftP + ", RightP: " + rightP);


            // create the starting star
            // if not at 0, 0, 0 then mirror it X and Y (and mirror Y of mirrored X)
            // Then repeat for each level of Z until reached zIterations
            // Use Z in the two functions above to see if the stars need to be loaded in

            for (int planes = 0; planes < zIterationsBack; planes++)
            {
                //Debug.Log("Z  -  " + planes);
                SpawnStarPlane(offsetBack + (planes * distanceBetweenStars));
            }
        }

        // Method which takes a float z plane and spawns all stars within the constrains on that plane
        // Because reflections are handled by the SpawnStarWithReflections function, this method only needs to handle spawning all stars in the positive quadrant
        public void SpawnStarPlane(float z)
        {
            for (int x = (int)startVector.x; x < xIterationsRight; x++)
            {
                for (int y = (int)startVector.y; y < yIterationsUp; y++)
                {
                    //Debug.Log("SpawnStarPlane  -  x: " + x + " | y: " + y + " | z: " + z);

                    SpawnStarWithReflections(new Vector3(x * distanceBetweenStars, y * distanceBetweenStars, z));
                }
            }
        }

        // Method that takes a Vector3 position for a new star to spawn in the positive quadrant and spawn the star along with the (up to) 3 reflections along the X & Y axis
        public void SpawnStarWithReflections(Vector3 pos)
        {
            SpawnStar(pos); // Spawn star in default position

            if (pos.x == 0 && pos.y == 0)
                return;

            if (pos.x != 0)
            {
                // Spawn star as pos.-x pos.y
                SpawnStar(new Vector3(-pos.x, pos.y, pos.z));

            }
            if (pos.y != 0)
            {
                // Spawn star as pos.x pos.-y
                SpawnStar(new Vector3(pos.x, -pos.y, pos.z));
            }
            if (pos.x != 0 && pos.y != 0)
            {
                // Spawn star as pos.-x pos.-y
                SpawnStar(new Vector3(-pos.x, -pos.y, pos.z));
            }
        }

        // Method which takes a Vector3 position in space and instantiates a new star based on the given prefab in that location
        public void SpawnStar(Vector3 pos)
        {
            //Debug.Log("SpawnStar  -  Success");
            GameObject newStar = Instantiate(StarOriginal, pos, Quaternion.identity);
            newStar.transform.parent = StarParent;
        }
    }
}