using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    const int MAP_WIDTH = 30;
    GameObject player;
    GameObject playerCam;
    bool hasSpawnedABG = false;

    void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject parent = GameObject.FindGameObjectWithTag("Map");
        transform.SetParent(parent.transform);

        int rotate = (int)Mathf.Round(Random.value);
        if (rotate == 0)
        {
            sprite.flipX = true;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void SpawnNewBG()
    {
        if (player.transform.position.x >= transform.position.x)
        {
            Vector3 spawnPos = new Vector3(transform.position.x + MAP_WIDTH, transform.position.y, transform.position.z);
            Instantiate(this.gameObject, spawnPos, new Quaternion(0f, 0f, 0f, 0f));
            hasSpawnedABG = true;
        }
    }
    private void FixedUpdate()
    {
        if(!hasSpawnedABG)
        {
            SpawnNewBG();
        }

        if((playerCam.transform.position.x - Spawnable.DESPAWN_OFFSET >= transform.position.x) && this.hasSpawnedABG)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
