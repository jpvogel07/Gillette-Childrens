using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKey_Event1 : MonoBehaviour
{
    public GameObject Events;

    public void DoThing()
    {
        //trigger Jade next dialogue

        Events.GetComponent<WorldEvent>().check = true;
        Events.GetComponent<WorldEvent>().DTrigger();
        this.gameObject.SetActive(false);
    }
}