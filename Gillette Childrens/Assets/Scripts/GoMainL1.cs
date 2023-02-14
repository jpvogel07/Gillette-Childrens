using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainL1 : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
