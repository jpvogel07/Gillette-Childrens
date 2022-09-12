using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject textBox;
    public GameObject continueButton;
    public GameObject backButton;

    private Queue<string> sentences;
    private int count;
    private int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.enabled = true;
        dialogueText.enabled = true;
        textBox.SetActive(true);
        continueButton.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            count++;
        }

        DisplayNextSentence();
    } 

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        number++;
    }

    void back(int count)
    {

    }
    void EndDialogue()
    {
        Debug.Log("End of Conversation");
        nameText.enabled = false;
        dialogueText.enabled = false;
        textBox.SetActive(false);
        continueButton.SetActive(false);
    }
}
