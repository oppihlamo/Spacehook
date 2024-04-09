using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckpointText : MonoBehaviour
{

public TextMeshProUGUI checkpointText;
public Animator textFade;
public bool checkpointTaken = false;
public Collider2D door;



void Awake()
{
    checkpointText.enabled = false;
    GetComponent<Animator>();
}
void OnTriggerEnter2D(Collider2D checkpoint)
{   //when player picks up checkpoint on level for the first time, show text animation, then hide text
    PlayerController player = checkpoint.GetComponent<PlayerController>();
    if (player!= null && (checkpointTaken == false))
    {   
        checkpointText.enabled = true;
        textFade.SetBool("checkpointHit", true);
        checkpointTaken = true;
        StartCoroutine(HideText());
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2);

        checkpointText.enabled = false;
        textFade.SetBool("checkpointHit", false);
    }
}
}
