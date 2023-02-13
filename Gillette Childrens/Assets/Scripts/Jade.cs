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
    public  TextMeshProUGUI obj;
    public string[] TaskList;
    public PlayerMovement mouse;
    

    public static Action NextTask = delegate { };

    private void Awake()
    {
        GameObject.Find("dialogue manager").gameObject.GetComponent<DialogueManager>().tut = false;
        JadeSpeech = this.GetComponent<DialogueTrigger>();
        obj.text = " Obtain " + TaskList[0];
        mouse = GameObject.Find("mouse").gameObject.GetComponent<PlayerMovement>();
        JadeSpeech.secret = mouse.JadeSecret;
    }

    public void flip()
    {
        if (this.GetComponent<DialogueTrigger>().secret)
        {
            NextTask();
            wisp = Instantiate(InvWisp);
            wisp.transform.SetParent(this.transform.parent.transform);

            //item.GetComponent<Image>().sprite = BlackBox;
            //item.transform.localScale = new Vector3(1, 1, 1);

            obj.text = " Obtain " + TaskList[JadeSpeech.stage];
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
