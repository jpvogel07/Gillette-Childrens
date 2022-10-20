using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task : MonoBehaviour
{
    public GameObject mouse;

    private void Start()
    {
        mouse = GameObject.Find("mouse");
    }

    public void donetask(int complete)
    {
        mouse.GetComponent<TaskList>().TaskComplete(complete);
    }
}
