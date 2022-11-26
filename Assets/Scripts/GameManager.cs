using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Silence
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        //public GameObject demon;
        //public GameObject physical;
        //public GameObject phantom;
        public GameObject[] nightmarePrefabs = new GameObject[4];

        //public NightmareObject demonObj;

        //public Item defaultPhysical;
        //public Item defaultPyro;
        //public Item defaultSpiritual;

        public List<Item> inventory = new List<Item>();
        public Item selectedItem;
        public int zIterationsBack;

        [SerializeField]
        private bool spawnNightmares = false;

        private Sleepy sleepy;
        private Player player;

        private int nightmares;
        private float time;

        //private int score;

        private float spawnDelay;

        void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Multiple GameManager instances");
            }
            instance = this;
        }

        IEnumerator Start()
        {
            GameEvents.instance.onGameOver += GameOver;

            sleepy = Sleepy.instance;
            player = Player.instance;
            nightmares = 0;
            time = 0f;
            //score = 0;
            spawnDelay = 3f;



            //inventory.Add(defaultPhysical);
            //inventory.Add(defaultPyro);
            //inventory.Add(defaultSpiritual);
            GameEvents.instance.UpdateInv();

            selectedItem = inventory[2];

            while (spawnNightmares)
            {
                yield return new WaitForSeconds(spawnDelay);
                //Debug.Log("Spawned enemy");
                SpawnNightmare();
            }
        }

        void Update()
        {
            time += Time.deltaTime;
        }

        void SpawnNightmare()
        {
            nightmares++;

            float nightmareXSpawn = Random.Range((sleepy.transform.position.x - sleepy.spawnRadius), (sleepy.transform.position.x + sleepy.spawnRadius));
            //Debug.Log("X spawn: " + nightmareXSpawn);

            //(𝑥−𝑢)2+(𝑦−𝑣)2=𝑟2
            //𝑦=𝑣±𝑟2−(𝑥−𝑢)2
            float u = sleepy.transform.position.x;
            float v = sleepy.transform.position.y;
            float nightmareYSpawn = v + Mathf.Sqrt(Mathf.Pow(sleepy.spawnRadius, 2) - Mathf.Pow(nightmareXSpawn - u, 2));
            //Debug.Log("Y spawn: " + nightmareYSpawn);

            if ((nightmares % 2).Equals(0))
                nightmareYSpawn = 0 - nightmareYSpawn;
            //Debug.Log("Y spawn: " + nightmareYSpawn);

            int nightmareIndex = (int)Random.Range(0, nightmarePrefabs.Length);
            //Debug.Log("nightmareIndex: " + nightmareIndex);

            GameObject d = GameObject.Instantiate(nightmarePrefabs[nightmareIndex], new Vector3(nightmareXSpawn, nightmareYSpawn, 0), new Quaternion(0, 0, 0, 0));
            d.GetComponent<Nightmare>().sleepy = sleepy.transform;
            //d.GetComponent<Nightmare>().nightmareObj = demonObj;
        }

        void GameOver()
        {
            Debug.Log("Game Over");
            Debug.Log("Time survived: " + time);
            Debug.Log("Nightmares Defeated: " + player.nightmareDefeated);
            Debug.Log("Score: " + time * 20 + player.nightmareDefeated * 100);
        }

        public void InvSelectionChanged(int invIndex)
        {
            if (invIndex < inventory.Count)
                selectedItem = inventory[invIndex];
        }
    }
}