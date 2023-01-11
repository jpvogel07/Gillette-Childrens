using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("main");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("You have quit.");
    }

    public void Options()
    {
        Debug.Log("There are no options!");
    }
}
