using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Inputs pinputs;
    private bool highlighted;
    private GameObject grabbed;
    public ClickableObject ClkObj;

    private void OnEnable()
    {
        pinputs = new Inputs();
        pinputs.Enable();
        //pinputs.player.movement.started += movment;

    }
    private void OnDisable()
    {
        pinputs.Disable();
        pinputs.player.movement.started -= movment;
    }

    void Start()
    {

    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        this.gameObject.transform.position = mousePos;
        if (Input.GetMouseButtonUp(0))
        {
            ClkObj.MovedCheck();
        }
    }


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
            ClkObj.GetComponent<ClickableObject>().nonhighlighted();
            ClkObj.GetComponent<ClickableObject>().Obj.x = ClkObj.transform.position.x;
            ClkObj.GetComponent<ClickableObject>().Obj.y = ClkObj.transform.position.y;
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

}