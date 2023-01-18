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
        Debug.Log("pot");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //scene.GetComponent<CanvasHandler>().ARHandler();
        mouse.GetComponent<PlayerMovement>().AR = false;
    }

    public void handle()
    {
        scene.GetComponent<CanvasHandler>().ARHandler();
        Debug.Log("swap");
    }
}
