using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHandler : MonoBehaviour
{
    public Sprite RL;
    public Sprite Art;
    public Sprite Map;
    public GameObject MiniMap;
    private bool check=false;
    public GameObject AR;
    public GameObject[] doors;

    private void Start()
    {
        //AR = GameObject.Find("AR switch").gameObject;
        Art = this.GetComponent<Image>().sprite; //<-- does not grab source image from image component 

    }

    public void On()
    {
        this.gameObject.SetActive(true);
        MiniMap.GetComponent<Image>().sprite = Map;
        AR.GetComponent<ARHandler>().scene = this.gameObject;
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
                door.SetActive(true);
            check = false;
        }
        else
        {
            this.GetComponent<Image>().sprite = RL;
            foreach (GameObject door in doors)
                door.SetActive(false);
            check = true;
        }
    }
}
