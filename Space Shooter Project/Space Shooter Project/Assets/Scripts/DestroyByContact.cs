using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public GameController gameController;

    private int scoreValue = 10;

    private void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary" || other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);

            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, transform.position, transform.rotation);
                gameController.GameOver();
            }


            gameController.addScore(scoreValue);
        }
    }
}