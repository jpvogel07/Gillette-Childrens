using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    private GameObject mouse, HUD, dialogue;
    private void Awake()
    {
        mouse = GameObject.Find("mouse")?.gameObject;
        HUD = GameObject.Find("HUD")?.gameObject;
        dialogue = GameObject.Find("dialogue manager")?.gameObject;
        Destroy(mouse);
        Destroy(HUD);
        Destroy(dialogue);
        Debug.Log("destoryed - " + mouse + " and " + HUD + " and " + dialogue);
    }

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
