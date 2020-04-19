using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public ParticleSystem particleSystem;
    public float Endspeed;

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public float hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public int score;

    public bool gameOver;
    private bool restart;
    private bool Ultimate;


    public Text restartText;
    public Text gameOverText;

    public Text winText;

    
    
    public float nextFire;

    public GameObject UltimateShot;

    public Transform ShotSpawn;

    public Text UltimateText;
    public float fireRate;
    public AudioSource MusicPlayer;
    public AudioClip loseSound;
    public AudioClip winSound;
    





    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        
        UltimateText.text = "";


        winText.text = "";
        
        

        StartCoroutine(SpawnWaves());
        score = 0;
        updateScore();




        
    }

    void Update ()
    {
        if (Ultimate == true)
        {
            if (Input.GetButton("Fire2") && Time.time > nextFire)
            {
                StartCoroutine(UltimateTimer());

                nextFire = Time.time + fireRate;
                Instantiate(UltimateShot, ShotSpawn.position, ShotSpawn.rotation);

            }
        }


            if (score >= 50)
        {
            UltimateText.text = "Press Shift To Trigger Ultimate";
            Ultimate = true;
        }

        if (gameOver == true)
        {
            UltimateText.text = "";
            particleSystem.GetComponent<ParticleSystem>().playbackSpeed = Endspeed;
        }

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
    IEnumerator UltimateTimer()
    {
        yield return new WaitForSeconds(1);


        Ultimate = false;
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
                
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
            
            if (gameOver)
            {
                restartText.text = "Press 'F' for Restart";
                restart = true;
                winText.text = "";
                break;

            }
        }
    }

   


    public void updateScore()
    {
        scoreText.text = "Score: " + score;
        
        if (score >= 100)
        {
            winText.text = "You Win, Game Created by Justin Diaz";
            gameOver = false;
            gameOverText.text = "";
            restartText.text = "Press 'F' for Restart";
            restart = true;
            particleSystem.GetComponent<ParticleSystem>().playbackSpeed = Endspeed;
            MusicPlayer.clip = winSound;
            MusicPlayer.Play();
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
        UltimateText.text = "";
        MusicPlayer.clip = loseSound;
        MusicPlayer.Play();
    }
}