using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Jade : MonoBehaviour
{
    public GameObject world;
    private DialogueTrigger JadeSpeech;
    public GameObject winscreen;
    public GameObject HUD;
    public GameObject item;
    public Sprite BlackBox;
    public GameObject InvWisp;
    private GameObject wisp;

    public static Action<int> NewIcon = delegate { };

    private void Awake()
    {
        GameObject.Find("dialogue manager").gameObject.GetComponent<DialogueManager>().tut = false;
        JadeSpeech = this.GetComponent<DialogueTrigger>();
        NewIcon(0);
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
            item.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Resized");
            //wisp effect
            wisp = Instantiate(InvWisp);
            InvWisp.gameObject.GetComponent<Image>().sprite = GameObject.Find("mouse").gameObject.GetComponent<PlayerMovement>().InventoryPics[JadeSpeech.stage-1];
            //InvWisp.gameObject.GetComponent<InventoryWisp>().image = GameObject.Find("mouse").gameObject.GetComponent<PlayerMovement>().InventoryPics[JadeSpeech.stage - 1];
            //set new inventory item
            NewIcon(JadeSpeech.stage);
        }
    }
}
