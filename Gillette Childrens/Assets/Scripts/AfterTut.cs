using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterTut : MonoBehaviour
{

    void Start()
    {
        WorldEvent.TutDone += TurnOff;
        this.gameObject.SetActive(false);
    }

    private void TurnOff()
    {
        this.gameObject.SetActive(true);
        WorldEvent.TutDone -= TurnOff;
    }
}
