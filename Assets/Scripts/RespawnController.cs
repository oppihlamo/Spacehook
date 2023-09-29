using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Vector2 respawnPoint;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        // spawn location created from starting position
        respawnPoint = transform.position;
    }

    void Update()
    {//create checkpoints
    
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