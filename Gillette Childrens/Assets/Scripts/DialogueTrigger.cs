using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool hasChoices;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        if(hasChoices == true)
        {
            FindObjectOfType<DialogueManager>().hasChoice = true;
        }
        
    }

    public void Back()
    {
        FindObjectOfType<DialogueManager>().back(dialogue);
    }
}
