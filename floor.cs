using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    //public List<GameObject> spawnables;
    //public GameObject star;
    //public GameObject enemy;
    //void Awake()
    //{
    //    GameObject parent = GameObject.FindGameObjectWithTag("Map");
    //    transform.SetParent(parent.transform);
    //    SpawnStuffOnTopOfFloor();
    //    SpawnStar();
    //    SpawnEnemy();
    //    Destroy(this.gameObject, 45f); 
    //}
    //void SpawnStuffOnTopOfFloor()
    //{
    //    float spawnPoint = 0.0f;
    //    int objectsToSpawn = (int)Mathf.Round(Random.Range(0f, 2f));
    //    for (int i = 0;  i < objectsToSpawn; i++)
    //    {
    //        if(spawnPoint == 0.0f)
    //        {
    //            spawnPoint = SpawnObject();
    //        }
    //        else
    //        {
    //            SpawnObject(spawnPoint);
    //        }
    //    }
    //}
    //void SpawnStar()
    //{
    //    int spawnChance = (int)Mathf.Round(Random.Range(0f, 3f));
            
    //    if(spawnChance == 1)
    //    {
    //        float objectSpawnPos = Random.Range(0.5f, 8.5f);
    //        float objectSpawnPosY = Random.Range(-3.45f, 0f);
    //        Vector3 spawnPos = new Vector3(transform.position.x + objectSpawnPos, objectSpawnPosY, transform.position.z);

    //        Instantiate(star, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
    //    }
    //}
    //void SpawnEnemy()
    //{
    //    int spawnChance = (int)Mathf.Round(Random.Range(0f, 2f));

    //    if (spawnChance == 1)
    //    {
    //        float objectSpawnPos = Random.Range(0.5f, 8.5f);
    //        float objectSpawnPosY = Random.Range(-3.45f, 0f);
    //        Vector3 spawnPos = new Vector3(transform.position.x + objectSpawnPos, objectSpawnPosY, transform.position.z);

    //        Instantiate(enemy, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
    //    }
    //}
    //float SpawnObject()
    //{
    //    int objectToSpawn = (int)Mathf.Round(Random.Range(0f, spawnables.Count -1));

    //    float objectSpawnPos = Random.Range(0.5f, 8.5f);
    //    Vector3 spawnPos = new Vector3(transform.position.x + objectSpawnPos, -3.45f, transform.position.z);

    //    Instantiate(spawnables[objectToSpawn], spawnPos, new Quaternion(0f, 0f, 0f, 0f));
    //    return objectSpawnPos;
    //}
    //float SpawnObject(float lastPos)
    //{
    //    float objectSpawnPos = 0.0f;
    //    int objectToSpawn = (int)Mathf.Round(Random.Range(0f, spawnables.Count - 1));
    //    if(lastPos <= 4.5f)
    //    {
    //        objectSpawnPos = Random.Range(4.5f, 8.5f);
    //    }
    //    else
    //    {
    //        objectSpawnPos = Random.Range(0.5f, 4.5f);
    //    }

    //    Vector3 spawnPos = new Vector3(transform.position.x + objectSpawnPos, -3.4f, transform.position.z);

    //    Instantiate(spawnables[objectToSpawn], spawnPos, new Quaternion(0f, 0f, 0f, 0f));
    //    return objectSpawnPos;
    //}
}
