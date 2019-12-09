using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseForegroundScript : MonoBehaviour
{
    GameObject playerCam;

    void Awake()
    {
        playerCam = GameObject.FindGameObjectWithTag("MainCamera");
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.flipX = Spawnable.SpriteFlip();
        transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
    }

    private void FixedUpdate()
    {
        if(playerCam.transform.position.x - Spawnable.DESPAWN_OFFSET >= transform.position.x)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
