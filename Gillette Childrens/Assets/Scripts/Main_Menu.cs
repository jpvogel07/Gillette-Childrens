using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(21);//loads hud that then goes to main lobby
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
