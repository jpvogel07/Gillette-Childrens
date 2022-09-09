using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{
    public void On()
    {
        this.gameObject.SetActive(true); 
    }
    public void Off()
    {
        this.gameObject.SetActive(false);
    }
}
