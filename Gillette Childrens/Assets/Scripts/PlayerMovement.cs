using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public GoMainL1 Go;
    private Inputs pinputs;
    public bool tut;

    public bool AR;
    public GameObject ARHandler;
    public GameObject MiniMap;
    public GameObject Objective;

    public GameObject HUD;
    public GameObject winner;

    public int CurrTask;
    public int EndTask = 4;
    
    public bool JadeSecret;
   
    public bool[] keys = new bool[3];
    public string[] taskList;

    public TextMeshProUGUI objectiveTXT;
    public Sprite[] InventoryPics = new Sprite[3];
    
    public Image inventory;
    public GameObject JadeO;
    //public GameObject WES;

    public static Action playClick = delegate { };

    private Vector3 OGpos;

    private void Awake()
    {
        Go.enable();
        Task.NeedNow += GiveThis;
        WorldEvent.ThisPass += takeThat;
        Jade.NextTask += NewTask;
        Jade.GiveThis += herego;
        WorldEvent.TutDone += afterTut;
        CanvasHandler.GetThings += PassThings;        
        pinputs = new Inputs();
        pinputs.Enable();
    }

    private void Start()
    {
        JadeO.GetComponent<Image>().enabled = false;
        JadeO.GetComponent<Jade>().passThis(this.gameObject);
        JadeO.GetComponent<Jade>().HUD = HUD;
        JadeO.GetComponent<Jade>().item = inventory;

        inventory = JadeO.GetComponent<Jade>().item;

        objectiveTXT = Objective.GetComponentInChildren<TextMeshProUGUI>();
        OGpos = inventory.GetComponent<RectTransform>().position;
    }
    private void OnDisable()
    {
        pinputs.Disable();
        //pinputs.player.movement.started -= movment;
        Jade.NextTask -= NewTask;
        Jade.GiveThis -= herego;
        WorldEvent.TutDone -= afterTut;
        CanvasHandler.GetThings -= PassThings;
        WorldEvent.ThisPass -= takeThat;
        Task.NeedNow -= GiveThis;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        this.gameObject.transform.position = mousePos;

        if (Input.GetMouseButtonDown(0) && AR)
        {
            ARHandler.GetComponent<ARHandler>().handle();
        }
        if(Input.GetMouseButtonUp(0) && AR)
        {
            ARHandler.GetComponent<ARHandler>().handle();
        }

        if (Input.GetMouseButtonDown(0))
        {
            playClick();
        }
    }

    public void InventorySwitch(int i)
    {
        inventory.GetComponent<Image>().sprite = InventoryPics[i];
        inventory.sprite = InventoryPics[i];

        float ratio = 0.0f;
        ratio = (float)InventoryPics[i].texture.width / (float)InventoryPics[i].texture.height;
        Debug.Log(ratio);
        ratio = 1 / ratio;
        inventory.GetComponent<RectTransform>().localScale = new Vector3(1, ratio, 1);
        inventory.GetComponent<RectTransform>().position = OGpos;
        inventory.GetComponent<RectTransform>().position -= new Vector3(0, 15f*inventory.GetComponent<RectTransform>().localScale.y, 0);

        inventory.color = Color.grey;
        objectiveTXT.text = "Obtain the " + taskList[CurrTask];
        inventory.GetComponent<Image>().color = Color.grey;
        
    }

    public void NewTask()
    {
        CurrTask++;
        if (CurrTask == EndTask)
        {
            HUD.SetActive(false);
            winner.SetActive(true);
        }
        JadeSecret = false;
        secretSwitch();

        InventorySwitch(CurrTask);
    }

    public void afterTut()
    {
        ARHandler.SetActive(true);
        Objective.SetActive(true);
    }

    public void PassThings(CanvasHandler scene)
    {
        scene.MiniMap = MiniMap;
        scene.AR = ARHandler;
        ARHandler.GetComponent<ARHandler>().scene = scene.gameObject;
        //JadeO.GetComponent<DialogueTrigger>().secret = JadeSecret;
    }

    public void takeThat(GameObject wes)
    {
        Debug.Log("Jade is "+wes);
        JadeO = wes.GetComponent<WorldEvent>().Jade;
        JadeO.GetComponent<DialogueTrigger>().secret = JadeSecret;
    }

    public void secretSwitch()
    {
        JadeO.GetComponent<DialogueTrigger>().secret = JadeSecret;
    }

    public void herego(GameObject jj)
    {
        jj.GetComponent<Jade>().mouse = this.gameObject.GetComponent<PlayerMovement>();
    }

    private void GiveThis(GameObject thing)
    {
        Debug.Log("this is " + this.gameObject);
        Debug.Log("the thing is "+thing);
        Debug.Log("the mouse in thing is "+thing.GetComponent<Task>().mouse);
        thing.GetComponent<Task>().mouse = this.gameObject;
    }
}
