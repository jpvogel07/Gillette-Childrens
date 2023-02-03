using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheck : MonoBehaviour
{
    public bool bGetTimeScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bGetTimeScale)
        {
            bGetTimeScale = false;
            Debug.Log(Time.timeScale);
        }
    }
}
