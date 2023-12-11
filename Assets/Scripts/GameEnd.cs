using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
public Collider2D endPortal;
public TextMeshProUGUI tutorialPassed;
public TextMeshProUGUI crystalText;

void Awake()
{
    tutorialPassed.enabled = false;
}

void OnTriggerEnter2D(Collider2D endPortal)
{
    PlayerController player = endPortal.GetComponent<PlayerController>();
    if (player != null)
    {
            StartCoroutine(TutorialEnd());
    }
}

IEnumerator TutorialEnd()
{
    crystalText.enabled = false;
    tutorialPassed.enabled = true;

    yield return new WaitForSeconds(5);
    
    RestartScene();
}
void RestartScene()
{
    SceneManager.LoadScene("SpacehookScene");
}
}
