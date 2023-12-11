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
// when player hits level end door, hide crystal counter, show end text, restart scene after 5 seconds
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
