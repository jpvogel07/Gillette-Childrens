using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldEvent : MonoBehaviour
{
    public GameObject win;
    public GameObject Jade;
    public int EventCounter=0;
    public GameObject StartKey;
    public GameObject StartDoor;
    public GameObject StartJade;
    public GameObject lobby;
    public GameObject checkin;
    public GameObject checkdoor;
    public bool check;
    private int TutCount = 3;
    public PlayerMovement mouse;

    public static Action TutDone = delegate { };
    public static Action TaskDone = delegate { };

    void Start()
    {
        mouse = GameObject.Find("mouse").GetComponent<PlayerMovement>();
        if (mouse.tut)
        {
            NoReload();
        }
        else
        {
            checkdoor.SetActive(false);
            check = true;
            DialogueManager.DialogueDone += ProgressCheck;
            Start_DTrigger();
            GameObject.Find("dialogue manager").gameObject.GetComponent<DialogueManager>().tut = true;
            mouse.winner = win;
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
            Debug.Log("event 1");
        }
        else if (EventCounter==2)
        {
            StartDoor.SetActive(true);//going through door handles rest of event
        }
        else if (EventCounter==3)
        {
            //lobby.GetComponent<CanvasHandler>().On();
            //checkin.SetActive(false);
            checkdoor.SetActive(true);
            Jade.SetActive(true);
            //Jade.GetComponent<DialogueTrigger>().secret = true;
            mouse.InventorySwitch(0);
            TutDone();
            mouse.tut = true;
            mouse.inventory.gameObject.SetActive(true);
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
        Debug.Log("prog");
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
        Jade.SetActive(true);
        TutDone();
        mouse.tut = true;
        Destroy(checkin);
        DestoryTut();
    }
}
