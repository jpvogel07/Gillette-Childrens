using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animateBox;
    public Animator animateName;
    public GameObject textBox;
    public GameObject mouse;
    public GameObject continueButton;
    public GameObject backButton;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject blocker;
    public GameObject blocker2;
    public GameObject blocker3;
    public GameObject blocker4;
    public bool hasChoice;

    private Queue<string> sentences;
    private string[] backer;
    
    private int count = 0;
    private int number = 0;

    void Start()
    {
        sentences = new Queue<string>();
        mouse = GameObject.Find("mouse")?.gameObject; 
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
        dialogueText.enabled = true;
        textBox.SetActive(true);
        //continueButton.SetActive(true);
        //backButton.SetActive(true);
        nameText.enabled = true;
        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        blocker.SetActive(true);
        blocker2.SetActive(true);
        blocker3.SetActive(true);
        blocker4.SetActive(true);

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
            count++;
        }

        /*for(int k = 0; k < count; k++) 
        {
            backer[k] = dialogue.sentences[k];
        }*/
        
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
        number++;
    }

    public void back(Dialogue dialogue)
    {
        Debug.LogError("We got here");
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            //number--;
        }
        DisplayNextSentence();
    }

    IEnumerator TypeSentence(string sentence) 
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        continueButton.SetActive(true);
        backButton.SetActive(true);
    }
    void EndDialogue()
    {
        Debug.Log("End of Conversation");
        continueButton.SetActive(false);
        backButton.SetActive(false);
        animateBox.SetBool("IsOpen", false);
        animateName.SetBool("IsOpen", false);
        blocker.SetActive(false);
        blocker2.SetActive(false);
        blocker3.SetActive(false);
        blocker4.SetActive(false);

        if (hasChoice == true)
        {
            DisplayChoices();
            hasChoice = false;
        }

        
    }

    void DisplayChoices()
    {
        choice1.SetActive(true);
        choice2.SetActive(true);
        choice3.SetActive(true);
    }
}
