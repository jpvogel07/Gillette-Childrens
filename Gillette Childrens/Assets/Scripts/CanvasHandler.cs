using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasHandler : MonoBehaviour
{
    public Sprite RL;
    public Sprite Art;
    public Sprite Map;
    public GameObject MiniMap;
    public bool check = false;
    public GameObject AR;
    public GameObject[] doors;

    private void Start()
    {
        //AR = GameObject.Find("AR switch").gameObject;
        Art = this.GetComponent<Image>().sprite; //<-- does not grab source image from image component 

    }

    private void Awake()
    {
        MiniMap = GameObject.Find("MiniMap");
        AR = GameObject.Find("AR switch");
        MiniMap.GetComponent<Image>().sprite = Map;
        //AR.GetComponent<ARHandler>().scene = this.gameObject;

    }

    public void On()
    {
        this.gameObject.SetActive(true);
        MiniMap.GetComponent<Image>().sprite = Map;
        //AR.GetComponent<ARHandler>().scene = this.gameObject;
    }

    public void Next(int NextScene)
    {
        SceneManager.LoadScene(sceneBuildIndex: NextScene);
    }

    public void Off()
    {
        this.gameObject.SetActive(false);
    }

    public void ARHandler()
    {
        if (check)
        {
            this.GetComponent<Image>().sprite = Art;
            foreach (GameObject door in doors)
            {
                if (door != null)
                {
                    door.SetActive(true);
                }
            }
            check = false;
        }
        else
        {
            this.GetComponent<Image>().sprite = RL;
            foreach (GameObject door in doors)
            {
                if (door != null)
                {
                    door.SetActive(false);
                }
            }
            check = true;
        }
    }

}
