using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task : MonoBehaviour
{
    public int TaskNum;
    private WorldEvent World = GameObject.Find("World Event System").gameObject.GetComponent<WorldEvent>();

    public void DoTask()
    {
        if (TaskNum == World.EventCounter-4)
        {
            World.check = true;
            this.gameObject.SetActive(false);
        }
    }
}
