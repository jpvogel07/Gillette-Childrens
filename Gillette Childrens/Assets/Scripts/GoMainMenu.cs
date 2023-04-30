using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainMenu : MonoBehaviour
{
    void Awake() { 
    //nothing 
    }

    public void GMM()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
