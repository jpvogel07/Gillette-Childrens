using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    private PlayerMovement movement;
    private CanvasHandler OnOff;
    public int KeyReq;
    public Canvas NextScene;

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
        }
    }
}
