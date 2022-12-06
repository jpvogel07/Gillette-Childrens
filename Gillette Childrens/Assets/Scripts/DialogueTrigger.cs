using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Dialogue dialogue4;
    public bool hasChoices;
    public Animation animation;
    public Dialogue secretMessage;
    public string[] decisionText = new string[3];
    public bool secret = false;
    public bool[] tasks = new bool[3];
    public int  stage;

    private void OnEnable()
    {
        stage = 0;
    }

    public void TriggerDialogue()
    {
        if (secret)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(secretMessage);
            secret = false;
        }
        else if (stage == 0)
        { 
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            stage++;
        }
        else if (stage == 1)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);
        }
        else if (stage == 2)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue3);
        }
        else if (stage == 3)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue4);
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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
