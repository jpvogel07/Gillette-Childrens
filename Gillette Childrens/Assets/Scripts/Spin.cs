using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinspeed=0;
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, spinspeed, Space.Self);
    }
}
