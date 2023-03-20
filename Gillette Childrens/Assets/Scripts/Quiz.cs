using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField] GameObject TestMenu;
    [SerializeField] string[] questions;
    [SerializeField] int[] answers;
    [SerializeField] string[][][] options;
    int index;

    public void startTest()
    {
        TestMenu.SetActive(true);
        index = 0;

    }

    public void endTest()
    {
        TestMenu.SetActive(false);
    }
}
