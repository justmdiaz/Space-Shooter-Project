﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
     public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float UltimateSpeed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public GameObject UltimateShot;

    public Transform ShotSpawn;
    public float fireRate;

    private float nextFire;

    private Rigidbody rb;

    public AudioClip audioData;
    public AudioSource musicSource;

    public GameObject pickupEffect;
    public bool Ultimate;
    public Text UltimateEnabled;
    private int UltimateScore;
    private GameController gameController;




   void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
   

        

    }












    void Update()
    {

        

        if (Input.GetButton("Jump") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
                musicSource.clip = audioData;
                musicSource.Play();


                if (Input.GetKey("escape"))
                {
                    Application.Quit();
                }



            }

            







             if (Ultimate == true)
             {
                nextFire = Time.time + 0.1f;
                Instantiate(UltimateShot, ShotSpawn.position, ShotSpawn.rotation);
                musicSource.clip = audioData;
                musicSource.Play();




             }

            
            
         


        }
    IEnumerator UltimateTimer()
    {
        yield return new WaitForSeconds(1);


        Ultimate = false;
    }
        void FixedUpdate()
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;

            rb.position = new Vector3
            (
                 Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                 0.0f,
                 Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

        }

    
}
