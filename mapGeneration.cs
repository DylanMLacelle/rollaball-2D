using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapGeneration : MonoBehaviour
{
    const float FLOOR_DEFAULT_HEIGHT = -8.44f;
    const float TELEPORTER_OFFSET = 6.7f;
    const float MAP_DEFAULT_HEIGHT = -1.49f;
    const int MAP_WIDTH = 70;

    const float FLOOR_SPAWN_RANGE_MIN = 23f;
    const float FLOOR_SPAWN_RANGE_MAX = 26f;

    bool hasSpawnedFirstFloor = false;
    bool hasSpawnedABG = false;

    //List of non collision background prefabs
    public List<GameObject> backgroundSpawnables;

    //Functional prefabs
    public GameObject enemy;
    public GameObject collectible;
    public GameObject floor;
    public GameObject background;
    public GameObject teleporter;

    float currDifficulty = 1f;
    public GameObject player;
    public GameObject map;
    Vector3 floorLastSpawnPos;
    Vector3 bgLastSpawnPos;

    void Start()
    {
        SpawnFloor();
        SpawnBackground();
    }

    #region Floor spawning
    /// <summary>
    /// Spawns a floor object prefab onto the map
    /// </summary>
    public void SpawnFloor()
    {
        GameObject spawnedFloor = new GameObject();

        if (hasSpawnedFirstFloor)
        {
            currDifficulty = 1 + (gameState.CurrentScore / 50);
            float spawnDistance = UnityEngine.Random.Range(FLOOR_SPAWN_RANGE_MIN * currDifficulty, FLOOR_SPAWN_RANGE_MAX * currDifficulty);
            Vector3 spawnPos = new Vector3(player.transform.position.x + spawnDistance, FLOOR_DEFAULT_HEIGHT, player.transform.position.z);
            floorLastSpawnPos = spawnPos;
            spawnedFloor = Instantiate(floor, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
            SpawnStuffOnTopOfFloor(spawnedFloor);
        }
        else
        {
            Vector3 spawnPos = new Vector3(player.transform.position.x, FLOOR_DEFAULT_HEIGHT, player.transform.position.z);
            floorLastSpawnPos = spawnPos;
            spawnedFloor = Instantiate(floor, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
            hasSpawnedFirstFloor = true;
        }
        SpawnTeleporter(spawnedFloor);
    }


    private void SpawnTeleporter(GameObject parent)
    {
        Vector3 spawnPos = new Vector3(parent.transform.position.x + TELEPORTER_OFFSET, -4.55f, parent.transform.position.z);
        Instantiate(teleporter, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
    }

    void SpawnStuffOnTopOfFloor(GameObject parent)
    {
        int objectsToSpawn = (int)Mathf.Round(UnityEngine.Random.Range(0f, 2f));
        for (int i = 0; i < objectsToSpawn; i++)
        {
            SpawnSpawnable(parent);
        }
    }

    void SpawnSpawnable(GameObject parent)
    {
        int spawnIndex = (int)Mathf.Round(UnityEngine.Random.Range(0f, backgroundSpawnables.Count - 1));

        float objectSpawnPos = UnityEngine.Random.Range(-7.5f, 7.5f);
        Vector3 spawnPos = new Vector3(parent.transform.position.x + objectSpawnPos, -3.7f, parent.transform.position.z);

        Instantiate(backgroundSpawnables[spawnIndex], spawnPos, new Quaternion(0f, 0f, 0f, 0f));
    }

    private bool checkToSpawn(Vector3 spawnPos)
    {
        if (player.transform.position.x >= spawnPos.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    #endregion
    
    void SpawnBackground()
    {
        if(hasSpawnedABG)
        {
            Vector3 spawnPos = new Vector3(player.transform.position.x + MAP_WIDTH, MAP_DEFAULT_HEIGHT, transform.position.z);
            Instantiate(background, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
            bgLastSpawnPos = spawnPos;
        }
        else
        {
            Vector3 spawnPos = new Vector3(player.transform.position.x, MAP_DEFAULT_HEIGHT, transform.position.z);
            Instantiate(background, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
            bgLastSpawnPos = spawnPos;
            hasSpawnedABG = true;
        }
    }

    private void FixedUpdate()
    {
        //check to spawn is players is past spawn point of old spawnable
        if (checkToSpawn(floorLastSpawnPos))
        {
            SpawnFloor();
        }

        //check to see if player is past last bg spawn to spawn new one
        if (checkToSpawn(bgLastSpawnPos))
        {
            SpawnBackground();
        }
    }
}
