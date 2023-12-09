using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointFade : MonoBehaviour
{
    private SpriteRenderer door;

    void Start()
    {
        door = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();
        if (player != null)
        {
            door.enabled = false;
        }
    }
}
