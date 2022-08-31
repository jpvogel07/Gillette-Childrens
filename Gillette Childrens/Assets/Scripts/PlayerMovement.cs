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
        //this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        this.gameObject.transform.position = mousePos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("clickable"))
        {
            pinputs.player.movement.started += movment;
            //switch image
            Debug.Log("highlighted");
            highlighted = true;
            grabbed = collision.gameObject;
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("clickable"))
        {
            pinputs.player.movement.started -= movment;
            //switch image
            highlighted = false;
            grabbed = null;
        }
    }
    private void movment(InputAction.CallbackContext c)
    {
        Debug.Log("click");
        if (highlighted)
        {
            grabbed.gameObject.transform.parent = this.transform;
            highlighted = false;
        }
        else if(!highlighted&&grabbed.gameObject.transform.parent!=null)
        {
            grabbed.gameObject.transform.parent = null;
        }
    }

}
