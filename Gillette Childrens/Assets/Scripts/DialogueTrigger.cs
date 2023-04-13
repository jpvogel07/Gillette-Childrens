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
    public DialogueManager manager;
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
        manager = GameObject.Find("dialogue manager").GetComponent<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        //Debug.Log(this + " is talking");
        if (secret)
        {
            manager.LoadTalking(SecretTalking[stage].sentence);
            manager.StartDialogue(secretMessages[stage]);
        }
        else
        {
            manager.LoadTalking(talking[stage].sentence);
            manager.StartDialogue(dialogues[stage]);
        }


        if (animation != null)
        {
            animation.Play();
        }

        if (hasChoices == true)
        {
            manager.hasChoice = true;

        }
        stage++;
    }

    public void secretTrigger()
    {
        secret = true;
        Debug.Log("The secret is active");
    }
}
