using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Task))]
public class RequiredLockedDoor : MonoBehaviour
{
    private PlayerMovement movement;
    private CanvasHandler OnOff;
    public int KeyReq;
    public Canvas NextScene;

    public bool isTask;
    public int taskDone;

    void Start()
    {
        movement = GameObject.Find("mouse")?.GetComponent<PlayerMovement>();
        OnOff = this.gameObject.GetComponentInParent<CanvasHandler>();
        if (NextScene == null)
        {
            Debug.LogError("required next scene = null");
        }
    }

    public void KeyCheck()
    {
        if (movement.keys[KeyReq])
        {
            OnOff.Off();
            NextScene.GetComponent<CanvasHandler>().On();

            if (isTask)
            {
                //this.gameObject.GetComponent<Task>().donetask(taskDone);
            }
        }
    }
}
