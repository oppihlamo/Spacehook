using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public Vector2 respawnPoint;

    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        // spawn location created from starting position
        respawnPoint = transform.position;
    }

    //checks if player hits a checkpoint and reassigns respawn location
    void OnTriggerEnter2D(Collider2D door)
    {
        if (door.tag == "Checkpoint")
        {   
            respawnPoint = new Vector2(83.88f, -3f);
        }

        //checkpoint2
    }
    void FixedUpdate()
    {
        // if player falls off-camera, position and velocity reset to start
        if(transform.position.y < -10f)
        {    
            playerRb.velocity = new Vector2(0, 0);
            transform.position = respawnPoint;
        }
    }
}