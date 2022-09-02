using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Vector2 Obj;
    private Transform parent;

    void Start()
    {
        this.tag = "clickable";
        Obj.x = this.transform.position.x;
        Obj.y = this.transform.position.y;
        parent = this.transform.parent;
    }

    void Update()
    {
        
    }

    public void MovedCheck()
    {
        //checks if obj has moved since mouse
        if (Input.GetMouseButtonUp(0) && this.transform.position.x != Obj.x && this.transform.position.y != Obj.y)
        {
            Debug.Log("moved");
            this.transform.parent = parent;
        }
    }
}
