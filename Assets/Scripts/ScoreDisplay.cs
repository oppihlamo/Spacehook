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
    }
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void Pickup()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
    }
}
