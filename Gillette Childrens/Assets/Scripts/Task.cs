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
    //private WorldEvent World;
    public GameObject Jade;
    //private Transform Popup;
    //public string name;

    private void OnEnable()
    {
        //World = GameObject.Find("World Event System").gameObject.GetComponent<WorldEvent>();
        mouse = GameObject.Find("mouse").gameObject;
        item = GameObject.Find("inventory");
        //Jade = World.GetComponent<WorldEvent>().Jade;
        Jade = GameObject.Find("Jade");
        //Popup = GameObject.Find("PopupParent").transform.GetChild(0);
        if (mouse.GetComponent<PlayerMovement>().keys[TaskNum])
        {
            Destroy(this.gameObject);
        }
    }

    public void DoTask()
    {
        if (TaskNum == mouse.GetComponent<PlayerMovement>().CurrTask)
        {
            //ItemPopup();
            this.gameObject.GetComponent<DialogueTrigger>().secret = true;
            this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            mouse.GetComponent<PlayerMovement>().keys[TaskNum] = true;
            //item.GetComponent<Image>().sprite = mouse.gameObject.GetComponent<PlayerMovement>().InventoryPics[TaskNum];
            item.GetComponent<Image>().color = Color.white;

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
