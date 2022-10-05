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
    public GameObject continueButton;
    public GameObject backButton;

    private Queue<string> sentences;
    private string[] backer;
    
    private int count = 0;
    private int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueText.enabled = true;
        textBox.SetActive(true);
        //continueButton.SetActive(true);
        //backButton.SetActive(true);
        nameText.enabled = true;

        animateBox.SetBool("IsOpen", true);
        animateName.SetBool("IsOpen", true);

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
    }
}
