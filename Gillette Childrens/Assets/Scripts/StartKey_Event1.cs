using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKey_Event1 : MonoBehaviour
{
    public GameObject Events;

    public void DoThing()
    {
        //trigger Jade next dialogue

        this.gameObject.SetActive(false);
        Events.GetComponent<WorldEvent>().check = true;
        Events.GetComponent<WorldEvent>().Start_DTrigger();
    }
}
