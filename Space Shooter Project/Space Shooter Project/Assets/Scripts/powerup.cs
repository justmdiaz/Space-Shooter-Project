using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public GameObject pickupEffect;

    public GameObject UltimateShot;
    public Transform ShotSpawn;
    private float nextFire;

    public GameController gamecontroller;
    GameController gamecontroller_script;

    

    

    void Start ()
    {
        
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("PlayerBolt"))
        {
           
                
                Pickup(other);
                Debug.Log("You hit the Powerup");
            
        }
    }

    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
       


        Destroy(gameObject);

        



    }
}
