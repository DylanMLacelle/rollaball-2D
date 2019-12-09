using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //player information
    float walkingSpeed;
    GameObject player;
    Animator playerAnim;
    bool wasHit = false;
    private void Awake()
    {
        walkingSpeed = (Random.Range(0.05f, 0.13f));
        float scale = (Random.Range(0.25f, 0.5f));
        transform.localScale = new Vector3(scale,scale, 1);
        Destroy(this.gameObject, 30f);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Player")
        {
            wasHit = true;
        }
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x + (-1*(1 * walkingSpeed)), transform.position.y);
        float scale = (Random.Range(0.29f, 0.3f));
        if(scale == 0.3f)
        {
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * 300f);
        }
        if (wasHit)
        {
            //play destroy animation
            Destroy(this.gameObject);
        }
    }
}
