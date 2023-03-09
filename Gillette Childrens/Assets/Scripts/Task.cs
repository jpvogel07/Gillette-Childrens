using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public int TaskNum;
    public GameObject mouse;
    public Image item;
    private WorldEvent World;
    //private Transform Popup;
    //public string name;

    public static Action<GameObject> NeedNow = delegate { };

    private void OnEnable()
    {
        NeedNow(this.gameObject);
        Debug.Log(mouse);
        //mouse = GameObject.Find("mouse").gameObject;
        item = mouse.GetComponent<PlayerMovement>().inventory;
        if (mouse.GetComponent<PlayerMovement>().keys[TaskNum])
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
    }

    public void DoTask()
    {
        Debug.Log("the mouse is "+mouse);
        if (TaskNum == mouse.GetComponent<PlayerMovement>().CurrTask)
        {
            //ItemPopup();
            this.gameObject.GetComponent<DialogueTrigger>().secret = true;
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            mouse.GetComponent<PlayerMovement>().keys[TaskNum] = true;
            //item.GetComponent<Image>().sprite = mouse.gameObject.GetComponent<PlayerMovement>().InventoryPics[TaskNum];
            Debug.Log(item);
            item.color = Color.white;

            /*float ratio = 0.0f;
            ratio = (float)this.gameObject.GetComponent<Image>().sprite.texture.width / (float)this.gameObject.GetComponent<Image>().sprite.texture.height;
            Debug.Log(ratio);
            ratio = 1 / ratio;
            item.GetComponent<RectTransform>().localScale = new Vector3(1,ratio,1);*/

            //this.gameObject.SetActive(false);
            //World.Jade.gameObject.GetComponent<DialogueTrigger>().secret = true;
            mouse.gameObject.GetComponent<PlayerMovement>().JadeSecret = true;
            mouse.GetComponent<PlayerMovement>().keys[TaskNum] = true;
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            Debug.Log("task failed");
        }
    }

    /*private void ItemPopup() {
        Popup.gameObject.SetActive(true);
    }*/

}
