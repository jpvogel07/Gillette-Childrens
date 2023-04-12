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
    private int i;
    private Inputs pinputs;
    public bool tut;
    //private bool highlighted;
    //private GameObject grabbed;
    //public ClickableObject ClkObj;

    public bool AR;
    public GameObject ARHandler;
    public GameObject MiniMap;
    public GameObject Objective;
    public GameObject toggler;

    public GameObject HUD;
    public GameObject winner;

    public int CurrTask;
    public int EndTask = 4;
    public GameObject jade;
    public bool JadeSecret;
    public bool[] keys = new bool[3];
    public string[] taskList;
    public TextMeshProUGUI objectiveTXT;
    
    public Sprite[] InventoryPics = new Sprite[3];
    public Image inventory;
    //public GameObject WES;

    public static Action playClick = delegate { };

    private Vector3 OGpos= new Vector3(90,-250,0);
   
    private void OnEnable()
    {
        pinputs = new Inputs();
        pinputs.Enable();
        //pinputs.player.movement.started += movment;
        Jade.NextTask += NewTask;
        WorldEvent.TutDone += afterTut;
        CanvasHandler.GetThings += PassThings;
        objectiveTXT = Objective.GetComponentInChildren<TextMeshProUGUI>();
        /*
        for (i=1;i<taskNum;i++)
        {
            InventoryPics[i--] = WES.GetComponent<AfterTut>().TaskItems[i].GetComponent<Image>().sprite;
        }
        */
        //inventory = GameObject.Find("inventory").GetComponent<Image>();

    }
    private void OnDisable()
    {
        pinputs.Disable();
        //pinputs.player.movement.started -= movment;
        Jade.NextTask -= NewTask;
        WorldEvent.TutDone -= afterTut;
        CanvasHandler.GetThings -= PassThings;
    }

    void Start()
    {
        

    }

    void Update()
    {
        inventory.GetComponent<RectTransform>().localPosition = new Vector3(90, -250 - (15f * inventory.GetComponent<RectTransform>().localScale.y), 0);
        Vector3 mousePos = Input.mousePosition;
        //Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mousePos.z = 0;
        this.gameObject.transform.position = mousePos;
        /*
        if (Input.GetMouseButtonUp(0)&&ClkObj)
        {
            ClkObj.MovedCheck();
            ClickableObject[] cObjects = transform.GetComponentsInChildren<ClickableObject>();
            foreach (ClickableObject item in cObjects)
                item.PutDown();
        }
        */

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
            //Debug.Log("Click");
            playClick();
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("clickable"))
        {
            pinputs.player.movement.started += movment;
            highlighted = true;
            grabbed = collision.gameObject;
            ClkObj = collision.GetComponent<ClickableObject>();
            ClkObj.GetComponent<ClickableObject>().highlighted();
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("clickable"))
        {
            pinputs.player.movement.started -= movment;
            highlighted = false;
            grabbed = null;
            if (ClkObj.GetComponent<ClickableObject>() != null)
            {
                ClkObj.GetComponent<ClickableObject>().nonhighlighted();
                ClkObj.GetComponent<ClickableObject>().Obj.x = ClkObj.transform.position.x;
                ClkObj.GetComponent<ClickableObject>().Obj.y = ClkObj.transform.position.y;
            }
        }
        
        if(collision.CompareTag("AR"))
        {
            
        }
    }
    private void movment(InputAction.CallbackContext c)
    {
        if (highlighted)
        {
            grabbed.gameObject.transform.parent = this.transform;
            highlighted = false;
            ClkObj.MovedCheck();
            Debug.Log("picked up");
        }
        else if(!highlighted&&grabbed.gameObject.transform.parent!=null)
        {
            grabbed.gameObject.transform.parent = null;
        }
    }
    */

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
        //inventory.GetComponent<RectTransform>().position -= new Vector3(0, 15f*inventory.GetComponent<RectTransform>().localScale.y, 0);

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

        InventorySwitch(CurrTask);
    }

    public void afterTut()
    {
        //inventory.SetActive(true);
        //ARHandler.SetActive(true);
        Objective.SetActive(true);
    }

    public void PassThings(CanvasHandler scene)
    {
        scene.MiniMap = MiniMap;
        scene.AR = ARHandler;
        ARHandler.GetComponent<ARHandler>().scene = scene.gameObject;
    }
}
