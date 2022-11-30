using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterTut : MonoBehaviour
{

    void Start()
    {
        WorldEvent.TutDone += TurnOff;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void TurnOff()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        WorldEvent.TutDone -= TurnOff;
    }
}
