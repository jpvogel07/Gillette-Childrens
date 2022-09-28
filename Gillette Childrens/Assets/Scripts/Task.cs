using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Task : TaskList
{
    public void donetask(int complete)
    {
        TaskComplete(complete);
    }
}
