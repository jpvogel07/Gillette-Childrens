using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jade : MonoBehaviour
{
    public GameObject world;
    private DialogueTrigger JadeSpeech;
    public GameObject winscreen;
    public GameObject HUD;

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
            Debug.Log(JadeSpeech.stage);
            if (JadeSpeech.stage == 4)
            {
                HUD.SetActive(false);
                winscreen.SetActive(true);
            }
            JadeSpeech.secret = true;
        }
    }
}
