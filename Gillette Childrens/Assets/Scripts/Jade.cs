using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jade : MonoBehaviour
{
    public GameObject world;
    private DialogueTrigger JadeSpeech;
    public GameObject winscreen;
    public GameObject HUD;
    public GameObject item;
    public Sprite BlackBox;

    private void Awake()
    {
        GameObject.Find("dialogue manager").gameObject.GetComponent<DialogueManager>().tut = false;
        JadeSpeech = this.GetComponent<DialogueTrigger>();
    }

    public void flip()
    {
        if (!this.GetComponent<DialogueTrigger>().secret)
        {
            JadeSpeech.stage++;
            if (JadeSpeech.stage == 4)
            {
                HUD.SetActive(false);
                winscreen.SetActive(true);
            }
            JadeSpeech.secret = true;
            item.GetComponent<Image>().sprite = BlackBox;
        }
    }
}
