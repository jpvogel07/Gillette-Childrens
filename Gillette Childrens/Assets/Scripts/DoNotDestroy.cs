using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        Pause_Menu.GoMain += D;
    }

    private void OnDisable()
    {
        Pause_Menu.GoMain -= D;
    }

    private void D()
    {
        Destroy(this);
    }
}
