using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterTut : MonoBehaviour
{
    public GameObject[] TaskItems;
    private int i;

    void Start()
    {
        WorldEvent.TutDone += TurnOff;
        i = 0;
        while (i != TaskItems.Length)
        {
            TaskItems[i].SetActive(false);
            i++;
        }
    }
    private void OnDisable()
    {
        WorldEvent.TutDone -= TurnOff;
    }

    private void TurnOff()
    {
        i = 0;
        while (i!=TaskItems.Length)
        {
            TaskItems[i].SetActive(true);
            i++;
        }
    }
}
