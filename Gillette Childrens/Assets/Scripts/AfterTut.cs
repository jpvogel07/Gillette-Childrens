using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterTut : MonoBehaviour
{
    public GameObject[] TurnOn;
    public GameObject[] TurnOff;
    private int i,f;

    void Start()
    {
        WorldEvent.TutDone += ThingsOffNOn;
        i = 0;
        while (i != TurnOn.Length)
        {
            TurnOn[i].SetActive(true) ;
            i++;
        }
        f = 0;
        while (f != TurnOff.Length)
        {
            TurnOff[f].SetActive(false);
            f++;
        }
    }
    private void OnDisable()
    {
        WorldEvent.TutDone -= ThingsOffNOn;
    }

    private void ThingsOffNOn()
    {
        f = 0;
        i = 0;
        while (f != TurnOff.Length)
        {
            
            TurnOff[f].SetActive(false);
            f++;
        }
        while (i != TurnOn.Length)
        {
            
            TurnOn[i].SetActive(true);
            i++;
        }
    }
}
