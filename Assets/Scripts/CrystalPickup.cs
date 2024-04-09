using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalPickup : MonoBehaviour
{
    public int score = 0;
    public GameObject crystal;

    void Start()
    {

    }
    // pickup crystal, destroy it, add to counter
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController player = collider.GetComponent<PlayerController>();
        if (player != null)
        {
            Object.Destroy(crystal);
            ScoreDisplay.instance.Pickup();
        }
    }
}
