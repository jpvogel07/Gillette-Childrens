using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool hasChoices;
    public Animation animation;
    public Dialogue dialogue2;
    public Dialogue secretMessage;
    public string[] decisionText = new string[3];
    public bool secret = false;
    public bool[] tasks = new bool[3];
    int stage = 1;
    public void TriggerDialogue()
    {
        if (stage == 1)
        { 
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            stage++;
        }
        else if (secret == true)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(secretMessage);
            secret = false;
        } else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);
            hasChoices = false;
        }


        if (animation != null)
        {
            animation.Play();
        }

        if(hasChoices == true)
        {
            FindObjectOfType<DialogueManager>().hasChoice = true;

        }
        
    }

    public void Back()
    {
        FindObjectOfType<DialogueManager>().back(dialogue);
    }

    public void secretTrigger()
    {
        secret = true;
        Debug.Log("The secret is active");
    }
}
