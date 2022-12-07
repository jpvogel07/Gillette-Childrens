using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task : MonoBehaviour
{
    public int TaskNum;
    public GameObject mouse;
    private WorldEvent World;
    private GameObject Jade;

    private void OnEnable()
    {
        World = GameObject.Find("World Event System").gameObject.GetComponent<WorldEvent>();
        mouse = GameObject.Find("mouse").gameObject;
        Jade = World.GetComponent<WorldEvent>().Jade;
    }

    public void DoTask()
    {
        if (TaskNum == Jade.GetComponent<DialogueTrigger>().stage)
        {
            this.gameObject.GetComponent<DialogueTrigger>().secret = true;
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            mouse.GetComponent<PlayerMovement>().keys[TaskNum] = true;
            this.gameObject.SetActive(false);
            World.Jade.gameObject.GetComponent<DialogueTrigger>().secret = false;
        }
        else
        {
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Debug.Log("task failed");
        }
    }
}
