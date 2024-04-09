using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
public Collider2D spike;

    void OnTriggerEnter2D(Collider2D spike)
    {   //spikecheck, if yes, respawn
        PlayerController player = spike.GetComponent<PlayerController>();
        if (player != null)
        {
            RespawnController.instance2.RespawnToCheckpoint();
        }
    }
}
