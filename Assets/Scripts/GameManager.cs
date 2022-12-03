using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Silence
{
    public enum NightmareClass { Physical, Demonic, Ghost }
    public enum NightmareVariantEnum { Basic, Quick, Tank }

    public class GamePhase
    {    
        /**
         * 1: Basic Nightmare Spawn Timer
         * 2: Quick Nightmare Spawn Timer
         * 3: Tank Nightmare Spawn Timer
         * 4: Boss Encounter Spawn Timer
         */
        public Vector4 nightmareSpawnTimers;
        public GamePhase nextPhase;

        public GamePhase(Vector4 spawnTimers, GamePhase next)
        {
            nightmareSpawnTimers = spawnTimers;
            nextPhase = next;
        }
    }

   

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        //public GameObject demon;
        //public GameObject physical;
        //public GameObject phantom;
        public GameObject nightmarePrefab;
        public NightmareVariant[] nightmareVariants = new NightmareVariant[4];
        public List<NightmareType> nightmareTypes;

        private GamePhase currentPhase;
        GamePhase easy = new GamePhase(new Vector4(1.0f, 5.0f, 10000000.0f, 60.0f), null);
        Vector4 spawnTimers = Vector4.zero;

        //public NightmareObject demonObj;

        //public Item defaultPhysical;
        //public Item defaultPyro;
        //public Item defaultDemonic;

        //public List<Item> inventory = new List<Item>();
        //public Item selectedItem;
        public int zIterationsBack;
        public float gameTime;

        [SerializeField]
        private bool spawnNightmares = false;

        private Sleepy sleepy;
        private PlayerController playerController;

        private int nightmares;

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
            playerController = PlayerController.instance;
            nightmares = 0;
            gameTime = 0f;
            //score = 0;
            spawnDelay = 3f;

            currentPhase = easy;

            //inventory.Add(defaultPhysical);
            //inventory.Add(defaultPyro);
            //inventory.Add(defaultDemonic);
            //GameEvents.instance.UpdateInv();

            //selectedItem = inventory[2];

            while (spawnNightmares)
            {
                yield return new WaitForSeconds(spawnDelay);
                //Debug.Log("Spawned enemy");
                //SpawnNightmare();
            }
        }

        private void Update()
        {
            gameTime += Time.deltaTime;

            spawnTimers += new Vector4(Time.deltaTime, Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }

        private void FixedUpdate()
        {
            SpawnAllNightmares();
        }

        private void SpawnAllNightmares()
        {
            Vector4 toSpawn = Vector4.zero;
            if (spawnTimers.x > currentPhase.nightmareSpawnTimers.x)
            {
                SpawnNightmare(nightmareVariants[0]);
                spawnTimers.x = 0; // Reset spawn timer for basic nightmares
            }
            if (spawnTimers.y > currentPhase.nightmareSpawnTimers.y)
            {
                SpawnNightmare(nightmareVariants[1]);
                spawnTimers.y = 0; // Reset spawn timer for quick nightmares
            }
            if (spawnTimers.z > currentPhase.nightmareSpawnTimers.z)
            {
                SpawnNightmare(nightmareVariants[2]);
                spawnTimers.z = 0; // Reset spawn timer for tank nightmares
            }
            if (spawnTimers.w > currentPhase.nightmareSpawnTimers.w)
            {
                SpawnBossEncounter();
                spawnTimers.w = 0; // Reset spawn timer for boss encounter
            }
        }

        void SpawnNightmare(NightmareVariant variant)
        {
            Debug.Log("Spawned " + variant.name);

            nightmares++;

            float nightmareXSpawn = Random.Range((sleepy.transform.position.x - sleepy.spawnRadius), (sleepy.transform.position.x + sleepy.spawnRadius));

            //(𝑥−𝑢)2+(𝑦−𝑣)2=𝑟2
            //𝑦=𝑣±𝑟2−(𝑥−𝑢)2
            float u = sleepy.transform.position.x;
            float v = sleepy.transform.position.y;
            float nightmareYSpawn = v + Mathf.Sqrt(Mathf.Pow(sleepy.spawnRadius, 2) - Mathf.Pow(nightmareXSpawn - u, 2));

            // No idea what this does or the point of it...
            // This might alternate spawning a nightmare above and below sleepy
            if ((nightmares % 2).Equals(0))
                nightmareYSpawn = 0 - nightmareYSpawn;

            // Choose a random type
            NightmareType type = nightmareTypes[Random.Range(0, nightmareTypes.Count)];
            //int nightmareIndex = (int)Random.Range(0, nightmarePrefabs.Length);
            //Debug.Log("nightmareIndex: " + nightmareIndex);

            variant.nightmareType = type;

            GameObject nightmareToSpawn = GameObject.Instantiate(nightmarePrefab, new Vector3(nightmareXSpawn, nightmareYSpawn, 0), new Quaternion(0, 0, 0, 0));
            nightmareToSpawn.GetComponent<Nightmare>().nightmareObj = variant;
            nightmareToSpawn.SetActive(true);
            //d.GetComponent<Nightmare>().Sleepy = sleepy.transform;
            ////d.GetComponent<Nightmare>().nightmareObj = demonObj;
        }

        private void SpawnBossEncounter()
        {
            Debug.Log("Spawn boss encounter");

        }

        void GameOver()
        {
            Debug.Log("Game Over");
            Debug.Log("Time survived: " + gameTime);
            Debug.Log("Nightmares Defeated: " + playerController.nightmareDefeated);
            Debug.Log("Score: " + gameTime * 20 + playerController.nightmareDefeated * 100);
        }

        void SetupPhases()
        {
            List<GamePhase> phases = new List<GamePhase>();
            GamePhase sleepysRoom = new GamePhase(new Vector4(10000.0f, 10000.0f, 10000.0f, 10000.0f), null);
            GamePhase easy = new GamePhase(new Vector4(1.0f, 5.0f, 10000.0f, 60.0f), null);
            GamePhase medium = new GamePhase(new Vector4(0.5f, 1.0f, 10000.0f, 60.0f), null);
            GamePhase hard = new GamePhase(new Vector4(0.25f, 0.5f, 5.0f, 60.0f), null);
            
        }
    }
}