using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class RespawnController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public Vector2 respawnPoint;
    public static RespawnController instance2;
    public TextMeshProUGUI respawns;
    public int respawnCount = 0;
    void Awake()
    {
        instance2 = this;
        playerRb = GetComponent<Rigidbody2D>();
        respawns.enabled = false;
    }
    void Start()
    {
        // spawn location created from starting position
        respawnPoint = transform.position;
    }

    void UpdateRespawns()
    {
        if (respawnCount > 0)
        {
            respawns.enabled = true;
        }
        if (respawnCount == 1)
        {
            respawns.text = respawnCount.ToString() + " respawn";
        }
        else
        {
            respawns.text = respawnCount.ToString() + " respawns";
        }
    }
    //checks if player hits a checkpoint and reassigns respawn location
    void OnTriggerEnter2D(Collider2D door)
    {
        if (door.tag == "Checkpoint")
        {   
            Checkpoint1();
        }

        if (door.tag == "Checkpoint2")
        {   
            Checkpoint2();
        }
    }
    //set new respawnpoint according to checkpoint hit
    void Checkpoint1()
    {
        respawnPoint = new Vector2(83.88f, -2f);
    }

    void Checkpoint2()
    {
        respawnPoint = new Vector2(148.2f, 2f);
    }

    public void RespawnToCheckpoint()
    {
        playerRb.velocity = new Vector2(0, 0);
        transform.position = respawnPoint;
        respawnCount += 1;
        UpdateRespawns();
    }

    void FixedUpdate()
    {
        // if player falls off-camera, position and velocity reset to start
        if(transform.position.y < -10f || (transform.position.y > 10f) || (transform.position.x < -11))
        {    
            RespawnToCheckpoint();
        }
    }
}