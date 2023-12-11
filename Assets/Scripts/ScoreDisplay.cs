using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay instance;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    private void Awake()
    {
        instance = this;
        scoreText.enabled = false;
    }
    //keep score text hidden until its needed
    void Update()
    {
        if (score > 0)
        {
            scoreText.enabled = true;
        }
    }

    public void Pickup()
    {
        score += 1;
        scoreText.text = "Crystals collected: " + score.ToString();
    }
}
