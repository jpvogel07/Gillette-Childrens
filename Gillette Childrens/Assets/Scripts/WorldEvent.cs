using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class WorldEvent : MonoBehaviour
{
    public GameObject win;
    public GameObject Jade;
    public int EventCounter=0;
    public GameObject StartKey;
    public GameObject StartDoor;
    public GameObject StartJade;
    public GameObject lobby;
    public GameObject[] doors;
    public bool check;
    private int TutCount = 3;
    public PlayerMovement mouse;

    public static Action TutDone = delegate { };
    public static Action TaskDone = delegate { };
    public static Action<GameObject> ThisPass = delegate { };

    void Awake()
    {
        mouse = GameObject.Find("mouse").GetComponent<PlayerMovement>();
        if (mouse.tut)
        {
            NoReload();
        }
        else
        {
            check = true;
            DialogueManager.DialogueDone += ProgressCheck;
            Start_DTrigger();
            GameObject.Find("dialogue manager").gameObject.GetComponent<DialogueManager>().tut = true;
            mouse.winner = win;
            ThisPass(gameObject);
        }
    }

    private void OnDisable()
    {
        DialogueManager.DialogueDone -= ProgressCheck;
    }

    private void WorldScript()
    {
        EventCounter += 1;

        if (EventCounter==1)
        {
            StartKey.SetActive(true);//picking up key handles rest of event

            

        }
        else if (EventCounter==2)
        {
            StartDoor.SetActive(true);//going through door handles rest of event

            

        }
        else if (EventCounter==3)
        {
            //lobby.GetComponent<CanvasHandler>().On();
            //checkin.SetActive(false);

            Jade.GetComponent<Image>().enabled = true;
            //Jade.GetComponent<DialogueTrigger>().secret = true;
            mouse.InventorySwitch(0);
            TutDone();
            mouse.tut = true;

            DestoryTut();
        }
        /*else if (EventCounter==4)
        {
            TaskDone();
            Debug.Log("event: " + EventCounter);
        }
        else if(EventCounter == 5)
        {
            Debug.Log("event: " + EventCounter);
        }*/

        check = false;
    }

    private void ProgressCheck()
    {
        if (check)
        {
            WorldScript();
        }
    }

    public void Start_DTrigger()
    {
        StartJade.GetComponent<DialogueTrigger>().stage = EventCounter;
        StartJade.GetComponent<DialogueTrigger>().TriggerDialogue();
        StartJade.GetComponent<DialogueTrigger>().stage = 100;
    }

    public void DTrigger()
    {
        Jade.GetComponent<DialogueTrigger>().stage = EventCounter-3;
        Jade.GetComponent<DialogueTrigger>().TriggerDialogue();
        Jade.GetComponent<DialogueTrigger>().stage = 100;
    }

    public void DestoryTut()
    {
        Destroy(StartJade);
        Destroy(StartDoor);
        Destroy(StartKey);
        Destroy(this.gameObject);
    }

    private void NoReload()
    {
        Debug.Log("tut gone");
        Jade.GetComponent<Image>().enabled = true;
        TutDone();
        mouse.tut = true;
        this.gameObject.GetComponent<AfterTut>().TurnOff();

        Destroy(StartDoor);
        DestoryTut();
    }
}
