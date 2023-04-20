using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Jade : MonoBehaviour
{
    public GameObject world;
    public DialogueTrigger JadeSpeech;
    public GameObject winscreen;
    public GameObject HUD;
    public GameObject item;
    public Sprite BlackBox;
    public GameObject InvWisp;
    private GameObject wisp;
    //public  TextMeshProUGUI obj;
    //public string[] TaskList;
    public PlayerMovement mouse;
    

    public static Action NextTask = delegate { };

    private void OnEnable()
    {
        mouse = GameObject.Find("mouse").GetComponent<PlayerMovement>();
        HUD = GameObject.Find("HUD");
        JadeSpeech = this.GetComponent<DialogueTrigger>();
        JadeSpeech.secret = mouse.JadeSecret;
        JadeSpeech.stage = mouse.CurrTask;
    }

    private void Awake()
    {
        GameObject.Find("dialogue manager").gameObject.GetComponent<DialogueManager>().tut = false;
        mouse = GameObject.Find("mouse").GetComponent<PlayerMovement>();
        HUD = GameObject.Find("HUD");
        //obj.text = " Obtain " + TaskList[0];
        //mouse = GameObject.Find("mouse").gameObject.GetComponent<PlayerMovement>();

    }

    public void flip()
    {
        if (this.GetComponent<DialogueTrigger>().secret)
        {
            wisp = Instantiate(InvWisp);
            wisp.transform.SetParent(this.transform.parent.transform);
            NextTask();

            //item.GetComponent<Image>().sprite = BlackBox;
            //item.transform.localScale = new Vector3(1, 1, 1);

            //obj.text = " Obtain " + TaskList[JadeSpeech.stage];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wisp"))
        {
            Destroy(collision.gameObject);
        }
    }
}
