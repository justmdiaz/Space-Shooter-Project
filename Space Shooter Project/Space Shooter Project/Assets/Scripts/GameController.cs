using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public float hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public int score;

    private bool gameOver;
    private bool restart;

    public Text restartText;
    public Text gameOverText;

    public Text winText;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        winText.text = "";
        

        StartCoroutine(SpawnWaves());
        score = 0;
        updateScore();
    }

    void Update ()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.F))
            {
                SceneManager.LoadScene("Challenge3");
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards [Random.Range (0,hazards.Length )];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject clone = Instantiate(hazard, spawnPosition, spawnRotation);
                ReverseDirection(clone);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
            
            if (gameOver)
            {
                restartText.text = "Press 'F' for Restart";
                restart = true;
                break;
            }
        }
    }

    void ReverseDirection (GameObject clone)
    {
        clone.transform.rotation.y = 0;
        clone.GetComponent<Mover>().speed = 5;
    }

    void updateScore()
    {
        scoreText.text = "Score: " + score;

        if (score >= 100)
        {
            winText.text = "You Win, Game Created by Justin Diaz";
            gameOver = false;
            gameOverText.text = "";
            restartText.text = "Press 'F' for Restart";
            restart = true;
        }
    }

    public void addScore(int scoreParam)
    {
        score += scoreParam;
        updateScore();
    }

    public void GameOver ()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;

    }
}