using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogues;
    public bool hasChoices;
    public Animation animation;
    public Dialogue[] secretMessages;
    public string[] decisionText = new string[3];
    public bool secret = false;
    public bool[] tasks = new bool[3];
    public int stage;

    public AudioSource[] talking;
    public AudioSource SecretTalking;

    private void Awake()
    {
        stage = 0;
        DialogueManager.TriggerTalking += PlayTalking;
    }

    private void OnDisable()
    {
        DialogueManager.TriggerTalking -= PlayTalking;
    }

    public void TriggerDialogue()
    {

        if (secret)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(secretMessages[stage]);
            //secret = false;
        }
        else
        { 
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[stage]);
        }


        if (animation != null)
        {
            animation.Play();
        }

        if(hasChoices == true)
        {
            FindObjectOfType<DialogueManager>().hasChoice = true;

        }
        stage++;
    }

    public void secretTrigger()
    {
        secret = true;
        Debug.Log("The secret is active");
    }

    public void PlayTalking()
    {
        /*
        if (secret)
        {
            SecretTalking.Play();
            return;
        }
        talking[stage].Play();
        */
        //Debug.Log("playertalking " + this.gameObject.name);
    }
}
