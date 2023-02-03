using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARHandler : MonoBehaviour
{
    public GameObject scene;
    public GameObject mouse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //scene.GetComponent<CanvasHandler>().ARHandler();
        mouse.GetComponent<PlayerMovement>().AR = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //scene.GetComponent<CanvasHandler>().ARHandler();
        mouse.GetComponent<PlayerMovement>().AR = false;
        scene.GetComponent<CanvasHandler>().check = true;
        scene.GetComponent<CanvasHandler>().ARHandler();
    }

    public void handle()
    {
        scene.GetComponent<CanvasHandler>().ARHandler();
    }
}
