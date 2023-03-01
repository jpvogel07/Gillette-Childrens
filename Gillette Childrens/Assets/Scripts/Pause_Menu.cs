using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject backpackButton;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        backpackButton.SetActive(false);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        backpackButton.SetActive(true);
    }

    public void mainMenu()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        SceneManager.LoadScene("Main Menu");
        //Debug.LogError("No functioning main menu yet");
    }

    public void close()
    {
        Debug.LogError("Quit");
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
