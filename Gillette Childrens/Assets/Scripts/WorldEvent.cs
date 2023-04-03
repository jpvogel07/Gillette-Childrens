using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldEvent : MonoBehaviour
{
    private DialogueTrigger script;
    public GameObject win;
    public GameObject toggle;
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
        toggle = mouse.toggler;
        if (mouse.tut)
        {
            NoReload();
        }
        else
        {
            script = this.GetComponent<DialogueTrigger>();
            checkdoor.SetActive(false);
            check = true;
            DialogueManager.DialogueDone += ProgressCheck;
            Start_DTrigger();
            GameObject.Find("dialogue manager").gameObject.GetComponent<DialogueManager>().tut = true;
            mouse.winner = win;
            StartKey.SetActive(false);
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
            toggle.SetActive(true);
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
            Debug.Log("prog");
            WorldScript();
        }
    }

    public void Start_DTrigger()
    {
        script.TriggerDialogue();
        check = true;
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
        toggle.SetActive(true);
        TutDone();
        mouse.tut = true;
        Destroy(checkin);
        DestoryTut();
    }
}
