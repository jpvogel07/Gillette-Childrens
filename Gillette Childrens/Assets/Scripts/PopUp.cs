using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    private void OnEnable()
    {
        GameObject.Find("mouse").GetComponent<PlayerMovement>().PopUp = this.gameObject;
    }
}
