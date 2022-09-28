using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskList : MonoBehaviour
{
    public GameObject tasks;
    public int TaskNum = 5;

    private bool[] AllDone;
    private TextMeshProUGUI[] tasklist;
    private int i;
    private GameObject Won;

    private void OnEnable()
    {

    }
    private void OnDisable()
    {
        
    }

    private void Awake()
    {
        Won = GameObject.Find("winscreen");
        tasks = GameObject.Find("HUD");
    }

    private void Start()
    {
        AllDone = new bool[TaskNum];
        tasklist = new TextMeshProUGUI[TaskNum];

        Won.SetActive(false);
        for (i=0;i<TaskNum;i++)
        {
            tasklist[i] = tasks.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }

    public void TaskComplete(int complete)
    {
        tasklist[complete].text = tasklist[complete].text.ToString() + " done";
        AllDone[complete] = true;

        Won.SetActive(done());
    }

    private bool done()
    {
        for (i=0;i<TaskNum;i++)
        {
            if (AllDone[i])
            {

            }
            else
            {
                return false;
            }
        }
        
        return true; 
    }
}
