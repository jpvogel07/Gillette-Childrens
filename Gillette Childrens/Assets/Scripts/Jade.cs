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
    public GameObject item;
    public Sprite BlackBox;
    public GameObject InvWisp;
    private GameObject wisp;
    public  TextMeshProUGUI obj;
    public string[] TaskList;
    

    public static Action<int> NewIcon = delegate { };

    private void Awake()
    {
        GameObject.Find("dialogue manager").gameObject.GetComponent<DialogueManager>().tut = false;
        JadeSpeech = this.GetComponent<DialogueTrigger>();
        NewIcon(0);
        obj.text = " Obtain " + TaskList[0];
    }

    public void flip()
    {
        Debug.Log(this.GetComponent<DialogueTrigger>().secret);
        if (this.GetComponent<DialogueTrigger>().secret)
        {
            wisp = Instantiate(InvWisp);
            wisp.transform.SetParent(HUD.transform);
            //InvWisp.gameObject.GetComponent<InventoryWisp>().image = GameObject.Find("mouse").gameObject.GetComponent<PlayerMovement>().InventoryPics[JadeSpeech.stage];
            Debug.Log(JadeSpeech.stage);
            Debug.Log("haha");

            JadeSpeech.stage++;
            if (JadeSpeech.stage == 4)
            {
                HUD.SetActive(false);
                winscreen.SetActive(true);
            }
            JadeSpeech.secret = false;
            item.GetComponent<Image>().sprite = BlackBox;
            item.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Resized");
            //wisp effect
            //InvWisp.gameObject.GetComponent<InventoryWisp>().image = GameObject.Find("mouse").gameObject.GetComponent<PlayerMovement>().InventoryPics[JadeSpeech.stage - 1];
            //set new inventory item
            NewIcon(JadeSpeech.stage);
            obj.text = " Obtain " + TaskList[JadeSpeech.stage];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("wisp"))
        {
            Destroy(collision.gameObject);
        }
    }
}
