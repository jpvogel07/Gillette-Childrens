using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainL1 : MonoBehaviour
{
    public void enable()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
