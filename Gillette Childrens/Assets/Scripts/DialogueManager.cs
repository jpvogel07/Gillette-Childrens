using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    public static Action DialogueDone = delegate { };

    public bool tut;
    public AudioSource speech;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animateBox;
    public Animator animateName;
    public GameObject textBox;
    public GameObject mouse;
    /*
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    */
    public GameObject blocker;
    public bool hasChoice;
    public bool dialogueOpen = false;

    private Queue<string> sentences;

    public static Action TriggerTalking = delegate { };

    void Awake()
    {
        sentences = new Queue<string>();
        mouse = GameObject.Find("mouse")?.gameObject;
        speech = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(dialogueOpen == false)
        {
            dialogueText.enabled = false;
            textBox.SetActive(false);
            nameText.enabled = false;
        } 
        else if(dialogueOpen == true)
        {
            dialogueText.enabled = true;
            textBox.SetActive(true);
            nameText.enabled = true;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        /* if (mouse.GetComponent<PlayerMovement>().ClkObj != null)
         {
             mouse.GetComponent<PlayerMovement>().ClkObj?.PutDown();
             Debug.Log("putdown");
             mouse.GetComponent<PlayerMovement>().ClkObj = null;
         }
        */
        //DialogueDone();

        dialogueText.enabled = true;
        textBox.SetActive(true);
        nameText.enabled = true;
        /*
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        */
        blocker.SetActive(true);
        dialogueOpen = true;

        if (animateBox != null)
        {
            animateBox.SetBool("IsOpen", true);
            animateName.SetBool("IsOpen", true);
        }

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        TriggerTalking();        
        DisplayNextSentence();
    } 
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        animateBox.SetBool("IsOpen", false);
        animateName.SetBool("IsOpen", false);
        blocker.SetActive(false);

        if (hasChoice == true)
        {
            DisplayChoices();
            hasChoice = false;
        }
        //end of dialogue
        if (tut) { 
            DialogueDone();
        }
        dialogueOpen = false;
        speech.Stop();
    }

    void DisplayChoices()
    {
        /*
        choice1.SetActive(true);
        choice2.SetActive(true);
        choice3.SetActive(true);
        */
    }
}
