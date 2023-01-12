using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public int TaskNum;
    public GameObject mouse;
    private GameObject item;
    private WorldEvent World;
    private GameObject Jade;
    private Transform Popup;
    //public string name;

    private void OnEnable()
    {
        World = GameObject.Find("World Event System").gameObject.GetComponent<WorldEvent>();
        mouse = GameObject.Find("mouse").gameObject;
        item = GameObject.Find("inventory");
        Jade = World.GetComponent<WorldEvent>().Jade;
        Popup = GameObject.Find("PopupParent").transform.GetChild(0);
    }

    public void DoTask()
    {
        if (TaskNum == Jade.GetComponent<DialogueTrigger>().stage)
        {
            ItemPopup();
            this.gameObject.GetComponent<DialogueTrigger>().secret = true;
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            mouse.GetComponent<PlayerMovement>().keys[TaskNum] = true;
            item.GetComponent<Image>().sprite = this.gameObject.GetComponent<Image>().sprite;
            item.GetComponent<Image>().color = Color.white;
            this.gameObject.SetActive(false);
            World.Jade.gameObject.GetComponent<DialogueTrigger>().secret = false;
        }
        else
        {
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Debug.Log("task failed");
        }
    }
    private void ItemPopup() {
        Popup.gameObject.SetActive(true);
    }
}
