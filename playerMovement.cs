using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    const float DEFAULT_SPEED = 5f;
    const int MAX_JUMPS = 2;
    const float JUMP_RESET_POINT = -4.65375f;

    //player speed and position
    Vector3 lastPos;
    Vector3 currPos;
    public float CurSpeed { get; private set; }

    //player information
    public float StarsCollected { get; set; }
    private int jumps;
    GameObject player;
    Animator playerAnim;
    Rigidbody2D playerRig;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        playerRig = player.GetComponent<Rigidbody2D>();

        CurSpeed = 1f;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Ground" && transform.position.y <= -5f)
        {
            jumps = MAX_JUMPS;
        }
        if(coll.collider.tag == "Enemy")
        {
            playerRig.AddForce(player.transform.right * (DEFAULT_SPEED * -1f));
        }
    }

    private void FixedUpdate()
    {
        //Take current position minus last position to calculate speed and use for animation
        currPos = transform.position;
        CurSpeed = 1.01f + ((currPos.x - lastPos.x));

        lastPos = currPos;
        if (!gameState.IsPaused)
        {
            if (Input.GetKeyDown("space") && jumps > 0)
            {
                playerRig.AddForce(player.transform.up * (DEFAULT_SPEED), ForceMode2D.Impulse);
                jumps--;
            }
            else if (Input.GetKeyDown("r"))
            {
                gameState.NewGame();
            }
            else
            {
                playerRig.AddForce(player.transform.right * (DEFAULT_SPEED));
                playerAnim.speed = (0.5f * CurSpeed);
            }
        }
        if (transform.position.y <= -8f)
        {
            gameState.NewGame();
        }
    }
}
