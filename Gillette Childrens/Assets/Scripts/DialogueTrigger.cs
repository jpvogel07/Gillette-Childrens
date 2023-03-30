using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    [Serializable]
    public struct Talk
    {
        public List<AudioClip> sentence;
    }

public class DialogueTrigger : MonoBehaviour
{
    public List<Talk> talking;
    public List<Talk> SecretTalking;
    public Dialogue[] dialogues;
    public bool hasChoices;
    public Animation animation;
    public Dialogue[] secretMessages;
    public string[] decisionText = new string[3];
    public bool secret = false;
    public bool[] tasks = new bool[3];
    public int stage;

    

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
            if (SecretTalking[stage].sentence!=null)
            {
                FindObjectOfType<DialogueManager>().talk = SecretTalking[stage].sentence;
            }
            else
            {
                Debug.Log("empty");
            }
        }
        else
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogues[stage]);
            for(int i = 0; i < talking[stage].sentence.Count; i++)
            {
                FindObjectOfType<DialogueManager>().talk[i] = talking[stage].sentence[i];
            }
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
        Debug.Log("playertalking " + this.gameObject.name);
    }
}
