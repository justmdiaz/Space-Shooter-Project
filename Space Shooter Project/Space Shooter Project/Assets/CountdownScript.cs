using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    [SerializeField]
    private Text uiText;

    [SerializeField]
    private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public GameController GC;



    void Start ()
    {
        timer = mainTimer;
        
    }

    void Update ()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");

            

        }
        if (GC.score >= 100)
        {
            GC.winText.text = "You Win, Game Created by Justin Diaz";
            GC.gameOver = false;
            canCount = false;
            doOnce = true;
        }
        if (GC.gameOver == true)
            {
            GC.winText.gameObject.SetActive(false);
           
        }

        


        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            GC.GameOver();
            
            if (GC.score <= 100)
            {
                GC.gameOver = true;
               
                
                
            }
        }
    }
}
