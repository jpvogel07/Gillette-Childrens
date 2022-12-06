using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldEvent : MonoBehaviour
{
    public GameObject Jade;
    public int EventCounter=0;
    public GameObject StartKey;
    public GameObject StartDoor;
    public GameObject StartJade;
    public GameObject lobby;
    public GameObject checkin;
    public bool check = true;
    private int TutCount = 3;

    public static Action TutDone = delegate { };
    public static Action TaskDone = delegate { };

    void Start()
    {
        DialogueManager.DialogueDone += ProgressCheck;
        Debug.Log("event: " + EventCounter);
        Start_DTrigger();
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
            Debug.Log("event: " + EventCounter);
        }
        else if (EventCounter==2)
        {
            StartDoor.SetActive(true);//going through door handles rest of event
            Debug.Log("event: " + EventCounter);
        }
        else if (EventCounter==3)
        {
            lobby.SetActive(true);
            checkin.SetActive(false);


            StartJade.SetActive(false);
            Jade.SetActive(true);
            TutDone();
            Debug.Log("event: " + EventCounter);
        }
        else if (EventCounter==4)
        {
            TaskDone();
            Debug.Log("event: " + EventCounter);
        }
        else if(EventCounter == 5)
        {
            Debug.Log("event: " + EventCounter);
        }

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
}
