using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jade : MonoBehaviour
{
    public GameObject world;

    public void flip()
    {
        if (!this.GetComponent<DialogueTrigger>().secret)
        {
            this.GetComponent<DialogueTrigger>().stage++;
            this.GetComponent<DialogueTrigger>().secret = true;
            world.GetComponent<WorldEvent>().EventCounter++;
        }
    }
}
