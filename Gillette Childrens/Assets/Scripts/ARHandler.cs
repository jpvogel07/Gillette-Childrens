using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARHandler : MonoBehaviour
{
    public GameObject scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scene.GetComponent<CanvasHandler>().ARHandler();
        Debug.Log("image swap");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        scene.GetComponent<CanvasHandler>().ARHandler();
    }
}
