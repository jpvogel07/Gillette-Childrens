using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task : MonoBehaviour
{
    public int TaskNum;
    public GameObject mouse;
    private WorldEvent World;

    private void OnEnable()
    {
        World = GameObject.Find("World Event System").gameObject.GetComponent<WorldEvent>();
        mouse = GameObject.Find("mouse").gameObject;
    }

    public void DoTask()
    {
        if (TaskNum == World.EventCounter-3)
        {
            this.gameObject.GetComponent<DialogueTrigger>().secret = true;
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            mouse.GetComponent<PlayerMovement>().keys[TaskNum] = true;
            this.gameObject.SetActive(false);
            World.check = true;
            World.Jade.gameObject.GetComponent<DialogueTrigger>().secret = true;
        }
        else
        {
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Debug.Log("task failed");
        }
    }
}
