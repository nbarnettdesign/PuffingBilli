using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    Vector3 position, maxSpawnPos, minSpawnPos;
    GameObject[] enemyPrefabs;

    [SerializeField]
    List<Transform> spawnPositions;

    List<Transform> tempSpawnPositions;

    [SerializeField]
    private float spawnDelay;

    [SerializeField]
    private int spawnAmount;

    private int currentPool;

    [SerializeField] private Pool[] wavesTypes = new Pool[4];
    float posBufferHMin;
    float posBufferHMax;

    // Use this for initialization
    void Start()
    {
        //int spawned = 0;
        //spawnPositions = new List<Vector3>();
        //maxSpawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, 78.0f)); ;
        //minSpawnPos = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 78.0f)); ;


        //while (spawned < numToSpawn)
        //{

        //    //Left of Screen, right of screen //ScreenHeight min, max
        //    //position = Camera.main.ViewportToWorldPoint(new Vector3(Mathf.RoundToInt(Random.Range(0.0f, 1.0f)), Random.Range(0.0f, 1.0f), 78.0f));
        //    int enemy = GetRandomEnemy();
        //    position = AvailablePosition(enemy);
        //    Instantiate(enemyPrefabs[enemy], position, Quaternion.identity);
        //    spawned++;
        //}
        currentPool = 0;
        enemyPrefabs = wavesTypes[currentPool].enemyTypes;
        InvokeRepeating("SpawnFish", spawnDelay, 1);

        tempSpawnPositions = new List<Transform>();

        for (int i = 0; i < spawnPositions.Count; i++)
        {
            tempSpawnPositions.Add(spawnPositions[i]);
        }
    }


    private void SpawnFish()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            int randIndex = Random.Range(0, tempSpawnPositions.Count);

            Vector3 newPos = tempSpawnPositions[randIndex].position;
            Transform fish = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], newPos, Quaternion.identity).transform;
            tempSpawnPositions.RemoveAt(randIndex);

            // they're on the left
            if (newPos.x < 0.0f)
            {
               //do nothing
            }
            else
            {
                fish.Rotate(Vector3.up, 180);
            }
        }

        tempSpawnPositions.Clear();
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            tempSpawnPositions.Add(spawnPositions[i]);
        }
    }

    public void PlayerGrew()
    {
        currentPool++;
        enemyPrefabs = wavesTypes[currentPool].enemyTypes;
    }

    void Update()
    {
        //Debug.Log(Screen.currentResolution.height);
    }

    //Vector3 AvailablePosition(int a_enemy)
    //{

    //    ////spawnPositions.Add(newPos);
    //    ////float size = 0;

    //    ////switch (a_enemy)
    //    ////{
    //    ////    case 0:
    //    ////        size = 0.05f;
    //    ////        break;
    //    ////    case 1:
    //    ////        size = 0.10f;
    //    ////        break;
    //    ////    case 2:
    //    ////        size = 0.15f;
    //    ////        break;
    //    ////    case 3:
    //    ////        size = 0.20f;
    //    ////        break;
    //    ////    case 4:
    //    ////        size = 0.25f;
    //    ////        break;
    //    //// }

    //    ////for (int i = 0; i < enemyPrefabs.Count; i++)
    //    ////{ 
    //    ////    if (newPos.y + size != spawnPositions[i].y && newPos.y - size != spawnPositions[i].y)
    //    ////    {
    //    ////        spawnPositions.Add(newPos);
    //    ////        return newPos;
    //    ////    }
    //    ////    else
    //    ////    {
    //    ////        position = Camera.main.ViewportToWorldPoint(new Vector3(Mathf.RoundToInt(Random.Range(0.0f, 1.0f)), Random.Range(0.0f, 1.0f), 78.0f));
    //    ////    }
    //    ////}

    //    //return newPos;
    //}
}



[System.Serializable]
struct Pool
{
    public string name;
    public GameObject[] enemyTypes;
}
