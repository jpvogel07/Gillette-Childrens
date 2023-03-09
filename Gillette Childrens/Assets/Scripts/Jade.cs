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
    public Image item;
    public Sprite BlackBox;
    public GameObject InvWisp;
    private GameObject wisp;
    //public  TextMeshProUGUI obj;
    //public string[] TaskList;
    public PlayerMovement mouse;
    

    public static Action NextTask = delegate { };
    public static Action<GameObject> GiveThis = delegate { };

    private void OnEnable()
    { 
        GiveThis(this.gameObject);
    }

    private void Start()
    {
        JadeSpeech = this.GetComponent<DialogueTrigger>();

        Debug.Log("mouse is " + mouse);
        JadeSpeech.secret = mouse.JadeSecret;
        item = mouse.inventory;
        this.GetComponent<DialogueTrigger>().secret = mouse.JadeSecret;
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

    public void passThis(GameObject Tmouse)
    {
        mouse = Tmouse.GetComponent<PlayerMovement>();
        mouse.JadeO = this.gameObject;
    }
}
