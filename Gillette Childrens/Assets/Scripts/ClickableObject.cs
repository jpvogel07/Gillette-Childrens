using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableObject : MonoBehaviour
{
    public Vector2 Obj;
    private Transform parent;
    private Sprite nonHighLighted;
    public Sprite HighLighted;

    void Start()
    {
        this.tag = "clickable";
        Obj.x = this.transform.position.x;
        Obj.y = this.transform.position.y;
        parent = this.transform.parent;
        nonHighLighted = this.GetComponent<SpriteRenderer>().sprite;
    }

    public void MovedCheck()
    {
        //checks if obj has moved since mouse down
       /* if ((Input.GetMouseButtonUp(0) && this.transform.position.x != Obj.x) || (Input.GetMouseButtonUp(0) && this.transform.position.y != Obj.y))
        {
            Debug.Log("moved");
            PutDown();
        }*/
    }

    public void highlighted()
    {
        this.GetComponent<SpriteRenderer>().sprite = HighLighted;
    }
    public void nonhighlighted()
    {
        this.GetComponent<SpriteRenderer>().sprite = nonHighLighted;
    }

    public void PutDown()
    {
        this.transform.parent = parent;
    }
}
