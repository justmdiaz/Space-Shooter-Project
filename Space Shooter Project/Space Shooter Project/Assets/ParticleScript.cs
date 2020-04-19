using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{

    public ParticleSystem particleSpeed;
    public float speed;
    public float Endspeed;
    public GameController GC;
    public bool zoom;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zoom == true)
        {
            GetComponent<ParticleSystem>().playbackSpeed = Endspeed;
            
        }
       

    }
}
