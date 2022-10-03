using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private PlayerMovement movement;

    public int KeyNum;
    public bool isTask;
    public int taskDone;
    //public text pop up

    private void Start()
    {
        movement = GameObject.Find("mouse")?.GetComponent<PlayerMovement>();
    }
    public void giveItem()
    {
        if (movement!=null)
        {
            movement.keys[KeyNum] = true;
            Debug.Log(KeyNum);
            Debug.Log(movement.keys[KeyNum]);

            if (isTask)
            {
                this.gameObject.GetComponent<Task>().donetask(taskDone);
            }
            this.gameObject.SetActive(false);
            //create key item pop up now
        }
    }
}
