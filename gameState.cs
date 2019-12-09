using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameState : MonoBehaviour
{
    public static float CurrentScore { get; private set; }
    public static bool IsPaused = false;
    public Text scoreOutput;
    public GameObject player;
    public Text speedOutput;
    public Text txtPause;
    private float speed;

    // Update is called once per frame
    void Update()
    {
        CurrentScore += Time.deltaTime;
        scoreOutput.text = Mathf.Round(CurrentScore).ToString();
        speed = Mathf.Round((player.GetComponent<playerMovement>().CurSpeed * 10f) - 10);
        speedOutput.text = $"{ speed.ToString()} speeds per second";
        if(Input.GetKeyDown("escape"))
        {
            if (IsPaused)
            {
                txtPause.enabled = false;
                Time.timeScale = 1f;
            }
            else if (!IsPaused)
            {
                txtPause.enabled = true;
                Time.timeScale = 0f;
            }
            IsPaused = !IsPaused;
        }
    }

    public static void NewGame()
    {
        CurrentScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
