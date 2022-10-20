using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskList : MonoBehaviour
{
    public GameObject tasks;
    public int TaskNum = 3;

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
        //tasks = GameObject.Find("HUD");
    }

    private void Start()
    {
        AllDone = new bool[TaskNum];
        tasklist = new TextMeshProUGUI[TaskNum];

        Won.SetActive(false);
        for (i=1;i<TaskNum+1;i++)
        {
            tasklist[i-1] = tasks.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }

    public void TaskComplete(int complete)
    {
        if (tasklist[complete])
        {
            //tasklist[complete].text = tasklist[complete].text.ToString() + " done";
            tasklist[complete].gameObject.SetActive(false);
        }
        tasklist[complete] = null;
        AllDone[complete] = true;

        Won.SetActive(done());
    }

    private bool done()
    {
        for (i=0;i<TaskNum;i++)
        {
            Debug.Log(AllDone[i]);
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
