using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public int speed=1;
    public int height = 1000;

    void Update()
    {
        if (transform.localPosition.y <= height) {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
