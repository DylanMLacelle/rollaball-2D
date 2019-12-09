using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    bool wasHit = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<playerMovement>().StarsCollected += 0.05f;
        Debug.Log("Stars collected: " + player.GetComponent<playerMovement>().StarsCollected.ToString());
        wasHit = true;
    }

    private void FixedUpdate()
    {
        if(wasHit)
        {
            Destroy(this.gameObject);
        }

    }
}
