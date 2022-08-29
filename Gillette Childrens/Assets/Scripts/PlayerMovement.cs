using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerMovement : MonoBehaviour
{
    private Inputs pinputs;
    private bool highlighted;

    private void OnEnable()
    {
        pinputs = new Inputs();
        pinputs.Enable();
        pinputs.player.movement.started += movment;

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
        
    }

    private void movment(InputAction.CallbackContext c)
    {
        Debug.LogError("working");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("clickable"))
        {
            //switch image
            highlighted = true;
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("clickable"))
        {
            //switch image
            highlighted = false;
        }
    }
}
